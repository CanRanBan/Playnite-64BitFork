using System;

namespace Playnite.SDK.Models
{
    /// <summary>
    /// Describes Series object.
    /// </summary>
    public class Series : DatabaseObject
    {
        /// <summary>
        /// Creates new instance of <see cref="Series"/>.
        /// </summary>
        public Series() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="Series"/>.
        /// </summary>
        /// <param name="name"></param>
        public Series(string name) : base()
        {
            Name = name;
        }

        /// <summary>
        /// Gets empty series.
        /// </summary>
        public static readonly Series Empty = new Series { Id = Guid.Empty, Name = string.Empty };
    }
}
