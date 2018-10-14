using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameStatisticsRatingsDto
    {
        [XmlElement("usersrated")]
        public string UsersRated { get; set; }

        [XmlElement("average")]
        public string Average { get; set; }

        [XmlElement("bayesaverage")]
        public string BayesAverage { get; set; }

        [XmlArray("ranks")]
        [XmlArrayItem("rank")]
        public BoardGameStatisticsRatingsRankDto[] Ranks { get; set; }

        [XmlElement("stddev")]
        public string StdDev { get; set; }

        [XmlElement("median")]
        public string Median { get; set; }

        [XmlElement("owned")]
        public string Owned { get; set; }

        [XmlElement("trading")]
        public string Trading { get; set; }

        [XmlElement("wanting")]
        public string Wanting { get; set; }

        [XmlElement("wishing")]
        public string Wishing { get; set; }

        [XmlElement("numcomments")]
        public string NumComments { get; set; }

        [XmlElement("numweights")]
        public string NumWeights { get; set; }

        [XmlElement("averageweight")]
        public string AverageWeight { get; set; }
    }
}