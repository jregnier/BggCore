using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameStatisticsDto
    {
        [XmlAttribute("page")]
        public string Page { get; set; }

        [XmlElement("ratings")]
        public BoardGameStatisticsRatingsDto Ratings { get; set; }
    }
}