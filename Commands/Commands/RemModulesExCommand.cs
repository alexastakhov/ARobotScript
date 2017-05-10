namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Команда удаления всех модулей, кроме тех, которые есть списке.
    /// </summary>
    public class RemModulesExCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "RemModulesEx";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static readonly CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteNameSlashModuleNames", ArgType.N_STR_ARR, "Имена модулей, которые не должны удаляться, в формате Сайт/Модуль"),
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
