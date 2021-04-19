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
        private static List<string> _maleNames = new List<string>()
        {
            "Артём", "Сергей", "Алексей", "Александр", "Павел",
                "Роман", "Тимур", "Пётр", "Дмитрий", "Геннадий"
        };
        private static List<string> _femaleNames = new List<string>()
        {
            "Анна", "Виктория", "Елизавета", "Полина", "Валентина",
                "Дарья", "Екатерина", "Лилия", "Карина", "Вероника"
        };
        private static List<string> _maleSurnames = new List<string>()
        {
            "Андропов", "Троцкий", "Поляков", "Иванов", "Харламов",
                "Гаврилов", "Астахов", "Жданов", "Емельянов", "Виноградов"
        };
        private static List<string> _femaleSurnames = new List<string>()
        {
            "Гагарина", "Агапова", "Воронова", "Дубровина", "Борисова",
                "Высоцкая", "Глебова", "Журавлёва", "Громова", "Казакова"
        };

        /// <summary>
        /// Метод для возрата случайных значений
        /// </summary>
        public static Random Randomize = new Random();

        /// <summary>
        /// Метод для получения данных о человеке со случайными параметрами
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public static Person GetRandomPerson()
        {
            string name;
            string surname;

            GenderType gender = (GenderType)Randomize.Next(0,
                Enum.GetNames(typeof(GenderType)).Length);

            if (gender == GenderType.Male)
            {
                name = _maleNames[Randomize.Next(_maleNames.Count)];
                surname = _maleSurnames[Randomize.Next(_maleSurnames.Count)];
            }
            else
            {
                name = _femaleNames[Randomize.Next(_femaleNames.Count)];
                surname = _femaleSurnames[Randomize.Next(_femaleSurnames.Count)];
            }

            int age = Randomize.Next(Person.MinAge, Person.MaxAge + 1);

            return new Person(name, surname, age, gender);
        }
    }
}

