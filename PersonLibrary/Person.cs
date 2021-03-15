using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания человека
    /// </summary>
    public class Person
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
        const int MinAge = 1;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        const int MaxAge = 117;

        /// <summary>
        /// Свойство для обращения к полю _name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = NameOrSurnameValidation(value, 0);
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
            private set
            {
                _surname = NameOrSurnameValidation(value, 1);
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
            private set
            {
                while (true)
                {
                    if (value < MinAge)
                    {
                        RedTextOutput($"\nВозраст не может быть меньше {MinAge}!\n");
                        value = InputAge();
                    }
                    else if (value > MaxAge)
                    {
                        RedTextOutput($"\nВозраст не может быть больше {MaxAge}!\n");
                        value = InputAge();
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
        /// Свойство для обращения к полю, описывающему пол человека
        /// </summary>
        public GenderType Gender { get; private set; }

        /// <summary>
        /// Пуской конструктор класса Person
        /// </summary>
        public Person() { }

        /// <summary>
        /// Конструктор с параметрами для класса Person
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public Person(string name, string surname, int age, GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Свойство для получения информации о человеке
        /// </summary>
        /// <returns>Значение формата string</returns>
        public string Info => $"Имя и фамилия - {Name} {Surname}; " +
                              $"возраст - {Age}; пол - {(RussianGenderType)Gender}";

        /// <summary>
        /// Метод для вывода в консоль текста в красном цвете
        /// </summary>
        /// <param name="text">Текст для вывода в консоль</param>
        public static void RedTextOutput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод для ручного создания записи о человеке
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public Person InputPerson()
        {
            try
            {
                while (true)
                {
                    Name = InputNameOrSurname(0);
                    Surname = InputNameOrSurname(1);
                    Regex RegexRussian = new Regex(@"[а-яё]");
                    Regex RegexEnglish = new Regex(@"[a-z]");
                    if (RegexRussian.IsMatch(Name) && RegexEnglish.IsMatch(Surname) ||
                        RegexEnglish.IsMatch(Name) && RegexRussian.IsMatch(Surname))
                    {
                        RedTextOutput("\nНе допускается ввод имени и фамилии на разных языках. " +
                            "Повторите ввод заново.\n");
                    }
                    else
                    {
                        break;
                    }
                }
                Age = InputAge();
                Gender = InputGender();

                return new Person(Name, Surname, Age, Gender);
            }
            catch (Exception exception)
            {
                RedTextOutput($"{exception.Message}\nВ список будет добавлена " +
                    "случайная запись о человеке.");

                return GetRandomPerson();
            }
        }

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
            List<string> maleNames = new List<string>()
            {
                "Артём", "Сергей", "Алексей", "Александр", "Павел",
                    "Роман", "Тимур", "Пётр", "Дмитрий", "Геннадий"
            };
            List<string> femaleNames = new List<string>()
            {
                "Анна", "Виктория", "Елизавета", "Полина", "Валентина",
                    "Дарья", "Екатерина", "Лилия", "Карина", "Вероника"
            };
            List<string> maleSurnames = new List<string>()
            {
                "Андропов", "Троцкий", "Поляков", "Иванов", "Харламов",
                    "Гаврилов", "Астахов", "Жданов", "Емельянов", "Виноградов"
            };
            List<string> femaleSurnames = new List<string>()
            {
                "Гагарина", "Агапова", "Воронова", "Дубровина", "Борисова",
                    "Высоцкая", "Глебова", "Журавлёва", "Громова", "Казакова"
            };
            string name;
            string surname;

            GenderType gender = (GenderType)Randomize.Next(0, Enum.GetNames(typeof(GenderType)).Length);
            if (gender == GenderType.Male)
            {
                name = maleNames[Randomize.Next(maleNames.Count)];
                surname = maleSurnames[Randomize.Next(maleSurnames.Count)];
            }
            else
            {
                name = femaleNames[Randomize.Next(femaleNames.Count)];
                surname = femaleSurnames[Randomize.Next(femaleSurnames.Count)];
            }
            int age = Randomize.Next(MinAge, MaxAge);

            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Метод для ввода имени/фамилии из консоли
        /// </summary>
        /// <param name="identifier">Идентификатор имени (0) или фамилии (1)</param>
        /// <returns>Значение формата string</returns>
        public string InputNameOrSurname(int identifier)
        {
            string input = "";

            if (identifier == 0)
            {
                Console.Write("Введите имя - ");
                input = Console.ReadLine();
            }
            else if (identifier == 1)
            {
                Console.Write("Введите фамилию - ");
                input = Console.ReadLine();
            }
            else
            {
                throw new Exception("Неверный идентификатор для функции ввода имени/фамилии.");
            }

            return input;
        }

        /// <summary>
        /// Метод для проверки введённых имени или фамилии человека
        /// </summary>
        /// <param name="nameForCheck">Имя или фамилия, которые подлежат проверке</param>
        /// <param name="identifier">Идентификатор имени (0) или фамилии (1)</param>
        /// <returns>Значение формата string</returns>
        public string NameOrSurnameValidation(string nameForCheck, int identifier)
        {
            string name = "";

            while (true)
            {
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

                if (name != "" && name.Contains("-"))
                {
                    name = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf("-")) +
                        name.Substring(name.IndexOf("-") + 1, 1).ToUpper() +
                        name.Substring(name.IndexOf("-") + 2);
                    break;
                }
                else if (name != "" && !name.Contains("-"))
                {
                    name = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);
                    break;
                }
                else
                {
                    RedTextOutput("\nОшибка! Повторите ввод.\n");
                    nameForCheck = InputNameOrSurname(identifier);
                }
            }

            return name;
        }

        /// <summary>
        /// Метод для ввода возраста человека из консоли
        /// </summary>
        /// <returns>Значение формата int</returns>
        public int InputAge()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите возраст - ");
                    string inputLine = Console.ReadLine();
                    return int.Parse(inputLine);
                }
                catch (Exception exception)
                {
                    RedTextOutput($"\n{exception.Message} Повторите ввод.\n");
                }
            }
        }

        /// <summary>
        /// Метод для ввода пола человека из консоли и проверки введённого значения
        /// </summary>
        /// <returns>Значение формата string</returns>
        public GenderType InputGender()
        {
            while (true)
            {
                Console.Write("Введите пол (м/ж) - ");
                string genderString = Console.ReadLine().ToLower();

                if (genderString == "м")
                {
                    return GenderType.Male;
                }
                else if (genderString == "ж")
                {
                    return GenderType.Female;
                }
                else
                {
                    RedTextOutput("\nПол указан неверно!\n");
                }
            }
        }
    }
}
