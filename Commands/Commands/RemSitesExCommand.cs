using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands.Commands
{
    /// <summary>
    /// Команда удаления сатов, кроме тех, которые есть в списке.
    /// </summary>
    public class RemSitesExCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "RemSitesEx";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteNames", ArgType.STR_ARR, "Имена сайтов, которые не должны удаляться")
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
