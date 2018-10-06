using BggCoreSdk.Dto;

namespace BggCoreSdk.Model
{
    public class BoardGameSearch
    {
        internal BoardGameSearch()
        {
        }

        public int Id { get; set; }

        public BoardGameName Name { get; set; }

        public int YearPublished { get; set; }
    }
}