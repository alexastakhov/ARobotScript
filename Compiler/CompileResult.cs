using AlfaRobot.ARobotScript.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Compiler
{
    /// <summary>
    /// Результат компиляции.
    /// </summary>
    public class CompileResult
    {
        /// <summary>
        /// Хранит значение свойства <see cref="Programm"/>
        /// </summary>
        private List<ScriptCommand> programm;

        /// <summary>
        /// Хранит значение свойства <see cref="Errors"/>
        /// </summary>
        private List<ErrorRecord> errors;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="programm">Последовательность инструкций.</param>
        /// <param name="errors">Список ошибок.</param>
        public CompileResult(List<ScriptCommand> programm, List<ErrorRecord> errors)
        {
            this.programm = programm;
            this.errors = errors;
        }

        /// <summary>
        /// Последовательность инструкций.
        /// </summary>
        public List<ScriptCommand> Programm
        {
            get 
            { 
                return programm; 
            }
        }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<ErrorRecord> Errors
        {
            get 
            {
                return errors;
            }
        }
    }
}
