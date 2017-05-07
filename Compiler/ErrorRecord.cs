using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Compiler
{
    public class ErrorRecord
    {
        /// <summary>
        /// Хранит значение <see cref="ErrorText"/>.
        /// </summary>
        private readonly string errorText;

        /// <summary>
        /// Хранит значение <see cref="RowNumber"/>.
        /// </summary>
        private readonly int rowNumber = 0;

        /// <summary>
        /// Хранит значение <see cref="ColumnNumber"/>.
        /// </summary>
        private readonly int columnNumber = 0;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="errorText">Текст ошибки.</param>
        /// <param name="rowNumber">Номер строки с ошибкой.</param>
        /// <param name="columnNumber">Номер столбца с ошибкой.</param>
        public ErrorRecord(string errorText, int rowNumber = 0, int columnNumber = 0)
        {
            this.errorText = errorText;
            this.rowNumber = rowNumber;
            this.columnNumber = columnNumber;
        }

        /// <summary>
        /// Текст ошибки.
        /// </summary>
        public string ErrorText
        {
            get
            {
                return errorText;
            }
        }

        /// <summary>
        /// Номер строки с ошибкой.
        /// </summary>
        public int RowNumber
        {
            get
            {
                return rowNumber;
            }
        }
        /// <summary>
        /// Номер столбца с ошибкой.
        /// </summary>
        public int ColumnNumber
        {
            get
            {
                return columnNumber;
            }
        }

        /// <summary>
        /// Строковое представление ошибки.
        /// </summary>
        /// <returns>Строковое представление ошибки.</returns>
        public override string ToString()
        {
            if (rowNumber > 0)
            {
                return string.Format("{0} [строка: {1}, столбец: {2}]", ErrorText, rowNumber + 1, columnNumber + 1);
            }

            return errorText;
        }
    }
}
