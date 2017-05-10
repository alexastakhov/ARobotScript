using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Commands
{
    /// <summary>
    /// Типы аргументов.
    /// </summary>
    public enum ArgType
    {
        /// <summary>
        /// Строковый тип.
        /// </summary>
        STRING,

        /// <summary>
        /// Строковый тип имени модуля, содержащий разделяющий слэш.
        /// </summary>
        N_STRING,

        /// <summary>
        /// Булевский тип.
        /// </summary>
        BOOL,

        /// <summary>
        /// Массив строк.
        /// </summary>
        STR_ARR,

        /// <summary>
        /// Массив имен модулей, содержащих разделяющий слэш.
        /// </summary>
        N_STR_ARR,

        /// <summary>
        /// Целый тип.
        /// </summary>
        INT
    }
}
