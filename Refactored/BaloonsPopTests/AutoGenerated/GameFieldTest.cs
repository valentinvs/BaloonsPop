using BaloonsPop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaloonsPopTests
{
    
    
    /// <summary>
    ///This is a test class for GameFieldTest and is intended
    ///to contain all GameFieldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameFieldTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GameField Constructor
        ///</summary>
        [TestMethod()]
        public void GameFieldConstructorTest()
        {
            GameField target = new GameField();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for PopsEqualColoredBalloons
        ///</summary>
        [TestMethod()]
        public void PopsEqualColoredBalloonsTest()
        {
            GameField target = new GameField(); // TODO: Initialize to an appropriate value
            int row = 0; // TODO: Initialize to an appropriate value
            int col = 0; // TODO: Initialize to an appropriate value
            Balloon selectedBalloon = null; // TODO: Initialize to an appropriate value
            target.PopsEqualColoredBalloons(row, col, selectedBalloon);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PrintToConsole
        ///</summary>
        [TestMethod()]
        public void PrintToConsoleTest()
        {
            GameField target = new GameField(); // TODO: Initialize to an appropriate value
            target.PrintToConsole();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateBalloonsPositions
        ///</summary>
        [TestMethod()]
        public void UpdateBalloonsPositionsTest()
        {
            GameField target = new GameField(); // TODO: Initialize to an appropriate value
            target.UpdateBalloonsPositions();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BallonsCount
        ///</summary>
        [TestMethod()]
        public void BallonsCountTest()
        {
            GameField target = new GameField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.BallonsCount = expected;
            actual = target.BallonsCount;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ClearedCellsCount
        ///</summary>
        [TestMethod()]
        public void ClearedCellsCountTest()
        {
            GameField target = new GameField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ClearedCellsCount = expected;
            actual = target.ClearedCellsCount;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
