using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands.Commands
{
    /// <summary>
    /// Команда включения/выключения создания правил и модулей.
    /// </summary>
    public class SetOnCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "SetOn";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteNameSlashModuleName", ArgType.STRING, "Имя модуля в формате Сайт/Модуль"),
            new CommandArgument("createRules", ArgType.BOOL, "Создавать ли точки и правила"),
            new CommandArgument("createModule", ArgType.BOOL, "Создавать ли модуль") 
        };

        /// <summary>
        /// Аргументы команды.
        /// </summary>
        public new static CommandArgument[] Arguments
        {
            get
            {
                return arguments;
            }
        }

        /// <summary>
        /// Имя команды.
        /// </summary>
        public new static string Name
        {
            get
            {
                return name;
            }
        }
    }
}
