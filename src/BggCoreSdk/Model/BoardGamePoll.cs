using System.Collections.Generic;

namespace BggCoreSdk.Model
{
    public class BoardGamePoll
    {
        internal BoardGamePoll()
        {
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public int TotalVotes { get; set; }

        public List<BoardGamePollResult> Results { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}