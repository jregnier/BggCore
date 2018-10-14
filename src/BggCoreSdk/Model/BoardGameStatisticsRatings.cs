using System.Collections.Generic;

namespace BggCoreSdk.Model
{
    public class BoardGameStatisticsRatings
    {
        public float UsersRated { get; set; }

        public float Average { get; set; }

        public float BayesAverage { get; set; }

        public List<BoardGameStatisticsRatingsRank> Ranks { get; set; }

        public float StdDev { get; set; }

        public int Median { get; set; }

        public int Owned { get; set; }

        public int Trading { get; set; }

        public int Wanting { get; set; }

        public int Wishing { get; set; }

        public int NumComments { get; set; }

        public int NumWeights { get; set; }

        public float AverageWeight { get; set; }
    }
}