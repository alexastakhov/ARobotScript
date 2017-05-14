using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Класс аргумента команды.
    /// </summary>
    public class CommandArgument
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Хранит значение свойства <see cref="ValueType"/>
        /// </summary>
        private readonly ArgType valueType;

        /// <summary>
        /// Хранит значение свойства <see cref="Description"/>
        /// </summary>
        private readonly string description;

        /// <summary>
        /// Хранит значение свойства <see cref="BaseClass"/>
        /// </summary>
        private readonly Type baseClass;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="name">Имя аргумента.</param>
        /// <param name="valueType">Тип аргумента.</param>
        /// <param name="description">Описание аргумента.</param>
        public CommandArgument(string name, ArgType valueType, string description)
        {
            this.name = name;
            this.valueType = valueType;
            this.description = description;

            switch (valueType)
            {
                case ArgType.STRING:
                case ArgType.N_STRING: baseClass = typeof(string); break;
                case ArgType.STR_ARR:
                case ArgType.N_STR_ARR: baseClass = typeof(string[]); break;
                case ArgType.INT: baseClass = typeof(Int32); break;
                case ArgType.BOOL: baseClass = typeof(bool); break;
                default: baseClass = null; break;
            }
        }

        /// <summary>
        /// Имя аргумента.
        /// </summary
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Тип аргумента.
        /// </summary>
        public ArgType ValueType
        {
            get
            {
                return valueType;
            }
        }

        /// <summary>
        /// Описание аргумента.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        public Type BaseClass
        {
            get
            {
                return baseClass;
            }
        }
    }
}
