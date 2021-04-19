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
                var ListOne = new PersonList();
                int start = int.Parse(DateTime.Now.ToString("ss"));
                Random randomize = new Random();

                ColorTextInConsole("Создание списка с записями о людях:", ConsoleColor.Blue);
                Console.ReadKey();

                for (int i = 0; i < 7; i++)
                {
                    int random = randomize.Next(1, 4);

                    switch (random)
                    {
                        case 1:
                            ListOne.Add(RandomPerson.GetRandomAdultPersonWithoutSpouse());
                            break;
                        case 2:
                            ListOne.Add(RandomPerson.GetRandomAdultPersonWithSpouse());
                            break;
                        case 3:
                            ListOne.Add(RandomPerson.GetRandomChildPerson());
                            break;
                    }
                }

                int finish = int.Parse(DateTime.Now.ToString("ss"));

                int counter = 0;

                foreach (var man in ListOne)
                {
                    counter++;
                    switch (man)
                    {
                        case Adult:
                            ColorTextInConsole($"{counter}-й человек:", ConsoleColor.Green);
                            Console.WriteLine(((Adult)man).Info());
                            break;
                        case Child:
                            ColorTextInConsole($"{counter}-й человек:", ConsoleColor.Green);
                            Console.WriteLine(((Child)man).Info());
                            break;
                    }
                }

                Console.ReadKey();
                Console.WriteLine($"Количество записей - {ListOne.Count()}\n");
                Console.WriteLine($"Время, затраченное на создание списка - {finish - start} сек\n");
                Console.ReadKey();

                try
                {
                    counter = 0;

                    foreach (var man in ListOne)
                    {
                        counter++;

                        if (counter == 4 && man is Adult)
                        {
                            ColorTextInConsole($"\nТип записи о {counter}-ом человеке в списке - " +
                                $"{man.GetType()}", ConsoleColor.Blue);
                            ColorTextInConsole($"\nИнформация о брачном партнере рассматриваемого человека:\n",
                                ConsoleColor.Blue);
                            Console.WriteLine(Adult.GetInfoAboutSpouse((Adult)man).Info());
                        }
                        else if (counter == 4 && man is Child)
                        {
                            ColorTextInConsole($"\nТип записи о {counter}-ом человеке в списке - " +
                                $"{man.GetType()}", ConsoleColor.Blue);
                            ColorTextInConsole($"\nИнформация о наличии родителей у ребенка: " +
                                $"{Child.CheckForParents((Child)man)}\n", ConsoleColor.Blue);
                        }
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
