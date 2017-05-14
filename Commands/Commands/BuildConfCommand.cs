namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Команда создания конфигурации.
    /// </summary>
    public class BuildConfCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "BuildConf";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static readonly CommandArgument[] arguments = new CommandArgument[] { };

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public BuildConfCommand()
        {
        }

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
