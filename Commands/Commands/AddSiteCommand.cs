using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Команда добавления сайта.
    /// </summary>
    public class AddSiteCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "AddSite";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static readonly CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteName", ArgType.STRING, "Имя сайта"),
            new CommandArgument("uri", ArgType.STRING, "Ссылка на ресурс"),
            new CommandArgument("srvIndex", ArgType.INT, "Серверный индекс") 
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
