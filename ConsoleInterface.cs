using System;

namespace Project_ListStorage_Class
{
    public class ConsoleInterface
    {
        public ConsoleInterface()
        {
        }

        public void Help() =>
            Console.WriteLine("\nПрограмма формирует несколько складов с базовыми элементами." +
                              "\nКоманды вводятся в строку по очереди." +
                              "\nСписок доступных Команд:" +
                              "\n\t new - Создать новый склад" +
                              "\n\t rmws - Удалить склад" +
                              "\n\t gl - Показать список элементов на складе;" +
                              "\n\t ch - Выбрать склад для последующих операций;" +
                              "\n\t add - Добавить элемент на выбранный склад;" +
                              "\n\t rmw - Удалить элемент на выбранном складе;" +
                              "\n\t rpl - Заменить элемент на другой на выбранном складе;" +
                              "\n\t nums - Общее количество складов;" +
                              "\n\t clear - Очистить выбранный склад.");

        public void ChooseOperation() =>
            Console.WriteLine("Выберите операцию: help, new, ch, add, rmw, rmws, clear, rpl, gl, nums");
        public void End() => Console.WriteLine("Завершение программы...");
        public void RemoveStorage() => Console.Write("Удалить склад №: ");
        public void StorageRemoved() => Console.WriteLine("Склад удалён.");
        public void ChooseStorage() => Console.Write("Выбор склада: ");
        public void UnChoosenStorage() => Console.WriteLine("Склад не выбран.");
        public void IncorrectFormat() => Console.WriteLine("Входная строка имела неверный формат.");
        public void IncorrectOperation() => Console.WriteLine("Такой операции не предусмотрено или склад не выбран.");
        public void IncorrectIndex() => Console.WriteLine("Неверный индекс.");
        public void StorageCleared() => Console.WriteLine("Склад очищен.");
        public void ClearStorage() => Console.Write("Очистить склад №: ");
        public void NewStorage( int storagesCount) => Console.WriteLine("Новый склад №{0} создан.", storagesCount);
        public void StoragesCount( int storagesCount) => Console.WriteLine("Общее число складов = {0}", storagesCount);
        public void ChoosenStorage(int numStorage,int itemsLength) => Console.WriteLine("Выбран склад №{0}, количество позиций: {1} ", numStorage, itemsLength);
        public void StorageInfo(string userData, string storagesCount)
        {
            switch (userData)
            {
                case "new":
                    
                    break;
                case "add":
                    Console.Write("Добавить на склад №{0}: ", storagesCount);
                    break;
                case "rmw":
                    Console.Write("Удалить со склада №{0}: ", storagesCount);
                    break;
                case "rpl":
                    Console.Write("Заменить  на складе №{0}: ", storagesCount);
                    break;
                case "nums":
                 
                    break;
            }
        }

        
    }
}