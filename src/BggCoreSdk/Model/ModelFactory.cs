using BggCoreSdk.Dto;

namespace BggCoreSdk.Model
{
    /// <inheritdoc />
    internal class ModelFactory : IModelFactory
    {
        /// <inheritdoc />
        public BoardGameSearch Create(BoardGameSearchDto dtoObject)
        {
            if (dtoObject == null)
            {
                return null;
            }

            return new BoardGameSearch()
            {
                Id = dtoObject.Id,
                Name = dtoObject.Name,
                YearPublished = dtoObject.YearPublished
            };
        }
    }
}