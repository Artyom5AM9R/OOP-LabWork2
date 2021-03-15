﻿using System;
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
    }
}
