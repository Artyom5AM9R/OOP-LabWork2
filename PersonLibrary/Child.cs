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
    public class Child : Person
    {
        /// <summary>
        /// Свойство для хранения данных про мать
        /// </summary>
        public Adult Mother { get; private set; }

        /// <summary>
        /// Свойство для хранения данных про отца
        /// </summary>
        public Adult Father { get; set; }

        /// <summary>
        /// Свойство для хранения значения о месте учебы
        /// </summary>
        public string PlaceOfStudy { get; private set; }

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
                    if (value > 17)
                    {
                        value = GetRandomChildPerson().Age;
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
        /// Параметризованный конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="mother">Мать</param>
        /// <param name="father">Отец</param>
        /// <param name="place">Место учебы</param>
        public Child(string name, string surname, int age, GenderType gender,
            Adult mother, Adult father, string place)
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
        /// Метод для получения информации о человеке
        /// </summary>
        /// <returns>Значение типа string</returns>
        public new string Info()
        {
            string mother;
            string father;

            if (string.IsNullOrEmpty(Mother.Name))
            {
                mother = "нет";
            }
            else
            {
                mother = $"{Mother.Name} {Mother.Surname}";
            }

            if (string.IsNullOrEmpty(Father.Name))
            {
                father = "нет";
            }
            else
            {
                father = $"{Father.Name} {Father.Surname}";
            }

            return $"Имя и фамилия - {Name} {Surname}; " +
                   $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                   $"Мать - {mother}\n" +
                   $"Отец - {father}\n" +
                   $"Место обучения - {PlaceOfStudy}\n";
        }

        /// <summary>
        /// Метод для генерации записи о человеке со случайными характеристиками
        /// </summary>
        /// <returns></returns>
        public static Child GetRandomChildPerson()
        {            
            var Man = Person.GetRandomPerson();
            var Father = new Adult();
            string surname = Man.Surname;

            if (Randomize.Next(0, 2) == 1)
            {
                while (true)
                {
                    Father = Adult.GetRandomAdultPerson();
                    if (Father.Gender == GenderType.Male)
                    {
                        break;
                    }
                }

                if (Man.Gender == GenderType.Female)
                {
                    surname = Father.Surname + "а";
                }
                else
                {
                    surname = Father.Surname;
                }
            }

            var Mother = new Adult();

            if (Randomize.Next(0, 2) == 1)
            {
                if (string.IsNullOrEmpty(Father.Name))
                {
                    while (true)
                    {
                        Mother = Adult.GetRandomAdultPerson();

                        if (Mother.Gender == GenderType.Female)
                        {
                            break;
                        }
                    }

                    if (Man.Gender == GenderType.Female)
                    {
                        surname = Mother.Surname;
                    }
                    else
                    {
                        surname = Mother.Surname.Remove(Mother.Surname.Length - 1, 1);
                    }
                }
                else
                {
                    Mother = Adult.FindSpouse(Father);
                }
            }

            var kindergartensList = new List<string>()
            {
                "детский сад 'Солнышко'", "детский сад 'Родничок'", "детский сад 'Сказка'",
                "детский сад 'Антошка'", "детский сад 'Морозко'"
            };
            var schoolsList = new List<string>()
            {
                "Гимназия №1", "СОШ №5", "Лицей №2", "СОШ №3", "Лицей №1"
            };

            string placeOfStudy;
            Console.WriteLine(Man.Age + "\n");
            if (Man.Age < 6)
            {
                placeOfStudy = kindergartensList[Person.Randomize.Next(0, kindergartensList.Count)];
            }
            else
            {
                placeOfStudy = schoolsList[Person.Randomize.Next(0, schoolsList.Count)];
            }

            return new Child(Man.Name, surname, Man.Age, Man.Gender, Mother, Father, placeOfStudy);
        }
    }
}
