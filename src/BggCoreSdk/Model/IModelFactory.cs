using BggCoreSdk.Dto;

namespace BggCoreSdk.Model
{
    /// <summary>
    /// Factory for creating models.
    /// </summary>
    public interface IModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardGameSearch" /> class
        /// </summary>
        /// <param name="dtoObject">The Dto object to create the model from.</param>
        /// <returns>A new board game search.</returns>
        BoardGameSearch CreateBoardGameSearch(BoardGameDto dtoObject);

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardGame" /> class
        /// </summary>
        /// <param name="dtoObject">The Dto object to create the model from.</param>
        /// <returns>A new board game.</returns>
        BoardGame CreateBoardGame(BoardGameDto dtoObject);
    }
}