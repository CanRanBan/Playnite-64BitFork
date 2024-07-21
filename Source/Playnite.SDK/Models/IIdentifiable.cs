using System;

namespace Playnite.SDK.Models
{
    /// <summary>
    /// Desribes object identifiable by an id.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Gets unique object identifier.
        /// </summary>
        Guid Id { get; }
    }
}
