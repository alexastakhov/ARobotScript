using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlfaRobot.ARobotScript.Compiler;
using AlfaRobot.ARobotScript.Commands;

namespace AlfaRobot.ARobotScript.Tests
{
    /// <summary>
    /// Тесты компилятора.
    /// </summary>
    [TestClass]
    public class CompilerTests
    {
        /// <summary>
        /// Пустой скрипт.
        /// </summary>
        [TestMethod]
        public void ScriptIsEmpty()
        {
            string script = "";

            var result = ScriptCompiler.Compile(script);

            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_INCORR_HEADER, result.Errors[0].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// Проверяем некорректный заголовок.
        /// </summary>
        [TestMethod]
        public void IncorrectHeader()
        {
            var text = "Invalid Header";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_INCORR_HEADER, result.Errors[0].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IncorrectCommand()
        {
            var text = "@AlfaScript\n\r\nIncorrectCommand(aaa, \"bbb\")";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(2, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_UNKN_COMMAND + " [строка: 3, столбец: 1]", result.Errors[0].ToString());
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[1].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IncorrectCommandWithSpacesBegin()
        {
            var text = "@AlfaScript\n\r\n     IncorrectCommand(aaa, \"bbb\")";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(2, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_UNKN_COMMAND + " [строка: 3, столбец: 6]", result.Errors[0].ToString());
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[1].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void NoCommandsInScript()
        {
            var text = "@AlfaScript";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[0].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnlyCommentsInScript()
        {
            var text = "@AlfaScript\n  #Comment1\n   #Comment2";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[0].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SpaceBetweenCommandAndBracket()
        {
            var text = "@AlfaScript\nBuildConf ()";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(2, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_CMD_FORMAT_OP_BRACK + " [строка: 2, столбец: 10]", result.Errors[0].ToString());
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[1].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SpaceBetweenCommandAndBracketWithSpacesBegin()
        {
            var text = "@AlfaScript\n    BuildConf ()";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(2, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_CMD_FORMAT_OP_BRACK + " [строка: 2, столбец: 14]", result.Errors[0].ToString());
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[1].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CorrectCommandWithoutParams()
        {
            var text = "@AlfaScript\n\r\nBuildConf()";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(0, result.Errors.Count);
            Assert.AreEqual(1, result.Programm.Count);
            Assert.IsTrue(result.Programm[0] is BuildConfCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CorrectCommandWithoutParamsWithSpacesBegins()
        {
            var text = "@AlfaScript\n\r\n     BuildConf()";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(0, result.Errors.Count);
            Assert.AreEqual(1, result.Programm.Count);
            Assert.IsTrue(result.Programm[0] is BuildConfCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnlySpacesInScript()
        {
            var text = "@AlfaScript\n          ";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[0].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnlyValidCommandNameInScript()
        {
            var text = "@AlfaScript\nBuildConf";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(2, result.Errors.Count);

            Assert.AreEqual(StringConst.ERR_CMD_FORMAT_OP_BRACK + " [строка: 2, столбец: 10]", result.Errors[0].ToString());
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[1].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnlyValidCommandNameInScriptWithSpacesBegins()
        {
            var text = "@AlfaScript\n         BuildConf";

            var result = ScriptCompiler.Compile(text);

            Assert.AreEqual(2, result.Errors.Count);

            Assert.AreEqual(StringConst.ERR_CMD_FORMAT_OP_BRACK + " [строка: 2, столбец: 19]", result.Errors[0].ToString());
            Assert.AreEqual(StringConst.ERR_NO_COMMANDS, result.Errors[1].ToString());
            Assert.AreEqual(0, result.Programm.Count);
        }
    }
}
