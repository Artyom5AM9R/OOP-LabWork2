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
    public class Adult : Person
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
        public Person Spouse { get; private set; }

        /// <summary>
        /// Свойство для хранения информации о месте работы
        /// </summary>
        public string Job { get; private set; }

        public override int Age
        {
            get
            {
                return _age;
            }
            protected private set
            {
                if (value >= 18 && value <= 60)
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Поле хранения паспортных данных людей
        /// </summary>
        private static List<string> _passportList = new List<string>();

        /// <summary>
        /// Пустой конструктор класса
        /// </summary>
        public Adult() { }

        /// <summary>
        /// Параметризированный конструктор класса
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
            int series, int number, FamilyStatusType status, Person spouse, string job)
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
        /// Параметризированный конструктор класса
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
            Dictionary<int, string> status = new Dictionary<int, string>(3);
            status.Add(1, "в браке c");
            status.Add(2, "холост");
            status.Add(3, "не замужем");

            string work;
            if (!Job.Contains("Безработн"))
            {
                work = $"Место работы - {Job}";
            }
            else
            {
                work = Job;
            }

            if (FamilyStatus == FamilyStatusType.Married)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {status[1]} {Spouse.Name} " +
                       $"{Spouse.Surname}\n" +
                       $"{work}\n";
            }
            else if (FamilyStatus == FamilyStatusType.Unmarried && Gender == GenderType.Male)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {status[2]}\n" +
                       $"{work}\n";
            }
            else
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {status[3]}\n" +
                       $"{work}\n";
            }
        }

        /// <summary>
        /// Метод для генерирования данных о случайном взрослом человеке без жены/мужа
        /// </summary>
        /// <returns>Значение типа Adult</returns>
        public static Adult GetPerson()
        {
            int series;
            int number;

            while (true)
            {
                series = Randomize.Next(1000, 10000);
                number = Randomize.Next(100000, 1000000);
                var data = series.ToString() + number.ToString();

                if (!_passportList.Contains(data))
                {
                    _passportList.Add(data);
                    break;
                }
            }    

            var businessOrganisation = new List<string>()
            {
                "ООО 'Здоровье'", "АО 'Медстрахование'", "Клининговая компания 'Чистый дом'",
                    "Интернет-провайдер 'Дом.ru'", "Автошкола 'УдачаПлюс'", "СТО 'РесурсАвто'",
                    "ООО 'Ситилинк'", "ТПУ", "ТУСУР", null
            };
            string job = businessOrganisation[Randomize.Next(0, businessOrganisation.Count)];
            
            Person Man;
            
            while (true)
            {
                Man = GetRandomPerson();
                var ManForCheck = new Adult();
                ManForCheck.Age = Man.Age;

                if (ManForCheck.Age > 0)
                {
                    break;
                }
            }

            if (Man.Gender == GenderType.Male && job == null)
            {
                job = "Безработный";
            }
            else if (Man.Gender == GenderType.Female && job == null)
            {
                job = "Безработная";
            }

            return new Adult(Man.Name, Man.Surname, Man.Age, Man.Gender, series,
                number, FamilyStatusType.Unmarried, job);
        }

        /// <summary>
        /// Метод для поиска муха/жены для человека
        /// </summary>
        /// <param name="Man">Человек, для которого нудо искать мужа/жену</param>
        /// <returns>Значение типа Adult</returns>
        public static Adult FindSpouse(Adult Man)
        {
            Adult Couple;

            while (true)
            {
                Couple = GetPerson();

                if (Man.Gender == GenderType.Female && Couple.Gender != Man.Gender &&
                    (Math.Abs(Couple.Age - Man.Age) <= 3))
                {
                    Couple.Surname = Man.Surname.Remove(Man.Surname.Length - 1, 1);
                    break;
                }
                else if (Man.Gender == GenderType.Male && Couple.Gender != Man.Gender &&
                    (Math.Abs(Couple.Age - Man.Age) <= 3))
                {
                    Couple.Surname = Man.Surname + "а";
                    break;
                }
            }

            var NewMan = new Adult(Man.Name, Man.Surname, Man.Age, Man.Gender, Man.PassportSeries,
                Man.PassportNumber, FamilyStatusType.Married, Couple, Man.Job);

            Couple.FamilyStatus = FamilyStatusType.Married;
            Couple.Spouse = NewMan;

            return Couple;
        }

        /// <summary>
        /// Метод для генерирования данных о случайном взрослом человеке c поиском жены/мужа
        /// </summary>
        /// <returns>Значение типа Adult</returns>
        public static Adult GetRandomAdultPerson()
        {
            Adult FirstMan = GetPerson();
            Adult SecondMan;

            FirstMan.FamilyStatus =
                (FamilyStatusType)Randomize.Next(0, Enum.GetNames(typeof(FamilyStatusType)).Length);

            if (FirstMan.FamilyStatus ==FamilyStatusType.Married)
            {
                SecondMan = FindSpouse(FirstMan);
                FirstMan.Spouse = SecondMan;
            }
            else
            {
                FirstMan.Spouse = new Adult(FirstMan.Name, FirstMan.Surname, FirstMan.Age, FirstMan.Gender,
                    FirstMan.PassportSeries, FirstMan.PassportNumber, FirstMan.FamilyStatus, FirstMan.Job);
            }

            return FirstMan;
        }

        /// <summary>
        /// Метод для получения информации о муже/жене человека
        /// </summary>
        /// <param name="Man">Человек, информацию о муже/жене которого нужно искать</param>
        /// <returns>Значение типа Person</returns>
        public static Person GetSpouse(Adult Man)
        {
            if (Man.FamilyStatus == FamilyStatusType.Married)
            {
                return Man.Spouse;
            }
            else
            {
                return new Person();
            }
        }
    }
}
