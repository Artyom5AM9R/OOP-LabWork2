using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;

namespace OOP_LabWork2
{
    /// <summary>
    /// Класс, реализующий функционал библиотеки PersonLibrary
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод для вывода в консоль цветного текста
        /// </summary>
        /// <param name="text">Текст для вывода</param>
        /// <param name="color">Цвет текста</param>
        public static void ColorTextInConsole(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            while (true)
            {
                var listOne = new PersonList();
                Random randomize = new Random();

                ColorTextInConsole("Создание списка с записями о людях:", ConsoleColor.Blue);
                Console.ReadKey();

                for (int i = 0; i < 7; i++)
                {
                    int random = randomize.Next(1, 4);
                    PersonBase tmpPerson = new Adult();
                    
                    switch (random)
                    {
                        case 1:
                            tmpPerson = RandomPerson.GetRandomAdultPersonWithoutSpouse();
                            break;
                        case 2:
                            tmpPerson = RandomPerson.GetRandomAdultPersonWithSpouse();
                            break;
                        case 3:
                            tmpPerson = RandomPerson.GetRandomChildPerson();
                            break;
                    }

                    ColorTextInConsole($"{i + 1}-й человек:", ConsoleColor.Green);
                    Console.WriteLine(tmpPerson.Info);
                    listOne.Add(tmpPerson);
                }

                Console.ReadKey();
                Console.WriteLine($"Количество записей в списке - {listOne.Count()}\n");
                Console.ReadKey();

                try
                {
                    int indexForFind = 4;
                    var findResult = listOne.Find(indexForFind);
                    switch (findResult)
                    {
                        case Adult adult:
                            ColorTextInConsole($"\nТип записи о {indexForFind}-ом человеке в списке - " +
                                $"{adult.GetType()}", ConsoleColor.Blue);
                            Console.WriteLine($"\nИнформация о брачном партнере рассматриваемого человека:\n");
                            
                            if (adult.FamilyStatus == FamilyStatusType.Married)
                            {
                                Console.WriteLine(adult.Spouse.Info);
                                Console.WriteLine($"Разница в возрасте между супругами - " +
                                    $"{adult.AgeDifference()}");
                            }
                            else
                            {
                                throw new Exception("Указанный человек не состоит в браке.\n");
                            }
                            
                            break;
                        case Child child:
                            ColorTextInConsole($"\nТип записи о {indexForFind}-ом человеке в списке - " +
                                $"{child.GetType()}", ConsoleColor.Blue);
                            Console.WriteLine($"\nИнформация о наличии родителей у ребенка: " +
                                $"{child.CheckForParents()}\n");
                            break;
                    }
                }
                catch (Exception exception)
                {
                    ColorTextInConsole(exception.Message, ConsoleColor.Red);
                }

                ColorTextInConsole("\nДля выхода из программы нажмите клавишу Esc\n",
                        ConsoleColor.Blue);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
