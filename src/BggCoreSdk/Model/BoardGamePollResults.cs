using System.Collections.Generic;

namespace BggCoreSdk.Model
{
    public class BoardGamePollResults
    {
        public int NumPlayers { get; set; }

        public List<BoardGamePollResult> ResultList { get; set; }
    }
}