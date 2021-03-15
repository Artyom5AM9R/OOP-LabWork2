using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс, описывающий абстракцию списка, содержащего объекты класса Person
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Массив для хранения списка записей о людях
        /// </summary>
        private Person[] _list = new Person[0];

        /// <summary>
        /// Метод для вывода списка людей на экран
        /// </summary>
        /// <param name="heading">Заголовок перед списком</param>
        public void ShowList(string heading)
        {
            Console.WriteLine(heading);
            foreach (Person Man in _list)
            {
                Console.WriteLine(Man.Info);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для добавления записи о человеке в список людей
        /// </summary>
        /// <param name="person">Объект класса Person</param>
        public void Add(Person person)
        {
            Array.Resize(ref _list, _list.Length + 1);
            _list[_list.Length - 1] = person;
        }

        /// <summary>
        /// Метод для удаления последней записи из списка людей
        /// </summary>
        public void Remove()
        {
            if (_list.Length > 0)
            {
                Array.Resize(ref _list, _list.Length - 1);
            }
            else
            {
                Person.RedTextOutput("Спиcок пуст, записей для удаления нет!\n");
            }
        }

        /// <summary>
        /// Метод для удаления записи в списке людей по её индексу
        /// </summary>
        public void RemoveByIndex(int index)
        {
            try
            {
                if (_list.Length > 0)
                {
                    Array.Clear(_list, index - 1, 1);
                    List<Person> listForCopy = new List<Person>();
                    foreach (Person Human in _list)
                    {
                        if (Human != null)
                        {
                            listForCopy.Add(Human);
                        }
                    }
                    Array.Resize(ref _list, _list.Length - 1);
                    _list = listForCopy.ToArray();
                }
                else
                {
                    Person.RedTextOutput("Спиcок пуст, записей для удаления нет!\n");
                }
            }
            catch (Exception exception)
            {
                Person.RedTextOutput($"{exception.Message}\n");
            }
        }

        /// <summary>
        /// Метод для поиска записи о человека в списке людей по её индексу
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public Person Find(int index)
        {
            try
            {
                return _list[index - 1];
            }
            catch (Exception exception)
            {
                Person.RedTextOutput($"{exception.Message}\nВ качестве результата поиска была принята " +
                    "случайная запись о человеке.\n");
                return Person.GetRandomPerson();
            }
        }

        /// <summary>
        /// Метод для поиска индекса записи в списке людей по её параметрам
        /// </summary>
        public void FindIndex()
        {
            Console.WriteLine("Введите параметры записи для поиска её индекса в списке:");
            Console.Write("Имя - ");
            string searchLine = Console.ReadLine();
            Console.Write("Фамилия - ");
            searchLine = searchLine + Console.ReadLine();
            Console.Write("Возраст - ");
            searchLine = searchLine + Console.ReadLine();
            int noteIndex = 0;
            foreach (Person Human in _list)
            {
                if (string.Format(Human.Name + Human.Surname + Human.Age) == searchLine)
                {
                    noteIndex = Array.IndexOf(_list, Human) + 1;
                }
            }
            if (noteIndex > 0)
            {
                Console.WriteLine("\nИндекс записи в списке - " + noteIndex + "\n");
            }
            else
            {
                Person.RedTextOutput("\nТакой записи в списке нет!\n");
            }
        }

        /// <summary>
        /// Метод для очистки записей в списке людей
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref _list, 0);
        }

        /// <summary>
        /// Метод для опряделения количества записей в списке людей
        /// </summary>
        /// <returns>Число типа int</returns>
        public int Count()
        {
            return _list.Length;
        }
    }
}
