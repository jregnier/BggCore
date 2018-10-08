using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    public class BoardGamePollResultDto
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("numvotes")]
        public string NumVotes { get; set; }
    }
}