using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlfaRobot.ARobotScript.Commands;

namespace AlfaRobot.ARobotScript.Tests
{
    /// <summary>
    /// Тесты команд.
    /// </summary>
    [TestClass]
    public class CommandTests
    {
        /// <summary>
        /// Корректное создание объекта команды AddModule.
        /// </summary>
        [TestMethod]
        public void AddModuleCommandCorrectCreation()
        {
            var modName = "module1";
            var modType = "typeOfModule1";
            var flag1 = true;
            var flag2 = false;
            object[] values = new object[] { modName, modType, flag1, flag2 };

            var command = new AddModuleCommand(values);

            Assert.AreEqual("module1", command.SiteNameSlashModuleName);
            Assert.AreEqual("typeOfModule1", command.ModuleType);
            Assert.AreEqual(true, command.CreateRules);
            Assert.AreEqual(false, command.CreateModule);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), ErrorConst.ERR_ARGUMENT_NUM)]
        public void AddModuleCommandInvalidNumOfArguments()
        {
            var modName = "module1";
            var modType = "typeOfModule1";
            var flag1 = true;
            var flag2 = false;
            var overArg = "overArg";
            object[] values = new object[] { modName, modType, flag1, flag2, overArg };

            var command = new AddModuleCommand(values);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddModuleCommandInvalidTypeOfArgument()
        {
            var modName = "module1";
            var modInt = 1001;
            var flag1 = true;
            var flag2 = false;
            object[] values = new object[] { modName, modInt, flag1, flag2 };

            var command = new AddModuleCommand(values);
        }
    }
}
