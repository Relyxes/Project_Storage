using System.Collections.Generic;
using System;

namespace Project_ListStorage_Class
{
    public class Storage
    {
        public Storage() { }

        private List<Item> _items = new List<Item>();
        public int ItemsLength() => _items.Count;
        public void Clear() => _items.Clear();
        public void AddNew(string userItem)
        {
            Item newItem = new Item(userItem);
            newItem.Name = userItem;


            if (_items.Count == 0)
            {
                _items.Add(newItem);
                Console.WriteLine("Новый элемент \"{0}\" добавлен на склад.", userItem);
            }
            else
            {
                bool eqaul = false;
                for (int i = 0; i < _items.Count; i++)
                {
                    if (_items[i].Name.Equals(newItem.Name))
                    {
                        eqaul = true;
                        Console.WriteLine("Такой элемент уже существует." +
                                          "\nДобавить(y/n)?");
                        string key = Convert.ToString(Console.ReadKey().KeyChar).ToLower();
                        
                        if (key == "y" || key == "н")
                        {
                            _items[i].ChangeCount();
                            Console.WriteLine("\nЭлемент \"{0}\" добавлен на склад. Общее количество: {1}", userItem,
                                _items[i].Counts);
                            break;
                        }
                    }
                }

                if (eqaul == false)
                {
                    _items.Add(newItem);
                    Console.WriteLine("Новый элемент \"{0}\" добавлен на склад.", userItem);
                }
            }
        }

        public void Remove(string userItem)
        {
            Item newItem = new Item(userItem);

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name.Equals(newItem.Name))
                {
                    _items.Remove(_items[i]);
                }
            }
        }

        public void Replace(string userItem, string toItem)
        {
            Item newItem = new Item(userItem);

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name.Equals(newItem.Name))
                {
                    _items.Remove(_items[i]);
                    newItem.Name = toItem;
                    _items.Insert(i, newItem);
                }
            }
        }

        public void GetList(int index)
        {
            if (index > 0)
            {
                if (_items.Count == 0)
                    Console.WriteLine("Склад пустой.");
                else
                {
                    Console.WriteLine("Список элементов на складе №{0}: ", index);
                    foreach (Item element in _items)
                    {
                        Console.WriteLine("Наименование: " + element.Name +
                                          "\tКоличество: " + element.Counts);
                    }
                }
            }

            else
                Console.WriteLine("Склад не выбран.");
        }
    }
}