using System.Collections.Generic;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Model;

namespace BggCoreSdk.Service
{
    /// <summary>
    /// Service for dealing with the board game end point.
    /// </summary>
    public interface IBoardGameService : IBggQueryable<IBoardGameService, BoardGameSearchQueryParameters>
    {
        /// <summary>
        /// Performs a search for board games based on the given input.
        /// </summary>
        /// <returns>The collection of results.</returns>
        Task<Exceptional<IList<BoardGameSearch>>> SearchAsync();

        /// <summary>
        /// Gets the boards games with the given identifiers.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        /// <returns>The games with the given identifiers.</returns>
        Task<Exceptional<IList<BoardGame>>> FindAsync(IList<string> ids);
    }
}