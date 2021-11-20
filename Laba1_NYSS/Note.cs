using System;
using System.Collections.Generic;
using System.Text;

namespace laba
{
    public class Note
    {


        public static int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public long Phone { get; set; }
        public string Country { get; set; }
        public string Birthday { get; set; }
        public string Organization { get; set; }
        public string Post { get; set; }
        public string Notes { get; set; }




        public void ShowNote()
        {
            Console.Clear();
            Console.WriteLine("Введите id записи...");
            string idRead = Console.ReadLine();
            int id;
            bool isInt = int.TryParse(idRead, out id);
            if (isInt)
            {
                if (id >= 1 && id <= Id)
                {
                    Console.WriteLine(Program.notes[id].ToString());
                    Console.WriteLine("\nНажмите на любую кнопку для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Такого id не существует. Попробуйте еще раз...");

                }
            }
            else
            {
                Console.WriteLine("Введите число...");
            }



        }
        public void CreateNote()
        {
            Console.Clear();
            Console.WriteLine("Введите имя (Обязательное поле)");
            string tempName = null;
            string name = null;
            bool isNameNull = true;
            do
            {
                tempName = Console.ReadLine();
                isNameNull = String.IsNullOrWhiteSpace(tempName);
                if (!isNameNull)
                {
                    name = tempName;
                }
                else
                {
                    Console.WriteLine("Имя - ОБЯЗАТЕЛЬНОЕ поле...");
                }
            } while (isNameNull);

            Console.WriteLine("Введите Фамилию (Обязательное поле)");
            string tempLastName = null;
            string lastName = null;
            bool isLastNameNull = true;
            do
            {
                tempLastName = Console.ReadLine();
                isLastNameNull = String.IsNullOrWhiteSpace(tempLastName);
                if (!isLastNameNull)
                {
                    lastName = tempLastName;
                }
                else
                {
                    Console.WriteLine("Фамилия - ОБЯЗАТЕЛЬНОЕ поле...");
                }
            } while (isLastNameNull);

            Console.WriteLine("Введите Отчество (Необязательное поле)");
            string secondName = Console.ReadLine();

            Console.WriteLine("Введите Телефон (Обязательное поле)");
            bool isLong = false;
            long phone;
            do
            {
                string tempPhone = Console.ReadLine();
                isLong = Int64.TryParse(tempPhone, out phone);
                if (tempPhone == null || isLong == false)
                {
                    Console.WriteLine("Введите номер корректно(Только цифры)");
                }
            } while (!isLong);


            Console.WriteLine("Введите Страну (Обязательное поле)");
            string tempCountry = null;
            string country = null;
            bool isCountryNull = true;
            do
            {
                tempCountry = Console.ReadLine();
                isCountryNull = String.IsNullOrWhiteSpace(tempCountry);
                if (!isCountryNull)
                {
                    country = tempCountry;
                }
                else
                {
                    Console.WriteLine("Страна - ОБЯЗАТЕЛЬНОЕ поле...");
                }
            } while (isCountryNull);

            Console.WriteLine("Введите дату рождения (Необязательное поле)");
            bool isDate = false;
            DateTime birthDate = new DateTime();
            string birthday = null;
            do
            {
                string tempDate = Console.ReadLine();
                bool isDateNull = String.IsNullOrWhiteSpace(tempDate);
                if (isDateNull)
                {
                    isDate = true;
                    continue;
                }
                else
                {
                    isDate = DateTime.TryParse(tempDate, out birthDate);
                    birthday = birthDate.ToString("dd.MM.yyyy");
                    if (isDate == false)
                    {
                        Console.WriteLine("Введите дату корректно");
                    }
                }
            } while (!isDate);



            Console.WriteLine("Введите название организации (Необязательное поле)");
            string organization = Console.ReadLine();

            Console.WriteLine("Введите должность (Необязательное поле)");
            string post = Console.ReadLine();

            Console.WriteLine("Введите прочие заметки (Необязательное поле)");
            string notes = Console.ReadLine();

            Id++;
            Program.notes.Add(Id, new Note()
            {
                FirstName = name,
                LastName = lastName,
                SecondName = secondName,
                Phone = phone,
                Country = country,
                Birthday = birthday,
                Organization = organization,
                Post = post,
                Notes = notes
            });

            Console.WriteLine("Запись успешно создана! Нажмите на любую кнопку для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
        public void DeleteNote()
        {
            string choice;
            Console.Clear();
            Console.WriteLine("Введите id записи...");
            string idRead = Console.ReadLine();
            int id;
            bool isInt = int.TryParse(idRead, out id);
            if (isInt)
            {
                if (id >= 1 && id <= Id)
                {
                    Console.Clear();
                    Console.WriteLine("Введите id записи, которую вы хотите удалить...");

                    Console.WriteLine(Program.notes[id].ToString() + "\n\nЭта запись будет удалена. Продолжить? [д / н]");
                    do
                    {
                        choice = Console.ReadLine(); ;
                        if (choice == "д")
                        {
                            Program.notes.Remove(id);
                            Console.WriteLine("\nЗапись успешно удалена! Нажмите на любую кнопку для продолжения...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (choice == "н")
                        {
                            Console.WriteLine("\nДля возвращения в меню нажмите на любую кнопку...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Значение не распознано\nЭта запись будет удалена. Продолжить? [д / н]");
                        }
                    } while (choice != "д" || choice != "н");
                }
                else
                {
                    Console.WriteLine("Такого id не существует. Попробуйте еще раз...");

                }
            }
            else
            {
                Console.WriteLine("Введите число...");
            }




        }
        public void EditNote()
        {
            Console.Clear();
            Console.WriteLine("Введите id записи, которую хотите отредактировать");

            string idRead = Console.ReadLine();
            int id;
            bool isInt = int.TryParse(idRead, out id);
            if (isInt)
            {
                if (id >= 1 && id <= Id)
                {
                    Console.Clear();
                    Console.WriteLine(Program.notes[id].ToString() + "\n\nКакое из полей вы хотите отредактировать?");
                    string choice = null;
                    bool isChanged;
                    do
                    {
                        Console.WriteLine("1 - Имя");
                        Console.WriteLine("2 - Фамилия");
                        Console.WriteLine("3 - Отчество");
                        Console.WriteLine("4 - Телефон");
                        Console.WriteLine("5 - Страна");
                        Console.WriteLine("6 - Дата рождения");
                        Console.WriteLine("7 - Организация");
                        Console.WriteLine("8 - Должность");
                        Console.WriteLine("9 - Заметка");


                        choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("\nВведите новое значение:");
                                Program.notes[id].FirstName = Console.ReadLine();

                                isChanged = true;
                                break;
                            case "2":
                                Console.WriteLine("\nВведите новое значение:");
                                Program.notes[id].LastName = Console.ReadLine();
                                isChanged = true;
                                break;
                            case "3":
                                Console.WriteLine("\nВведите новое значение:");
                                Program.notes[id].SecondName = Console.ReadLine();
                                isChanged = true;
                                break;
                            case "4":
                                Console.WriteLine("\nВведите новое значение:");
                                bool isLong = false;
                                long phone;
                                do
                                {
                                    string tempPhone = Console.ReadLine();
                                    isLong = Int64.TryParse(tempPhone, out phone);
                                    if (tempPhone == null || isLong == false)
                                    {
                                        Console.WriteLine("Введите номер корректно(Только цифры)");
                                    }
                                } while (!isLong);
                                Program.notes[id].Phone = phone;
                                isChanged = true;
                                break;
                            case "5":
                                Console.WriteLine("\nВведите новое значение:");
                                isChanged = true;
                                Program.notes[id].Country = Console.ReadLine();
                                break;
                            case "6":
                                Console.WriteLine("\nВведите новое значение:");
                                bool isDate = false;
                                DateTime birthDate = new DateTime();
                                string birthday = null;
                                do
                                {
                                    string tempDate = Console.ReadLine();
                                    bool isDateNull = String.IsNullOrWhiteSpace(tempDate);
                                    if (isDateNull)
                                    {
                                        isDate = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isDate = DateTime.TryParse(tempDate, out birthDate);
                                        Program.notes[id].Birthday = birthDate.ToString("dd.MM.yyyy");
                                        if (isDate == false)
                                        {
                                            Console.WriteLine("Введите дату корректно");
                                        }
                                    }
                                } while (!isDate);

                                isChanged = true;
                                break;
                            case "7":
                                Console.WriteLine("\nВведите новое значение:");
                                Program.notes[id].Organization = Console.ReadLine();
                                isChanged = true;
                                break;
                            case "8":
                                Console.WriteLine("\nВведите новое значение:");
                                Program.notes[id].Post = Console.ReadLine();
                                isChanged = true;
                                break;
                            case "9":
                                Console.WriteLine("\nВведите новое значение:");
                                Program.notes[id].Notes = Console.ReadLine();
                                isChanged = true;
                                break;

                            default:
                                isChanged = false;
                                Console.WriteLine("Введите одну из возможных цифр!");
                                break;

                        }

                    } while (isChanged != true);
                    Console.Clear();
                    Console.WriteLine("Запись успешно отредактирована! Нажмите на любую кнопку для продолжения...");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Такого id не существует. Попробуйте еще раз...");

                }
            }
            else
            {
                Console.WriteLine("Введите число...");
            }


        }

        public void ShowAllNotes()
        {
            Console.Clear();
            foreach (KeyValuePair<int, Note> item in Program.notes)
            {
                Console.WriteLine($"id - {item.Key}  |  Имя: {item.Value.FirstName}  |  Фамилия: {item.Value.LastName}  |  Телефон: {item.Value.Phone}");
            }
            Console.WriteLine("\nНажмите на любую кнопку для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }

        public override string ToString()
        {
            return $"Имя - {FirstName}\nФамилия - {LastName}\nОтчество - {SecondName}\nТелефон - {Phone}\nСтрана - {Country}\nДата рождения - " +
                $"{Birthday}\nОрганизация - {Organization}\nДолжность - {Post}\nПрочие заметки - {Notes}";
        }
    }

}
