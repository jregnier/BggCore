using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameSearchDto
    {
        [XmlAttribute("objectid")]
        public int Id { get; set; }

        [XmlElement("name")]
        public BoardGameNameDto Name { get; set; }

        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }
    }
}