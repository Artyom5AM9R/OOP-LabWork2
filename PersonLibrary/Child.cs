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
        /// Поле для описания матери ребёнка
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Поле для описания отца ребёнка
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Поле для описания названия детского сада/школы ребёнка
        /// </summary>
        private string _placeOfStudy;

        public Adult Mother { get; set; }

        public Adult Father { get; set; }

        public string PlaceOfStudy { get; private set; }

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

        public Child() { }

        public Child(string name, string surname, int age, GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

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
                   $"возраст - {Age}; пол - {Gender}\n" +
                   $"Мать - {mother}\n" +
                   $"Отец - {father}\n" +
                   $"{PlaceOfStudy}\n";
        }

        public static Child GetRandomChildPerson()
        {            
            var Father = new Adult();
            var Mother = new Adult();
            var pattern = Person.GetRandomPerson();
            var Kid = new Child(pattern.Name, pattern.Surname, pattern.Age, pattern.Gender);

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

                if (Kid.Gender == GenderType.Female)
                {
                    Kid.Surname = Father.Surname + "а";
                }
                else
                {
                    Kid.Surname = Father.Surname;
                }
            }

            Kid.Father = Father;

            if (Randomize.Next(0, 2) == 1)
            {
                while (true)
                {
                    if (string.IsNullOrEmpty(Father.Name))
                    {
                        Mother = Adult.GetRandomAdultPerson();

                        if (Kid.Gender == GenderType.Female)
                        {
                            Kid.Surname = Mother.Surname;
                            break;
                        }
                        else
                        {
                            Kid.Surname = Mother.Surname.Remove(Mother.Surname.Length - 1, 1);
                            break;
                        }
                    }
                    else
                    {
                        Mother = Adult.FindSpouse(Father.Surname, Father.Gender);
                        break;
                    }
                }
            }

            Kid.Mother = Mother;

            var kindergartensList = new List<string>()
            {
                "детский сад 'Солнышко'", "детский сад 'Родничок'", "детский сад 'Сказка'",
                "детский сад 'Антошка'", "детский сад 'Морозко'"
            };
            var schoolsList = new List<string>()
            {
                "Гимназия №1", "СОШ №5", "Лицей №2", "СОШ №3", "Лицей №1"
            };

            if (Kid.Age < 7)
            {
                Kid.PlaceOfStudy = $"Место обучения - " +
                    $"{kindergartensList[Person.Randomize.Next(0, kindergartensList.Count)]}";
            }
            else
            {
                Kid.PlaceOfStudy = $"Место обучения - " +
                    $"{schoolsList[Person.Randomize.Next(0, schoolsList.Count)]}";
            }

            return Kid;
        }
    }
}
