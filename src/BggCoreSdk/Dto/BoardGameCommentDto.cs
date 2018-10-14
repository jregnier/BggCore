using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGameCommentDto
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("username")]
        public string UserName { get; set; }

        [XmlAttribute("rating")]
        public string Rating { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}