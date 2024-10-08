﻿namespace Playnite.SDK
{
    /// <summary>
    /// Describes library client application.
    /// </summary>
    public abstract class LibraryClient
    {
        /// <summary>
        /// Gets value indicating whether the client is installed.
        /// </summary>
        public abstract bool IsInstalled { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Icon { get; }

        /// <summary>
        /// Open client application.
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// Shuts down client application
        /// </summary>
        public virtual void Shutdown()
        {
        }
    }
}
