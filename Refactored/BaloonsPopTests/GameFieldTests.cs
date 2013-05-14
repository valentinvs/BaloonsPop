using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaloonsPop;

namespace BaloonsPopTests
{
    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        public void GameFieldInitializeMethod()
        {
            GameField gameField = new GameField();


            Assert.AreSame(gameField, gameField);
        }
    }
}
