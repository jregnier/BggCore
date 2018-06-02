using BggCoreSdk.Dto;

namespace BggCoreSdk.Model
{
    /// <summary>
    /// Factory for creating models.
    /// </summary>
    internal interface IModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardGameSearch" /> class
        /// </summary>
        /// <param name="dtoObject">The Dto object to create the model from.</param>
        /// <returns>A new board game search.</returns>
         BoardGameSearch Create(BoardGameSearchDto dtoObject);
    }
}