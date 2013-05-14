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
            int actualFieldWidth = gameField.GameFieldWidth;

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

            int expected = gameField1.GameFieldHeight * gameField1.GameFieldWidth;
            int actual = 0;

            for (int row = 0; row < gameField1.BalloonsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < gameField1.BalloonsMatrix.GetLength(1); col++)
                {
                    if (gameField1.BalloonsMatrix[row, col] == gameField2.BalloonsMatrix[row, col])
                    {
                        actual++;
                    }
                }
            }

            Assert.IsTrue(expected > actual);
        }
    }
}
