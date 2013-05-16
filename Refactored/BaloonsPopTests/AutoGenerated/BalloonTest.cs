using BaloonsPop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaloonsPopTests
{
    
    
    /// <summary>
    ///This is a test class for BalloonTest and is intended
    ///to contain all BalloonTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BalloonTest
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
        ///A test for Balloon Constructor
        ///</summary>
        [TestMethod()]
        public void BalloonConstructorTest()
        {
            Color color = new Color(); // TODO: Initialize to an appropriate value
            Balloon target = new Balloon(color);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            Color color = new Color(); // TODO: Initialize to an appropriate value
            Balloon target = new Balloon(color); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.Clone();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBalloonChar
        ///</summary>
        [TestMethod()]
        public void GetBalloonCharTest()
        {
            Color color = new Color(); // TODO: Initialize to an appropriate value
            Balloon target = new Balloon(color); // TODO: Initialize to an appropriate value
            char expected = '\0'; // TODO: Initialize to an appropriate value
            char actual;
            actual = target.GetBalloonChar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pop
        ///</summary>
        [TestMethod()]
        public void PopTest()
        {
            Color color = new Color(); // TODO: Initialize to an appropriate value
            Balloon target = new Balloon(color); // TODO: Initialize to an appropriate value
            target.Pop();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
