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
    class Adult : Person
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
        /// Метод для формирования строки с информацией о человеке
        /// </summary>
        public new string Info()
        {
            if (FamilyStatus == FamilyStatusType.Married)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {FamilyStatus} с " +
                       $"Место работы - {PlaceOfWork}";
            }
            else if (FamilyStatus == FamilyStatusType.Unmarried && Gender == GenderType.Male)
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {FamilyStatus}" +
                       $"Место работы - {PlaceOfWork}";
            }
            else
            {
                return $"Имя и фамилия - {Name} {Surname}; " +
                       $"возраст - {Age}; пол - {(RussianGenderType)Gender}\n" +
                       $"Данные паспорта: серия - {PassportSeries}; номер - {PassportNumber}\n" +
                       $"Семейное положение - {FamilyStatus}" +
                       $"Место работы - {PlaceOfWork}";
            }
        }
            
    }
}
