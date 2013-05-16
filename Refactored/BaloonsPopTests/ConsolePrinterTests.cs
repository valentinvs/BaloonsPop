using System;
using BaloonsPop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPopTests
{
    [TestClass]
    public class ConsolePrinterTests
    {
        [TestMethod]
        public void MassageTest()
        {
            string input = "Text test";
            var currentConsoleOut = Console.Out;

            ConsolePrinter.Message(input);

            using (var consoleOutput = new ConsoleOutput())
            {
                ConsolePrinter.Message(input);

                Assert.AreEqual(input, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}
