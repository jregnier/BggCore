using System.Collections.Generic;

namespace BggCoreSdk.Dto
{
    internal class BoardGameSearchListDto : IBggResponse
    {
        public List<BoardGameSearchDto> BoardGames { get; set; }
    }
}