using System.Collections.Generic;
using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    [XmlRoot(Namespace = "", ElementName = "boardgames")]
    public class BoardGameSearchListDto : IBggResponse
    {
        [XmlElement("boardgame")]
        public List<BoardGameSearchDto> BoardGames { get; set; }
    }
}