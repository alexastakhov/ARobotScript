using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Compiler
{
    public static class StringConst
    {
        /// <summary>
        /// Заголовок скрипта.
        /// </summary>
        public const string HEADER = "@AlfaScript";

        /// <summary>
        /// Последовательность, открывающая блок текста.
        /// </summary>
        public const string OPEN_TEXT_BLOCK = "${";

        /// <summary>
        /// Последовательность, закрывающая блок текста.
        /// </summary>
        public const string CLOSE_TEXT_BLOCK = "}$";

        /// <summary>
        /// Текст ошибки "Ошибка загрузки сборки команд".
        /// </summary>
        public const string ERR_LOAD_CMD_ASSEMBLY = "Ошибка загрузки сборки команд.";

        /// <summary>
        /// Текст ошибки "Неправильный заголовок".
        /// </summary>
        public const string ERR_INCORR_HEADER = "Некорректный заголовок скрипта.";

        /// <summary>
        /// Текст ошибки "Неизвестная команда".
        /// </summary>
        public const string ERR_UNKN_COMMAND = "Неизвестная команда.";

        /// <summary>
        /// Текст ошибки "Неправильный формат команды".
        /// </summary>
        public const string ERR_CMD_FORMAT_OP_BRACK = "Неправильный формат команды. После имени команды обязательна открывающая скобка.";

        /// <summary>
        /// Текст ошибки "Скрипт не содержит команд".
        /// </summary>
        public const string ERR_NO_COMMANDS = "Скрипт не содержит команд.";

        /// <summary>
        /// Текст ошибки "Ошибка формата аргумента типа Bool".
        /// </summary>
        public const string ERR_ARG_TYPE_BOOL = "Ошибка формата аргумента типа Bool. Допустимые значения 0 и 1.";

        /// <summary>
        /// Текст ошибки "Ошибка формата аргумента типа Int".
        /// </summary>
        public const string ERR_ARG_TYPE_INT = "Ошибка формата аргумента типа Int. Значение должно быть целым числом большим или равным нулю.";

        /// <summary>
        /// Текст ошибки "Ошибка формата аргумента типа String, открывающие кавычки.".
        /// </summary>
        public const string ERR_ARG_TYPE_STRING_OP = "Ошибка формата аргумента типа String. Необходимы открывающие двойные кавычки.";

        /// <summary>
        /// Текст ошибки "Ошибка формата аргумента типа String, открывающие кавычки.".
        /// </summary>
        public const string ERR_ARG_TYPE_STRING_CLS = "Ошибка формата аргумента типа String. Необходимы Закрывающие двойные кавычки.";
    }
}
