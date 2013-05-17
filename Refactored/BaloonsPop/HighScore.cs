﻿namespace BaloonsPop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            this.GetLastRecord();
            this.highScoreRecords.Add(new KeyValuePair<string, int>(playerName, playerResult));
        }

        public KeyValuePair<string, int> GetLastRecord()
        {
            return this.highScoreRecords.LastOrDefault();
        }

        public override string ToString()
        {
            this.SortResultsDescending();

            StringBuilder result = new StringBuilder();
            int printLimit = this.highScoreRecords.Count;
            if (this.highScoreRecords.Count > HighScorePrintLimit)
            {
                printLimit = 5;
            }

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

        private void SortResultsDescending()
        {
            this.highScoreRecords.OrderByDescending(record => record.Value).ThenBy(record => record.Key);
        }
    }
}
