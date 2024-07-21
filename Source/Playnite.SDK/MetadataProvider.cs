using System;
using Playnite.SDK.Models;

namespace Playnite.SDK
{
    /// <summary>
    /// Describes metadata provider for library games.
    /// </summary>
    public abstract class LibraryMetadataProvider : IDisposable
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Dispose()
        {
        }

        /// <summary>
        /// Gets metadata for specified games.
        /// </summary>
        /// <param name="game">Game to get data for.</param>
        /// <returns>Game metadata.</returns>
        public abstract GameMetadata GetMetadata(Game game);
    }
}
