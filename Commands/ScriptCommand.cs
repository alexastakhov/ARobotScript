using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Базовый класс для команд.
    /// </summary>
    public abstract class ScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        protected object[] values = null;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ScriptCommand()
        {
        }

        /// <summary>
        /// Конструктор с аргументами команды.
        /// </summary>
        /// <param name="values">Значения аргументов команды.</param>
        public ScriptCommand(object[] values)
        {
            this.values = values;
        }

        /// <summary>
        /// Проверка правильности аргументов команды.
        /// </summary>
        /// <param name="values">Аргументы команды.</param>
        protected void CheckArgumentValues(CommandArgument[] args)
        {
            if (this.values.Length != args.Length)
            {
                throw new ArgumentException(ErrorConst.ERR_ARGUMENT_NUM);
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (!args[i].BaseClass.IsInstanceOfType(this.values[i]))
                {
                    throw new ArgumentException(string.Format(ErrorConst.ERR_ARGUMENT_TYPE, i));
                }
            }
        }

        /// <summary>
        /// Имя команды.
        /// </summary>
        public static string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Массив аргументов.
        /// </summary>
        public static CommandArgument[] Arguments
        {
            get;
            private set;
        }

        /// <summary>
        /// Строковое представление.
        /// </summary>
        /// <returns>Строковое представление.</returns>
        public new string ToString()
        {
            var result = new StringBuilder(Name + " [");

            for (var i = 0; i < Arguments.Length; i++)
            {
                result.Append(Arguments[i]);

                if (i < Arguments.Length - 1)
                {
                    result.Append(", ");
                }
            }

            result.Append("]");

            return result.ToString();
        }
    }
}
