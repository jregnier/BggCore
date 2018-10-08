using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class ValueIdentifierDto
    {
        [XmlAttribute("objectid")]
        public string Id { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}