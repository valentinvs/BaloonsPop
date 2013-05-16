using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaloonsPop;

namespace BaloonsPopTests
{
    [TestClass]
    public class GameFieldTests
    {
        // Example test
        [TestMethod]
        // [ExpectedException(typeof(ArgumentException))]
        public void GameFieldWidthTest()
        {
            GameField gameField = new GameField();
            int expectedFieldWidth = 10;
            int actualFieldWidth = GameField.FieldWidth;

            Assert.AreEqual(expectedFieldWidth, actualFieldWidth);
            Assert.IsTrue(expectedFieldWidth == actualFieldWidth);
        }

        // Example test
        [TestMethod]
        // [ExpectedException(typeof(ArgumentException))]
        public void GameFieldInitializeMethod()
        {
            GameField gameField1 = new GameField();
            GameField gameField2 = new GameField();

            int expected = GameField.FieldHeight * GameField.FieldWidth;
            int actual = 0;

            for (int row = 0; row < gameField1.Balloons.GetLength(0); row++)
            {
                for (int col = 0; col < gameField1.Balloons.GetLength(1); col++)
                {
                    if (gameField1.Balloons[row, col] == gameField2.Balloons[row, col])
                    {
                        actual++;
                    }
                }
            }

            Assert.IsTrue(expected > actual);
        }
    }
}
