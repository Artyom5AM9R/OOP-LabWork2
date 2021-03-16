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

        /// <summary>
        /// Поле хранения паспортных данных людей
        /// </summary>
        private static List<string> _passportList = new List<string>();

        public Adult() { }

        public Adult(string name, string surname, int age, GenderType gender, 
            int series, int number, FamilyStatusType status, string placeOfWork)
        {
            Name = name;
            Surname = surname;
            Age = age;
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
            if (FamilyStatus == FamilyStatusType.Married)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {FamilyStatus} с {FindSpouse(Surname, Gender)}\n" +
                       $"Место работы - {PlaceOfWork}";
            }
            /*else if (FamilyStatus == FamilyStatusType.Unmarried && Gender == GenderType.Male)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {FamilyStatus}" +
                       $"Место работы - {PlaceOfWork}";
            }*/
            else
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {FamilyStatus}\n" +
                       $"Место работы - {PlaceOfWork}";
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
                    "ООО 'Ситилинк'", "ТПУ", "ТУСУР"
            };

            Person Human = new Person();

            Human = GetRandomPerson();

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

            //Console.WriteLine($"\n{Human.Name} {Human.Surname} {Human.Age} {Human.Gender} {series} {number} {status}\n\n");
            return new Adult(Human.Name, Human.Surname, Human.Age, Human.Gender, series, number, status, work);
        }

        public string FindSpouse(string surname, GenderType gender)
        {
            Adult Persona = new Adult();

            while (true)
            {
                Persona = GetRandomAdultPerson();

                if (gender == GenderType.Female && Persona.Gender != gender)
                {
                    Persona.Surname = surname.Remove(surname.Length - 1, 1);
                    break;
                }
                else if (gender == GenderType.Male && Persona.Gender != gender)
                {
                    Persona.Surname = surname + "а";
                    break;
                }
            }

            return $"{Persona.Name} {Persona.Surname}";
        }
    }
}
