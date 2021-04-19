using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания человека
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия человека
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Минимальный возраст человека
        /// </summary>
        public const int MinAge = 1;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        public const int MaxAge = 117;

        /// <summary>
        /// Свойство для обращения к полю _name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = NameOrSurnameValidation(value);
            }
        }

        /// <summary>
        /// Свойство для обращения к полю _surname
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = NameOrSurnameValidation(value);
            }
        }

        /// <summary>
        /// Свойство для обращения к полю _age
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= MinAge && value <= MaxAge)
                {
                    _age = value;
                }

                if (value < MinAge)
                {
                    throw new Exception($"Возраст не может быть меньше {MinAge}!");
                }
                else if (value > MaxAge)
                {
                    throw new Exception($"Возраст не может быть больше {MaxAge}!");
                }
            }
        }

        /// <summary>
        /// Свойство для обращения к полю, описывающему пол человека
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Пуской конструктор для класса Person
        /// </summary>
        public PersonBase() { }

        /// <summary>
        /// Конструктор с параметрами для класса Person
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public PersonBase(string name, string surname, int age, GenderType gender)
        {
            Name = name;
            Surname = surname;

            CheckOneLanguageInPerson();

            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Свойство для получении информации о человеке
        /// </summary>
        /// <returns>Значение формата string</returns>
        public string Info => $"Имя и фамилия - {Name} {Surname}; " +
                              $"возраст - {Age}; пол - {TranslateGenderIntoRussian(Gender)}";

        /// <summary>
        /// Метод для проверки наличия одного языка в значениях имени и фамилии
        /// </summary>
        public void CheckOneLanguageInPerson()
        {
            Regex RegexRussian = new Regex(@"[а-яё]");
            Regex RegexEnglish = new Regex(@"[a-z]");

            if (RegexRussian.IsMatch(Name) && RegexEnglish.IsMatch(Surname) ||
                RegexEnglish.IsMatch(Name) && RegexRussian.IsMatch(Surname))
            {
                throw new Exception("Не допускается ввод имени и фамилии на разных языках.");
            }
        }

        /// <summary>
        /// Метод для проверки корректности имени или фамилии человека
        /// </summary>
        /// <param name="nameForCheck">Имя или фамилия, которые подлежат проверке</param>
        /// <returns>Значение типа string</returns>
        public string NameOrSurnameValidation(string nameForCheck)
        {
            string name = null;

            nameForCheck = nameForCheck.ToLower();
            var patternList = new List<string>()
            {
                @"^[а-яё]{2,}$",
                @"^[a-z]{2,}$",
                @"^[а-яё]{2,}-[а-яё]{2,}$",
                @"^[a-z]{2,}-[a-z]{2,}$",
            };

            foreach (string pattern in patternList)
            {
                Regex Regex = new Regex(pattern);
                if (Regex.IsMatch(nameForCheck))
                {
                    name = nameForCheck;
                    break;
                }
            }

            if (name != null && name.Contains("-") && name.Length < 25)
            {
                name = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf("-")) +
                    name.Substring(name.IndexOf("-") + 1, 1).ToUpper() +
                    name.Substring(name.IndexOf("-") + 2);
            }
            else if (name != null && !name.Contains("-") && name.Length < 13)
            {
                name = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);
            }
            else
            {
                throw new Exception("Введено неверное значение.");

            }

            return name;
        }

        /// <summary>
        /// Метод для отображения пола человека на русском языке
        /// </summary>
        /// <param name="gender">Значение пола человека</param>
        /// <returns>Значение типа string</returns>
        public string TranslateGenderIntoRussian(GenderType gender)
        {
            switch (gender)
            {
                case GenderType.Male:
                    return "мужской";
                default:
                    return "женский";
            }
        }
    }
}