﻿using System;
using Playnite.SDK.Events;

namespace Playnite.SDK
{
    /// <summary>
    /// Describes API for handling playnite:// URI.
    /// </summary>
    public interface IUriHandlerAPI
    {
        /// <summary>
        /// Registers new URI source.
        /// </summary>
        /// <param name="source">Source name.</param>
        /// <param name="handler">Method to be executed.</param>
        void RegisterSource(string source, Action<PlayniteUriEventArgs> handler);

        /// <summary>
        /// Removes registered source.
        /// </summary>
        /// <param name="source">Source name.</param>
        void RemoveSource(string source);
    }
}
