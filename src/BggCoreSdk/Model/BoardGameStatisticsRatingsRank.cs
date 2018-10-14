namespace BggCoreSdk.Model
{
    public class BoardGameStatisticsRatingsRank
    {
        public string Type { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public int Value { get; set; }

        public float BayesAverage { get; set; }
    }
}