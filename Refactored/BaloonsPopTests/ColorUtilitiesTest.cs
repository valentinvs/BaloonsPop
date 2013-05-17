namespace BaloonsPopTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaloonsPop;

    [TestClass]
    public class ColorUtilitiesTest
    {
        [TestMethod]
        public void MatchColorTestRed()
        {
            ColorEnum color = ColorEnum.Red;

            ConsoleColor acual = ColorUtilities.MatchColor(color);
            ConsoleColor expected = ConsoleColor.Red;

            Assert.AreEqual(expected, acual);
        }

        [TestMethod]
        public void MatchColorTestGreen()
        {
            ColorEnum color = ColorEnum.Green;

            ConsoleColor acual = ColorUtilities.MatchColor(color);
            ConsoleColor expected = ConsoleColor.Green;

            Assert.AreEqual(expected, acual);
        }

        [TestMethod]
        public void MatchColorTestBlue()
        {
            ColorEnum color = ColorEnum.Blue;

            ConsoleColor acual = ColorUtilities.MatchColor(color);
            ConsoleColor expected = ConsoleColor.Blue;

            Assert.AreEqual(expected, acual);
        }

        [TestMethod]
        public void MatchColorTestWhite()
        {
            ColorEnum color = ColorEnum.White;

            ConsoleColor acual = ColorUtilities.MatchColor(color);
            ConsoleColor expected = ConsoleColor.White;

            Assert.AreEqual(expected, acual);
        }

        [TestMethod]
        public void MatchColorTestYellow()
        {
            ColorEnum color = ColorEnum.Yellow;

            ConsoleColor acual = ColorUtilities.MatchColor(color);
            ConsoleColor expected = ConsoleColor.Yellow;

            Assert.AreEqual(expected, acual);
        }
    }
}
