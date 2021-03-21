using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания пожилых людей
    /// </summary>
    public class Elderly : Person
    {
        /// <summary>
        /// Минимальный размер пенсии
        /// </summary>
        const int MinPensionAmount = 10000;

        /// <summary>
        /// Максимальный размер пенсии
        /// </summary>
        const int MaxPensionAmount = 22000;

        /// <summary>
        /// Свойство для хранения величины размера пенсии
        /// </summary>
        public static int PensionAmount { get; private set; }

        /// <summary>
        /// Свойство для хранения года выхода человека на пенсию
        /// </summary>
        public static int RetirementYear { get; private set; }

        /// <summary>
        /// Свойство для хранения возраста человека
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            protected private set
            {
                while (true)
                {
                    
                    if ((value > 60 && Gender == GenderType.Male) ||
                        (value > 55 && Gender == GenderType.Female))
                    {
                        _age = value;
                        break;
                    }
                    else
                    {
                        value = GetRandomElderlyPerson().Age;
                    }
                }
            }
        }

        /// <summary>
        /// Параметризированный конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="pensionAmount">Размер пенсии</param>
        /// <param name="retirementYear">Год выхода на пенсию</param>
        public Elderly(string name, string surname, int age, GenderType gender,
            int pensionAmount, int retirementYear)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            PensionAmount = pensionAmount;
            RetirementYear = retirementYear;
        }

        /// <summary>
        /// Свойство для получения информации о человеке
        /// </summary>
        public new string Info => $"Имя и фамилия - {Name} {Surname}; " +
                                  $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                                  $"Год выхода на пенсию - {RetirementYear}\n" +
                                  $"Размер пенсии - {PensionAmount} рублей\n";

        /// <summary>
        /// Метод для генерации записи о человека со случайными характеристиками
        /// </summary>
        /// <returns>Значение типа Elderly</returns>
        public static Elderly GetRandomElderlyPerson()
        {
            var Man = GetRandomPerson();
            PensionAmount = Randomize.Next(MinPensionAmount, MaxPensionAmount + 1);

            if (Man.Gender == GenderType.Male)
            {
                RetirementYear = int.Parse(DateTime.Now.ToString("yyyy")) - Man.Age + 61;
            }
            else
            {
                RetirementYear = int.Parse(DateTime.Now.ToString("yyyy")) - Man.Age + 56;
            }

            return new Elderly(Man.Name, Man.Surname, Man.Age, Man.Gender, PensionAmount, RetirementYear);
        }
    }
}
