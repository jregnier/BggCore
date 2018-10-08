using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameNameDto
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("primary")]
        public string IsPrimary { get; set; }

        [XmlAttribute("sortindex")]
        public string SortIndex { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}