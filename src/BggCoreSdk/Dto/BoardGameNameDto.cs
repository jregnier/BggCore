using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameNameDto
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("primary")]
        public bool IsPrimary { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}