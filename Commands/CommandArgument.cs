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
    }
}
