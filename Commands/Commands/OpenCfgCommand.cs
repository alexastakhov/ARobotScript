namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Команда открытия файла конфигурации.
    /// </summary>
    public class OpenCfgCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "OpenCfg";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static readonly CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("fileName", ArgType.STRING, "Имя файла конфигурации"),
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
