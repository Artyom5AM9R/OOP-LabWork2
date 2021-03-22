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
        /// Метод для вывода в консоль текста в синем цвете
        /// </summary>
        /// <param name="text">Текст для вывода в консоль</param>
        public static void BlueTextOutput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var ListOne = new PersonList();

            int start = int.Parse(DateTime.Now.ToString("ss"));

            for (int i = 0; i < 5000; i++)
            {
                int random = Person.Randomize.Next(1, 4);

                if (random == 1)
                {
                    ListOne.Add(Adult.GetRandomAdultPerson());
                }
                else if (random == 2)
                {
                    ListOne.Add(Child.GetRandomChildPerson());
                }
                else
                {
                    ListOne.Add(Elderly.GetRandomElderlyPerson());
                }
            }

            int finish = int.Parse(DateTime.Now.ToString("ss"));

            foreach (var man in ListOne)
            {
                if (man.GetType() == typeof(Adult))
                {
                    Console.WriteLine(((Adult)man).Info());
                }
                else if (man.GetType() == typeof(Child))
                {
                    Console.WriteLine(((Child)man).Info());
                }
                else
                {
                    Console.WriteLine($"{((Elderly)man).Info}");
                }
            }

            Console.WriteLine("Количество записей - " + ListOne.Count());

            Console.WriteLine($"Затраченное время на создание - {finish - start} сек");

            Console.ReadLine();
        }
    }
}
