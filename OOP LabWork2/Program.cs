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
            /*var Human = new Adult();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i + 1}-ая личность");
                Human = Adult.GetRandomAdultPerson();
                Console.WriteLine($"{Human.Info()}\n");
            }
            Console.ReadLine();*/

            var Human = new Child();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i + 1}-ое дитё");
                Human = Child.GetRandomChildPerson();
                Console.WriteLine($"{Human.Info()}\n");
            }
            Console.ReadLine();
        }
    }
}
