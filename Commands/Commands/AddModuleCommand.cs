using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Команда добавления модуля.
    /// </summary>
    public class AddModuleCommand : ScriptCommand
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Name"/>.
        /// </summary>
        private static string name = "AddModule";

        /// <summary>
        /// Хранит значение свойства <see cref="Arguments"/>.
        /// </summary>
        private static readonly CommandArgument[] arguments = new CommandArgument[]
        {
            new CommandArgument("siteNameSlashModuleName", ArgType.N_STRING, "Имя модуля в формате Сайт/Модуль"),
            new CommandArgument("moduleType", ArgType.STRING, "Полный тип модуля"),
            new CommandArgument("createRules", ArgType.BOOL, "Создавать ли точки и правила"),
            new CommandArgument("createModule", ArgType.BOOL, "Создавать ли модуль")
        };

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="values">Аргументы команды.</param>
        public AddModuleCommand(object[] values) : base(values)
        {
            CheckArgumentValues(values);
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

        /// <summary>
        /// 
        /// </summary>
        public string SiteNameSlashModuleName
        {
            get
            {
                return (string)values[0];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ModuleType
        {
            get
            {
                return (string)values[1];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CreateRules
        {
            get
            {
                return (bool)values[2];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CreateModule
        {
            get
            {
                return (bool)values[3];
            }
        }
    }
}
