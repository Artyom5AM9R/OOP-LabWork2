using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания детей
    /// </summary>
    class Child : Person
    {
        /// <summary>
        /// Поле для описания матери ребёнка
        /// </summary>
        private Person _mother;

        /// <summary>
        /// Поле для описания отца ребёнка
        /// </summary>
        private Person _father;

        /// <summary>
        /// Поле для описания названия детского сада/школы ребёнка
        /// </summary>
        private string _placeOfStudy;
    }
}
