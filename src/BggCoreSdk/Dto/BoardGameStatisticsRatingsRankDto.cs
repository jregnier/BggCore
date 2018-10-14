using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameStatisticsRatingsRankDto
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("friendlyname")]
        public string FriendlyName { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("bayesaverage")]
        public string BayesAverage { get; set; }
    }
}