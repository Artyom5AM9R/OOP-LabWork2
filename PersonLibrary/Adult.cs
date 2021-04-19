using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания взрослых людей
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Свойство для хранения информации о серии паспорта
        /// </summary>
        public int PassportSeries { get; private set; }

        /// <summary>
        /// Свойство для хранения информации о номере паспорта
        /// </summary>
        public int PassportNumber { get; private set; }

        /// <summary>
        /// Свойство для хранения информации о семейном статусе
        /// </summary>
        public FamilyStatusType FamilyStatus { get; private set; }

        /// <summary>
        /// Свойство для хранения данных о брачном партнере
        /// </summary>
        public Adult Spouse { get; private set; }

        /// <summary>
        /// Свойство для хранения информации о месте работы
        /// </summary>
        public string Job{ get; private set; }

        /// <summary>
        /// Наименьший возможный возраст взрослого человека
        /// </summary>
        public const int MinAdultAge = 18;

        /// <summary>
        /// Свойство для хранения информации о возрасте человека
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            protected private set
            {
                if (value >= MinAdultAge && value <= PersonBase.MaxAge)
                {
                    _age = value;
                }
                else
                {
                    throw new Exception("Был указан неверный возраст.");
                }
            }
        }

        /// <summary>
        /// Пустой конструктор класса
        /// </summary>
        public Adult() { }

        /// <summary>
        /// Параметризированный конструктор класса для человека без мужа/жены
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="series">Серия паспорта</param>
        /// <param name="number">Номер паспорта</param>
        /// <param name="status">Семеной положение</param>
        /// <param name="spouse">Муж/жена</param>
        /// <param name="job">Место работы</param>
        public Adult(string name, string surname, int age, GenderType gender, 
            int series, int number, FamilyStatusType status, Adult spouse, string job)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            PassportSeries = series;
            PassportNumber = number;
            FamilyStatus = status;
            Spouse = spouse;
            Job = job;
        }

        /// <summary>
        /// Параметризированный конструктор класса для человека с мужем/женой
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Половая принадлежность</param>
        /// <param name="series">Серия паспорта</param>
        /// <param name="number">Номер паспорта</param>
        /// <param name="status">Семейное положение</param>
        /// <param name="job">Место работы</param>
        public Adult(string name, string surname, int age, GenderType gender,
            int series, int number, FamilyStatusType status, string job)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            PassportSeries = series;
            PassportNumber = number;
            FamilyStatus = status;
            Job = job;
        }
        
        /// <summary>
        /// Метод для формирования строки с информацией о человеке
        /// </summary>
        public new string Info()
        {
            string work;

            if (Job.Contains("Безработн") || Job.Contains("Пенсионер"))
            {
                work = Job;
            }
            else
            {
                work = $"Место работы - {Job}";
            }

            if (FamilyStatus == FamilyStatusType.Married)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {PersonBase.TranslateGenderIntoRussian(Gender)}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"{PrintFamilyStatusIntoRussian()}" +
                       $"{work}\n";
            }
            else if (FamilyStatus == FamilyStatusType.Unmarried && Gender == GenderType.Male)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {PersonBase.TranslateGenderIntoRussian(Gender)}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"{PrintFamilyStatusIntoRussian()}" +
                       $"{work}\n";
            }
            else
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {PersonBase.TranslateGenderIntoRussian(Gender)}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"{PrintFamilyStatusIntoRussian()}" +
                       $"{work}\n";
            }
        }

        /// <summary>
        /// Метод для поиска мужа/жены для человека
        /// </summary>
        /// <param name="man">Человек, для которого нудо искать мужа/жену</param>
        /// <returns>Значение типа Adult</returns>
        public static Adult FindSpouse(Adult man)
        {
            Adult couple;

            while (true)
            {
                couple = RandomPerson.GetRandomAdultPersonWithoutSpouse();

                if (man.Gender == GenderType.Female && couple.Gender != man.Gender &&
                    (Math.Abs(couple.Age - man.Age) <= 3))
                {
                    couple.Surname = man.Surname.Remove(man.Surname.Length - 1, 1);
                    break;
                }
                else if (man.Gender == GenderType.Male && couple.Gender != man.Gender &&
                    (Math.Abs(couple.Age - man.Age) <= 3))
                {
                    couple.Surname = man.Surname + "а";
                    break;
                }
            }
            
            man.FamilyStatus = FamilyStatusType.Married;
            man.Spouse = couple;

            couple.FamilyStatus = FamilyStatusType.Married;
            couple.Spouse = man;

            return couple;
        }

        /// <summary>
        /// Метод для вывода на экран семейного статуса человека на русском языке
        /// </summary>
        /// <returns></returns>
        private string PrintFamilyStatusIntoRussian()
        {
            Dictionary<int, string> status = new Dictionary<int, string>(3);
            status.Add(1, "в браке c");
            status.Add(2, "холост");
            status.Add(3, "не замужем");

            if (FamilyStatus == FamilyStatusType.Married)
            {
                return $"Семейное положение - {status[1]} {Spouse.Name} " +
                       $"{Spouse.Surname}\n";
            }
            else if (FamilyStatus == FamilyStatusType.Unmarried && Gender == GenderType.Male)
            {
                return $"Семейное положение - {status[2]}\n";
            }
            else
            {
                return $"Семейное положение - {status[3]}\n";
            }
        }

        /// <summary>
        /// Метод для получения информации о муже/жене человека
        /// </summary>
        /// <param name="man">Человек, информацию о муже/жене которого нужно искать</param>
        /// <returns>Значение типа Person</returns>
        public static Adult GetInfoAboutSpouse(Adult man)
        {
            if (man.FamilyStatus == FamilyStatusType.Married)
            {
                return man.Spouse;
            }
            else
            {
                throw new Exception("Указанный человек не состоит в браке.\n");
            }
        }
    }
}