using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands.Commands
{
    /// <summary>
    /// Команда удаления сайта
    /// </summary>
    public class RemSiteCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "RemSite";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteName", ArgType.STRING, "Имя сайта")
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
