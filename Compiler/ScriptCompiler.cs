using AlfaRobot.ARobotScript.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlfaRobot.ARobotScript.Compiler
{
    /// <summary>
    /// Класс компилятора скрипта.
    /// </summary>
    public static class ScriptCompiler
    {
        /// <summary>
        /// Имя файла сборки с командами.
        /// </summary>
        private const string CMD_ASSEMBLY = "AlfaRobot.ARobotScript.Commands.dll";

        /// <summary>
        /// Коллекция типов поддерживаемых команд.
        /// </summary>
        private static List<Type> commandTypes;

        /// <summary>
        /// Метод компиляции.
        /// </summary>
        /// <param name="script">Текст скрипта.</param>
        /// <returns>Результат компиляции.</returns>
        public static CompileResult Compile(string script)
        {
            var programm = new List<ScriptCommand>();
            var errors = new List<ErrorRecord>();

            var isTextBlock = false;
            var isAgruments = false;

            string currentCommandName;
            CommandArgument[] currentCommandArguments;

            try
            {
                LoadCommandsFromAssembly(CMD_ASSEMBLY);
            }
            catch (Exception e)
            {
                errors.Add(new ErrorRecord(string.Format("{0} ({1})", StringConst.ERR_LOAD_CMD_ASSEMBLY, e.Message)));

                return new CompileResult(programm, errors);
            }

            var lines = PrepareLines(script);

            // Проверяем корректность заголовка
            if (lines[0] != StringConst.HEADER)
            {
                errors.Add(new ErrorRecord(StringConst.ERR_INCORR_HEADER));

                return new CompileResult(programm, errors);
            }

            for (int rowNumber = 1; rowNumber < lines.Length; rowNumber++)
            {
                var index = 0;
                var currStr = lines[rowNumber];

                if (!isTextBlock)
                {
                    index = GetNextCharIndex(currStr, index);

                    if (!isAgruments && currStr.Length > index && index >= 0)
                    {
                        // Строка с комментарием
                        if (currStr.Substring(index, currStr.Length - index).StartsWith("#"))
                        {
                            continue;
                        }

                        // Получаем имя команды в текущей строке
                        currentCommandName = GetCommandNameFromLine(currStr.Substring(index, currStr.Length - index));

                        // Команда не найдена
                        if (string.IsNullOrEmpty(currentCommandName))
                        {
                            errors.Add(new ErrorRecord(StringConst.ERR_UNKN_COMMAND, rowNumber, index));

                            continue;
                        }

                        index += currentCommandName.Length;

                        // После имени команды отсутствует скобка
                        if (currStr.Length == index || currStr[index] != '(')
                        {
                            errors.Add(new ErrorRecord(StringConst.ERR_CMD_FORMAT_OP_BRACK, rowNumber, index));

                            continue;
                        }

                        index++;

                        // Разбор аргументов
                        index = GetNextCharIndex(currStr, index);
                        currentCommandArguments = GetCommandArguments(currentCommandName);

                        // Аргументы с новой строки
                        if (currStr.Length == index)
                        {
                            isAgruments = true;

                            continue;
                        }

                        for (var i = 0; i < currentCommandArguments.Length; i++)
                        {
                            if (currentCommandArguments[i].ValueType == ArgType.BOOL)
                            {
                                int value = -1;

                                int.TryParse(currStr[index].ToString(), out value);

                                if (value == -1)
                                {
                                    errors.Add(new ErrorRecord(StringConst.ERR_ARG_TYPE_BOOL, rowNumber, index));
                                }
                            }

                            if (currentCommandArguments[i].ValueType == ArgType.STRING)
                            {
                                if (currStr[index] != '\"')
                                {
                                    errors.Add(new ErrorRecord(StringConst.ERR_ARG_TYPE_STRING_OP, rowNumber, index));
                                }
                            }

                            if (currentCommandArguments[i].ValueType == ArgType.INT)
                            {
                                int value = -1;

                                int.TryParse(currStr[index].ToString(), out value);

                                if (value == -1)
                                {
                                    errors.Add(new ErrorRecord(StringConst.ERR_ARG_TYPE_INT, rowNumber, index));
                                }
                            }

                            if (currentCommandArguments[i].ValueType == ArgType.STR_ARR)
                            {

                            }
                        }
                    }
                }
            }

            if (programm.Count == 0)
            {
                errors.Add(new ErrorRecord(StringConst.ERR_NO_COMMANDS));
            }

            return new CompileResult(programm, errors);
        }

        /// <summary>
        /// Получить имя команды в текущей строке.
        /// </summary>
        /// <param name="line">Текущая строка.</param>
        /// <returns>Имя команды. Если команды нет, то возвращаем пустую строку.</returns>
        private static string GetCommandNameFromLine(string line)
        {
            foreach (var command in commandTypes)
            {
                var cmdName = GetCommandNameByType(command);

                if (line.StartsWith(cmdName))
                {
                    return cmdName;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Получить индекс следующего значащего символа, пропустив пробелы.
        /// </summary>
        /// <param name="line">Входная строка.</param>
        /// <param name="beginIndex">Индекс, с которого начинается отсчет.</param>
        /// <returns>Полученный индекс.</returns>
        private static int GetNextCharIndex(string line, int beginIndex)
        {
            if (beginIndex >= line.Length || beginIndex < 0)
            {
                return -1;
            }

            while (line.Length > beginIndex && line[beginIndex] == ' ')
            {
                beginIndex++;
            }

            return beginIndex;
        }

        /// <summary>
        /// Разделить текст скрипта на строки.
        /// </summary>
        /// <param name="text">Текст скрипта.</param>
        /// <returns>Массив строк.</returns>
        private static string[] PrepareLines(string text)
        {
            return text.Replace("\r", "").Split('\n');
        }

        /// <summary>
        /// Загрузить сборку с командами.
        /// </summary>
        /// <param name="assemblyFileName">Имя файла сборки.</param>
        private static void LoadCommandsFromAssembly(string assemblyFileName)
        {
            Assembly cmdAssembly;

            try
            {
                cmdAssembly = Assembly.LoadFrom(assemblyFileName);
            }
            catch (Exception e)
            {
                throw e;
            }

            var types = cmdAssembly.GetTypes();
            commandTypes = new List<Type>();

            foreach (var t in types)
            {
                if (t.BaseType != null && t.BaseType.Name == typeof(ScriptCommand).Name)
                {
                    commandTypes.Add(t);
                }
            }
        }

        /// <summary>
        /// Получить список аргументов команды по имени команды.
        /// </summary>
        /// <param name="commandName">Имя команды.</param>
        /// <returns>Список аргументов.</returns>
        private static CommandArgument[] GetCommandArguments(string commandName)
        {
            foreach (var command in commandTypes)
            {
                if (GetCommandNameByType(command) == commandName)
                {
                    return GetCommandArguments(command);
                }
            }

            return null;
        }

        /// <summary>
        /// Получить список аргументов команды из объекта типа команды.
        /// </summary>
        /// <param name="command">Объект типа команды.</param>
        /// <returns>Список аргументов.</returns>
        private static CommandArgument[] GetCommandArguments(Type command)
        {
            if (command.BaseType == null || command.BaseType != typeof(ScriptCommand))
            {
                return null;
            }

            return (CommandArgument[])command.GetProperty("Arguments").GetValue(null);
        }

        /// <summary>
        /// Получить имя команды из объекта типа команды.
        /// </summary>
        /// <param name="command">Объект типа команды.</param>
        /// <returns>Имя команды.</returns>
        private static string GetCommandNameByType(Type command)
        {
            if (command.BaseType == null || command.BaseType != typeof(ScriptCommand))
            { 
                return null;
            }

            return (string)command.GetProperty("Name").GetValue(null);
        }

        /// <summary>
        /// Получить объект типа команды по имени команды.
        /// </summary>
        /// <param name="name">Имя команды.</param>
        /// <returns>Объект типа команды.</returns>
        private static Type GetCommandTypeByName(string name)
        {
            return commandTypes.FirstOrDefault(command => GetCommandNameByType(command) == name);
        }
    }
}
