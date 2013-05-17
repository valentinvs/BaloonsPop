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
            int expectedFieldWidth = 10;
            int actualFieldWidth = GameField.FieldWidth;

            Assert.AreEqual(expectedFieldWidth, actualFieldWidth);
            Assert.IsTrue(expectedFieldWidth == actualFieldWidth);
        }

        // Example test
        [TestMethod]
        // [ExpectedException(typeof(ArgumentException))]
        public void GameFieldPopBalloonTest()
        {
            GameField gameField = new GameField();
            gameField.BalloonsMatrix[2, 2].Pop();

            bool expected = gameField.BalloonsMatrix[2, 2].IsPopped;
            Assert.IsTrue(expected);
        }

        [TestMethod]
        // [ExpectedException(typeof(ArgumentException))]
        public void PopsEqualColoredBalloonsTest()
        {
            GameField gameField = new GameField();
            gameField.BalloonsMatrix[1, 0].Pop();

            gameField.PopsEqualColoredBalloons(1, 0, gameField.BalloonsMatrix[1, 0]);
            gameField.UpdateBalloonsPositions();

            char actual = gameField.BalloonsMatrix[0, 0].GetBalloonChar();
            char expected = ' ';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // [ExpectedException(typeof(ArgumentException))]
        public void GameFieldIsPoppedTest()
        {
            GameField gameField = new GameField();
            gameField.BalloonsMatrix[2, 2].Pop();

            bool expected = gameField.BalloonsMatrix[2, 2].GetBalloonChar() == ' ';
            Assert.IsTrue(expected);
        }

        //[TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        //public void GameFieldBalloonsCountTest()
        //{
        //    GameField gameField = new GameField();
        //    gameField.BalloonsMatrix[2, 2].Pop();
        //    gameField.UpdateBalloonsPositions();
        //    bool expected = gameField.BallonsCount < GameField.FieldHeight * GameField.FieldWidth;
        //    Assert.IsTrue(expected);
        //}

        // Example test
        [TestMethod]
        // [ExpectedException(typeof(ArgumentException))]
        public void GameFieldInitializeMethod()
        {
            GameField gameField1 = new GameField();
            GameField gameField2 = new GameField();

            int expected = GameField.FieldHeight * GameField.FieldWidth;
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
