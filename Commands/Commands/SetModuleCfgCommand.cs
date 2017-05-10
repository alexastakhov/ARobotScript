using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands.Commands
{
    /// <summary>
    /// Команда измения конфигурации модуля целиком.
    /// </summary>
    public class SetModuleCfgCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "SetModuleCfg";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteNameSlashModuleName", ArgType.N_STRING, "Имя модуля в формате Сайт/Модуль"),
            new CommandArgument("xmlConfig", ArgType.STRING, "Конфигурация модуля в формате XML")
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
