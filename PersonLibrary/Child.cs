using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания детей
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Свойство для хранения данных про мать
        /// </summary>
        public Adult Mother { get; private set; }

        /// <summary>
        /// Свойство для хранения данных про отца
        /// </summary>
        public Adult Father { get; private set; }

        /// <summary>
        /// Свойство для хранения значения о месте учебы
        /// </summary>
        public string PlaceOfStudy { get; private set; }

        /// <summary>
        /// Свойство для хранения информации о том, является ли ребенок сиротой
        /// </summary>
        public string PresenseOfParents { get; private set; }

        /// <summary>
        /// Наибольший возможный возраст молодого человека
        /// </summary>
        public const int MaxChildAge = 17;

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
                if (value <= MaxChildAge)
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
        /// Параметризованный конструктор класса Child при наличии хотя бы 
        /// одного из родителей
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="mother">Мать</param>
        /// <param name="father">Отец</param>
        /// <param name="place">Место учебы</param>
        public Child(string name, string surname, int age, GenderType gender,
            Adult mother, Adult father, string place) : base(name, surname, age, gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            Mother = mother;
            Father = father;
            PlaceOfStudy = place;
        }

        /// <summary>
        /// Параметризованный конструктор класса Child при отсутствии родителей у ребенка
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="presenseOfParents">Признак отсутствия родителей</param>
        /// <param name="place">Место обучения</param>
        public Child(string name, string surname, int age, GenderType gender,
            string presenseOfParents, string place) : base(name, surname, age, gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            PresenseOfParents = presenseOfParents;
            PlaceOfStudy = place;
        }

        /// <summary>
        /// Метод для получения информации о человеке
        /// </summary>
        /// <returns>Значение типа string</returns>
        public override string Info
        {
//TODO: RSDN +++
            get
            {
                if (!string.IsNullOrEmpty(PresenseOfParents))
                {
                    return $"Имя и фамилия - {Name} {Surname}; " +
                           $"возраст - {Age}; пол - {TranslateGenderIntoRussian(Gender)}\n" +
                           $"{PresenseOfParents}\n" +
                           $"Место обучения - {PlaceOfStudy}\n";
                }

                string mother;

                if (string.IsNullOrEmpty(Mother.Name))
                {
                    mother = "нет";
                }
                else
                {
                    mother = $"{Mother.Name} {Mother.Surname}";
                }

                string father;

                if (string.IsNullOrEmpty(Father.Name))
                {
                    father = "нет";
                }
                else
                {
                    father = $"{Father.Name} {Father.Surname}";
                }

                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {TranslateGenderIntoRussian(Gender)}\n" +
                       $"Мать - {mother}\n" +
                       $"Отец - {father}\n" +
                       $"Место обучения - {PlaceOfStudy}\n";
            }
        }

        /// <summary>
        /// Метод для проверки наличия родителей у ребенка
        /// </summary>
        /// <param name="kind">Ребенок, информацию о наличии родителей которого
        /// нужно проверить</param>
        /// <returns>Значение типа string</returns>
        public static string CheckForParents(Child kind)
        {
            if (!string.IsNullOrEmpty(kind.PresenseOfParents))
            {
                return "нет обоих родителей.\n";
            }
            else
            {
                if (string.IsNullOrEmpty(kind.Mother.Name))
                {
                    return "нет матери.\n";
                }
                else if (string.IsNullOrEmpty(kind.Father.Name))
                {
                    return "нет отца.\n";
                }
                else
                {
                    return "растет в полной семье.\n";
                }
            }
        }
    }
}