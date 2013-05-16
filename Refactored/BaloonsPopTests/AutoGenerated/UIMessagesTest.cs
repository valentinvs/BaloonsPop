using BaloonsPop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaloonsPopTests
{
    
    
    /// <summary>
    ///This is a test class for UIMessagesTest and is intended
    ///to contain all UIMessagesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UIMessagesTest
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
        ///A test for Congratulations
        ///</summary>
        [TestMethod()]
        public void CongratulationsTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.Congratulations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnterRowCol
        ///</summary>
        [TestMethod()]
        public void EnterRowColTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.EnterRowCol();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GoodBye
        ///</summary>
        [TestMethod()]
        public void GoodByeTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.GoodBye();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Greetings
        ///</summary>
        [TestMethod()]
        public void GreetingsTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.Greetings();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HighScore
        ///</summary>
        [TestMethod()]
        public void HighScoreTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.HighScore();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IllegalMove
        ///</summary>
        [TestMethod()]
        public void IllegalMoveTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.IllegalMove();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InvalidCommand
        ///</summary>
        [TestMethod()]
        public void InvalidCommandTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.InvalidCommand();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InvalidMove
        ///</summary>
        [TestMethod()]
        public void InvalidMoveTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.InvalidMove();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PleaseEnterYourName
        ///</summary>
        [TestMethod()]
        public void PleaseEnterYourNameTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UIMessages.PleaseEnterYourName();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
