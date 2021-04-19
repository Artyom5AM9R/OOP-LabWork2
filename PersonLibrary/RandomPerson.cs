using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для генерации случайных объектов класса Person 
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Поле для хранения паспортных данных людей
        /// </summary>
        private static List<string> _passportList = new List<string>();

        /// <summary>
        /// Поле с возможными вариантами мужских имен
        /// </summary>
        private static List<string> _maleNames = new List<string>()
        {
            "Артём", "Сергей", "Алексей", "Александр", "Павел",
                "Роман", "Тимур", "Пётр", "Дмитрий", "Геннадий"
        };

        /// <summary>
        /// Поле с возможными вариантами женских имен
        /// </summary>
        private static List<string> _femaleNames = new List<string>()
        {
            "Анна", "Виктория", "Елизавета", "Полина", "Валентина",
                "Дарья", "Екатерина", "Лилия", "Карина", "Вероника"
        };

        /// <summary>
        /// Поле с вожможными вариантами мужских фамилий
        /// </summary>
        private static List<string> _maleSurnames = new List<string>()
        {
            "Андропов", "Кротов", "Поляков", "Иванов", "Харламов",
                "Гаврилов", "Астахов", "Жданов", "Емельянов", "Виноградов"
        };

        /// <summary>
        /// Поле с возможными вариантами жунских фамилий
        /// </summary>
        private static List<string> _femaleSurnames = new List<string>()
        {
            "Гагарина", "Агапова", "Воронова", "Дубровина", "Борисова",
                "Высоцкая", "Глебова", "Журавлёва", "Громова", "Казакова"
        };

        /// <summary>
        /// Метод для возрата случайных значений
        /// </summary>
        private static Random Randomize = new Random();

        /// <summary>
        /// Метод для генерирования данных о случайном взрослом человеке без жены/мужа
        /// </summary>
        /// <returns>Значение формата Adult</returns>
        public static Adult GetRandomAdultPersonWithoutSpouse()
        {
            GenderType gender = (GenderType)Randomize.Next(0,
                Enum.GetNames(typeof(GenderType)).Length);
            string name;
            string surname;

            switch (gender)
            {
                case GenderType.Male:
                    name = _maleNames[Randomize.Next(_maleNames.Count)];
                    surname = _maleSurnames[Randomize.Next(_maleSurnames.Count)];
                    break;
                default:
                    name = _femaleNames[Randomize.Next(_femaleNames.Count)];
                    surname = _femaleSurnames[Randomize.Next(_femaleSurnames.Count)];
                    break;
            }

            int age = Randomize.Next(Adult.MinAdultAge, PersonBase.MaxAge);
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
            string job;

            if ((gender == GenderType.Male && age >= 65) ||
                (gender == GenderType.Female && age >= 60))
            {
                job = "Пенсионер";
            }
            else
            {
                job = businessOrganisation[Randomize.Next(0, businessOrganisation.Count)];
            }

            if (gender == GenderType.Male && job == null)
            {
                job = "Безработный";
            }
            else if (gender == GenderType.Female && job == null)
            {
                job = "Безработная";
            }

            return new Adult(name, surname, age, gender, series, number,
                FamilyStatusType.Unmarried, job);
        }

        /// <summary>
        /// Метод для генерирования данных о случайном взрослом человеке c поиском жены/мужа
        /// </summary>
        /// <returns>Значение типа Adult</returns>
        public static Adult GetRandomAdultPersonWithSpouse()
        {
            Adult FirstMan = GetRandomAdultPersonWithoutSpouse();
            Adult SecondMan = Adult.FindSpouse(FirstMan);

            return FirstMan;
        }

        /// <summary>
        /// Метод для генерации записи о взрослом человеке со случайными характеристиками
        /// </summary>
        /// <returns>Значение типа Adult</returns>
        public static Adult GetRandomAdultPerson()
        {
            int random = Randomize.Next(0, 3);

            if (random == 0)
            {
                return GetRandomAdultPersonWithSpouse();
            }
            else
            {
                return GetRandomAdultPersonWithSpouse();
            }
        }

        /// <summary>
        /// Метод для генерации записи о молодом человеке со случайными характеристиками
        /// </summary>
        /// <returns>Значение типа Child</returns>
        public static Child GetRandomChildPerson()
        {
            GenderType gender = (GenderType)Randomize.Next(0,
                Enum.GetNames(typeof(GenderType)).Length);
            string name;
            string surname;

            switch (gender)
            {
                case GenderType.Male:
                    name = _maleNames[Randomize.Next(_maleNames.Count)];
                    surname = _maleSurnames[Randomize.Next(_maleSurnames.Count)];
                    break;
                default:
                    name = _femaleNames[Randomize.Next(_femaleNames.Count)];
                    surname = _femaleSurnames[Randomize.Next(_femaleSurnames.Count)];
                    break;
            }

            int age = Randomize.Next(PersonBase.MinAge, Child.MaxChildAge);

            var father = new Adult();

            if (Randomize.Next(0, 2) == 1)
            {
                while (true)
                {
                    father = RandomPerson.GetRandomAdultPersonWithoutSpouse();

                    if (father.Gender == GenderType.Male)
                    {
                        break;
                    }
                }

                if (gender == GenderType.Female)
                {
                    surname = father.Surname + "а";
                }
                else
                {
                    surname = father.Surname;
                }
            }

            var mother = new Adult();

            if (Randomize.Next(0, 2) == 1)
            {
                if (string.IsNullOrEmpty(father.Name))
                {
                    while (true)
                    {
                        mother = RandomPerson.GetRandomAdultPersonWithoutSpouse();

                        if (mother.Gender == GenderType.Female)
                        {
                            break;
                        }
                    }

                    if (gender == GenderType.Female)
                    {
                        surname = mother.Surname;
                    }
                    else
                    {
                        surname = mother.Surname.Remove(mother.Surname.Length - 1, 1);
                    }
                }
                else
                {
                    mother = Adult.FindSpouse(father);
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

            if (age < 6)
            {
                placeOfStudy = kindergartensList[Randomize.Next(0, kindergartensList.Count)];
            }
            else
            {
                placeOfStudy = schoolsList[Randomize.Next(0, schoolsList.Count)];
            }

            if (string.IsNullOrEmpty(father.Name) && string.IsNullOrEmpty(mother.Name))
            {
                return new Child(name, surname, age, gender, "Сирота", "Детский дом №1");
            }
            else
            {
                return new Child(name, surname, age, gender, mother, father, placeOfStudy);
            }
        }
    }
}

