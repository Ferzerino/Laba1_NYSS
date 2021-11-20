using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace laba
{

    /*
     * 1 - Просмотр записей
     * 2 - Создание записи
     * 3 - Удаление записи
     * 4 - Редактирование записи
     * 5 - Просмотр всех записей
     * 6 - Закрыть приложение
     * 
     */
    public class Program
    {

        public static Dictionary<int, Note> notes = new Dictionary<int, Note>();

        static void Main(string[] args)
        {
            string menuChoice = null;
            Note notebook = new Note();

            do
            {
                Console.WriteLine("1 - Просмотр записи");
                Console.WriteLine("2 - Создание записи");
                Console.WriteLine("3 - Удаление записи");
                Console.WriteLine("4 - Редактирование записи");
                Console.WriteLine("5 - Просмотр всех записей");
                Console.WriteLine("6 - Закрыть приложение");

                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        notebook.ShowNote();
                        break;
                    case "2":
                        notebook.CreateNote();
                        break;
                    case "3":
                        notebook.DeleteNote();
                        break;
                    case "4":
                        notebook.EditNote();
                        break;
                    case "5":
                        notebook.ShowAllNotes();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введите одну из возможных цифр!");
                        break;
                }
            } while (menuChoice != "6" || menuChoice == null);


        }

    }
}