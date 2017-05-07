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
