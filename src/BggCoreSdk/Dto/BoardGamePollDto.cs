using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGamePollDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("totalvotes")]
        public string TotalVotes { get; set; }

        [XmlElement("results")]
        public BoardGamePollResultsDto[] Results { get; set; }
    }
}