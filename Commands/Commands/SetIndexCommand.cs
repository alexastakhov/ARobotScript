namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Команда изменения серверного индекса сайта.
    /// </summary>
    public class SetIndexCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "SetIndex";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static readonly CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteName", ArgType.STRING, "Имя сайта"),
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
