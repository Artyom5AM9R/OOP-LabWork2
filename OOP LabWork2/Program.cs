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

            //var Human = new Adult();

            for (int i = 0; i < 10; i++)
            {
                int random = Person.Randomize.Next(1, 2);

                if (random == 1)
                {
                    var Man = Adult.GetRandomAdultPerson();
                    ListOne.Add(Man);
                    ListOne.Add(Adult.GetSpouse(Man));
                }
                else if (random == 2)
                {
                    ListOne.Add(Child.GetRandomChildPerson());
                }
                else if (random == 3)
                {
                    ListOne.Add(Elderly.GetRandomElderlyPerson());
                }
                else
                {
                    ListOne.Add(Person.GetRandomPerson());
                }
            }

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
                else if (man.GetType() == typeof(Elderly))
                {
                    Console.WriteLine($"{((Elderly)man).Info}");
                }
                else
                {
                    Console.WriteLine($"{((Person)man).Info}\n");
                }
            }

            Console.WriteLine(ListOne.Count());

            //Human.View();

            Console.ReadLine();

            /*var Human = new Child();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i + 1}-ое дитё");
                Human = Child.GetRandomChildPerson();
                Console.WriteLine($"{Human.Info()}\n");
            }
            Console.ReadLine();*/
        }
    }
}
