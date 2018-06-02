using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    internal class BoardGameSearchDto
    {
        [XmlAttribute("objectid")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }
    }
}