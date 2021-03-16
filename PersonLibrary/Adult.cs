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
        /// Поле для описание серии паспорта человека
        /// </summary>
        private int _passpportSeries;

        /// <summary>
        /// Поле для описания номера паспорта человека
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Поле для описания семейного положения человека
        /// </summary>
        private FamilyStatusType _familyStatus;

        /// <summary>
        /// Поле для описания места работы человека
        /// </summary>
        private string _placeOfWork;

        /// <summary>
        /// Свойство для обращения к полю _passpportSeries
        /// </summary>
        public int PassportSeries { get; private set; }

        /// <summary>
        /// Свойство для обращения к полю _passpportNumber
        /// </summary>
        public int PassportNumber { get; private set; }

        /// <summary>
        /// Свойство для обращения к полю _familyStatus
        /// </summary>
        public FamilyStatusType FamilyStatus { get; private set; }

        /// <summary>
        /// Свойство для обращения к полю _placeOfWork
        /// </summary>
        public string PlaceOfWork { get; private set; }

        public int AdultAge
        {
            get
            {
                return _age;
            }
            private set
            {
                while (true)
                {
                    if (value < 18)
                    {
                        value = Person.Randomize.Next(18, MaxAge + 1);
                    }
                    else
                    {
                        _age = value;
                        break;
                    }
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
        /// <param name="gender">Половая принадлежность</param>
        /// <param name="series">Серия паспорта</param>
        /// <param name="number">Номер паспорта</param>
        /// <param name="status">Семейное положение</param>
        /// <param name="placeOfWork">Место работы</param>
        public Adult(string name, string surname, int age, GenderType gender, 
            int series, int number, FamilyStatusType status, string placeOfWork)
        {
            Name = name;
            Surname = surname;
            AdultAge = age;
            Gender = gender;
            PassportSeries = series;
            PassportNumber = number;
            FamilyStatus = status;
            PlaceOfWork = placeOfWork;
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
            if (PlaceOfWork == null && Gender == GenderType.Male)
            {
                work = "Безработный";
            }
            else if (PlaceOfWork == null && Gender == GenderType.Female)
            {
                work = "Безработная";
            }
            else if (Age > 60 && Gender == GenderType.Male)
            {
                work = "Пенсионер";
            }
            else if (Age > 55 && Gender == GenderType.Female)
            {
                work = "Пенсионер";
            }
            else
            {
                work = $"Место работы - {PlaceOfWork}";
            }

            if (FamilyStatus == FamilyStatusType.Married)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {AdultAge}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {status[1]} {FindSpouse(Surname, Gender)}\n" +
                       $"{work}";
            }
            else if (FamilyStatus == FamilyStatusType.Unmarried && Gender == GenderType.Male)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {AdultAge}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {status[2]}\n" +
                       $"{work}";
            }
            else
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {AdultAge}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {status[3]}\n" +
                       $"{work}";
            }
        }

        /// <summary>
        /// Метод для генерирования данных о случайном взрослом человеке
        /// </summary>
        /// <returns></returns>
        public static Adult GetRandomAdultPerson()
        {
            int series;
            int number;
            var businessOrganisation = new List<string>()
            {
                "ООО 'Здоровье'", "АО 'Медстрахование'", "Клининговая компания 'Чистый дом'",
                    "Интернет-провайдер 'Дом.ru'", "Автошкола 'УдачаПлюс'", "СТО 'РесурсАвто'",
                    "ООО 'Ситилинк'", "ТПУ", "ТУСУР", null
            };

            Person Human = GetRandomPerson();

            while (true)
            {
                series = Randomize.Next(1000, 10000);
                number = Randomize.Next(100000, 1000000);
                var data = series.ToString() + number.ToString();

                foreach (string node in _passportList)
                {
                    if (_passportList.Contains(data))
                    {
                        data = "";
                        break;
                    }
                    else
                    {
                        _passportList.Add(data);
                    }
                }

                if (data != "")
                {
                    break;
                }
            }

            FamilyStatusType status = (FamilyStatusType)Randomize.Next(0,
                Enum.GetNames(typeof(FamilyStatusType)).Length);

            string work = businessOrganisation[Randomize.Next(0, businessOrganisation.Count)];

            return new Adult(Human.Name, Human.Surname, Human.Age, Human.Gender, series, number,
                status, work);
        }

        public string FindSpouse(string surname, GenderType gender)
        {
            Adult Human = new Adult();

            while (true)
            {
                Human = GetRandomAdultPerson();

                if (gender == GenderType.Female && Human.Gender != gender)
                {
                    Human.Surname = surname.Remove(surname.Length - 1, 1);
                    break;
                }
                else if (gender == GenderType.Male && Human.Gender != gender)
                {
                    Human.Surname = surname + "а";
                    break;
                }
            }

            return $"{Human.Name} {Human.Surname}";
        }
    }
}
