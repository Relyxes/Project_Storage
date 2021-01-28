using System;
using System.Collections.Generic;


namespace Project_ListStorage_Class
{
    public class Area
    {
        private static Area _area;

        private Area()
        {
        }

        public static Area CreateArea()
        {
            return _area ?? (_area = new Area());
        }

        private readonly List<Storage> _storages = new List<Storage>();
        private readonly ConsoleInterface _consoleInterface = new ConsoleInterface();

        private string _userItem;
        private static string _storageIndex;
        private string _userData;

        public void Start()
        {
            Help();
            Cycle();
            End();
        }

        private void Help() => _consoleInterface.Help();

        private void Cycle()
        {
            int numStorage = 0;
            while (true)
            {
                _consoleInterface.ChooseOperation();
                GetData(out _userData);
                
                if (_userData == "new")
                {
                    _storages.Add(new Storage());
                    _consoleInterface.NewStorage(_storages.Count);
                    _storageIndex = _storages.Count.ToString();
                    numStorage = Convert.ToInt32(_storageIndex);
                    Choose(_storages.Count);
                }
                else if (_userData == "help")
                {
                    _consoleInterface.Help();
                }
                else if (_userData == "nums")
                {
                    _consoleInterface.StoragesCount(_storages.Count);
                }
                else if (_userData == "ch")
                {
                    _consoleInterface.ChooseStorage();
                    GetData(out _storageIndex);
                    try
                    {
                        numStorage = Convert.ToInt32(_storageIndex);
                    }
                    catch (Exception)
                    {
                        _consoleInterface.IncorrectFormat();
                        _storageIndex = null;
                    }

                    Choose(numStorage);
                }
                else if (_userData == "rmws")
                {
                    _consoleInterface.RemoveStorage();
                    try
                    {
                        GetData(out _storageIndex);
                        numStorage = Convert.ToInt32(_storageIndex);
                        RemoveStorage(numStorage);
                        _consoleInterface.StorageRemoved();
                    }
                    catch (Exception)
                    {
                        _consoleInterface.IncorrectIndex();
                    }
                }
                else if (_userData == "clear" && numStorage > 0)
                {
                    _consoleInterface.ClearStorage();
                    GetData(out _storageIndex);

                    if (_storageIndex == null) _consoleInterface.UnChoosenStorage();
                    else
                    {
                        try
                        {
                            numStorage = Convert.ToInt32(_storageIndex);
                            _storages[numStorage - 1].Clear();
                            _consoleInterface.StorageCleared();
                        }
                        catch (Exception)
                        {
                            _consoleInterface.IncorrectFormat();
                        }
                    }
                }

                else if (_userData == "add")
                {
                    if (_storageIndex == null) _consoleInterface.UnChoosenStorage();
                    else
                    {
                        _consoleInterface.StorageInfo(_userData, _storageIndex);
                        GetData(out _userItem);
                        _storages[numStorage - 1].AddNew(_userItem);
                        _userData = null;
                    }
                }
                else if (_userData == "rmw")
                {
                    if (_storageIndex == null) _consoleInterface.UnChoosenStorage();
                    else
                    {
                        _consoleInterface.StorageInfo(_userData, _storageIndex);
                        GetData(out _userItem);
                        _storages[numStorage - 1].Remove(_userItem);
                    }
                }
                else if (_userData == "rpl")
                {
                    if (_storageIndex == null) _consoleInterface.UnChoosenStorage();
                    else
                    {
                        string editData;
                        _consoleInterface.StorageInfo(_userData, _storageIndex);
                        GetDataTo(out _userItem, out editData);
                        _storages[numStorage - 1].Replace(_userItem, editData);
                    }
                }
                else if (_userData == "gl" && numStorage > 0)
                {
                    try
                    {
                        _storages[numStorage - 1].GetList(numStorage);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Что-то пошло не так: \n" + e);
                    }
                }
                else
                {
                    _consoleInterface.IncorrectOperation();
                }
            }

            // ReSharper disable once FunctionNeverReturns
        }

        private void GetData(out string userData)
        {
            userData = Console.ReadLine()?.Trim().ToLower();
        }

        private void GetDataTo(out string userData, out string editData)
        {
            userData = Console.ReadLine()?.Trim().ToLower();
            Console.Write("На: ");
            editData = Console.ReadLine()?.Trim().ToLower();
        }

        private void Choose(int numStorage)
        {
            try
            {
                int itemsLength = _storages[numStorage - 1].ItemsLength();
                _consoleInterface.ChoosenStorage(numStorage, itemsLength);
            }
            catch (Exception)
            {
                _consoleInterface.IncorrectIndex();
            }
        }

        private void RemoveStorage(int index) => _storages.RemoveAt(index - 1);
        

        private void End() => _consoleInterface.End();
        
    }
}