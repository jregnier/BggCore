using System.Collections.Generic;
using System.Xml.Serialization;

namespace BggCoreSdk.Dto
{
    [XmlRoot(Namespace = "", ElementName = "boardgames")]
    public class BoardGameListDto : IBggResponse
    {
        [XmlElement("boardgame")]
        public List<BoardGameDto> BoardGames { get; set; }
    }
}