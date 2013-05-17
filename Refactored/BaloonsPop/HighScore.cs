﻿namespace BaloonsPop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HighScore
    {
        private const int HighScorePrintLimit = 5;
        private readonly List<KeyValuePair<string, int>> highScoreRecords;

        public HighScore()
        {
            this.highScoreRecords = new List<KeyValuePair<string, int>>();
        }

        public List<KeyValuePair<string, int>> TopPlayers
        {
            get
            {
                return this.highScoreRecords;
            }
        }

        public void AddResult(string playerName, int playerResult)
        {
            if (this.TopPlayers.Count >= 5)
            {
                KeyValuePair<string, int> lastRecord = this.GetLastRecord();
                this.highScoreRecords.Remove(lastRecord);
            }

            this.highScoreRecords.Add(new KeyValuePair<string, int>(playerName, playerResult));

            this.TopPlayers.Sort(DescendingComparer);
        }

        static int DescendingComparer(KeyValuePair<string, int> firstPair, KeyValuePair<string, int> secondPair)
        {
            return firstPair.Value.CompareTo(secondPair.Value);
        }

        public bool IsTopResult(int playerMoveCount)
        {
            if (this.TopPlayers.Count < 5 ||
                playerMoveCount <= this.GetLastRecord().Value)
            {
                return true;
            }

            return false;
        }

        public KeyValuePair<string, int> GetLastRecord()
        {
            return this.highScoreRecords.LastOrDefault();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int printLimit = this.highScoreRecords.Count;

            for (int index = 0; index < printLimit; index++)
            {
                string playerName = this.highScoreRecords[index].Key;
                string playerResult = this.highScoreRecords[index].Value.ToString();

                result.Append(playerName).Append("->").AppendLine(playerResult);

                if (index >= HighScorePrintLimit)
                {
                    break;
                }
            }

            result.Append(Environment.NewLine);
            return result.ToString();
        }
    }
}
