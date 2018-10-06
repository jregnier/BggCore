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
                Name = new BoardGameName() { Value = dtoObject.Name.Value, IsPrimary = dtoObject.Name.IsPrimary },
                YearPublished = dtoObject.YearPublished
            };
        }
    }
}