﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaloonsPop;

namespace BaloonsPopTests
{
    [TestClass]
    public class BalloonTests
    {
        [TestMethod]
        public void BalloonConstructorTest()
        {
            var color = ColorEnum.Blue;
            Balloon balloon = new Balloon(color);
            bool expected = balloon.Color == color && balloon.IsPopped == false;

            Assert.IsTrue(expected);
        }


        [TestMethod]
        public void GetBallonCharTest_NotPoped()
        {
            var color = ColorEnum.Blue;
            Balloon balloon = new Balloon(color);
            char expected = 'O';
            char actual = balloon.GetBalloonChar();
            Assert.AreEqual(expected, actual);
        }
    }
}
