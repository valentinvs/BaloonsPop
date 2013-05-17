namespace BaloonsPopTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaloonsPop;
    using System.Collections.Generic;


    [TestClass]
    public class HighScoreTests
    {
        [TestMethod]
        public void AddOneRecord()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);

            CollectionAssert.Contains(highScore.TopPlayers, new KeyValuePair<string, int>("Pesho", 25));
        }

        [TestMethod]
        public void AddDuplicatedRecordTest()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);
            highScore.AddResult("Pesho", 25);

            Assert.IsTrue(highScore.TopPlayers.Count == 2);
        }

        [TestMethod]
        public void AddFiveRecords()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);
            highScore.AddResult("Pesho", 20);
            highScore.AddResult("Gosho", 15);
            highScore.AddResult("Petkan", 26);
            highScore.AddResult("Jorkan", 18);

            Assert.IsTrue(highScore.TopPlayers.Count == 5);
        }

        [TestMethod]
        public void AddSixRecords()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);
            highScore.AddResult("Pesho", 20);
            highScore.AddResult("Gosho", 15);
            highScore.AddResult("Petkan", 26);
            highScore.AddResult("Jorkan", 18);
            highScore.AddResult("Jorkan", 18);

            Assert.AreEqual(5, highScore.TopPlayers.Count);
        }

        [TestMethod]
        public void AreRecordsSorted()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);
            highScore.AddResult("Pesho", 20);
            highScore.AddResult("Gosho", 15);
            highScore.AddResult("Petkan", 26);
            highScore.AddResult("Jorkan", 18);

            Assert.IsTrue(AreSortedDescending(highScore.TopPlayers));
        }

        [TestMethod]
        public void IsTopResult()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);
            highScore.AddResult("Pesho", 20);
            highScore.AddResult("Gosho", 15);
            highScore.AddResult("Petkan", 26);
            highScore.AddResult("Jorkan", 18);

            Assert.IsTrue(AreSortedDescending(highScore.TopPlayers));
        }

        [TestMethod]
        public void AddingNotTopResult()
        {
            HighScore highScore = new HighScore();
            highScore.AddResult("Pesho", 25);
            highScore.AddResult("Pesho", 20);
            highScore.AddResult("Gosho", 15);
            highScore.AddResult("Petkan", 26);
            highScore.AddResult("Jorkan", 18);
            highScore.AddResult("NotTopResult", 50);

            CollectionAssert.Contains(highScore.TopPlayers, new KeyValuePair<string, int>("NotTopResult", 50));
        }

        private bool AreSortedDescending(List<KeyValuePair<string, int>> records)
        {
            for (int index = 1; index < records.Count; index++)
            {
                if (records[index - 1].Value >= records[index].Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
