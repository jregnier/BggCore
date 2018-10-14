using System.Collections.Generic;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Model;

namespace BggCoreSdk.Service
{
    /// <summary>
    /// Service for gettting information on a boardgame.
    /// </summary>
    public interface IBoardGameService : IBggQueryable<IBoardGameService, BoardGameQueryParameters>
    {
        /// <summary>
        /// Gets the boards games with the given identifiers.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        /// <returns>The games with the given identifiers.</returns>
        Task<Exceptional<IList<BoardGame>>> FindAsync(IList<string> ids);
    }
}