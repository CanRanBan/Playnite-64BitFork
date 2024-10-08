﻿using System.Collections.Generic;

namespace Playnite.SDK
{
    /// <summary>
    /// Describes addons API interface.
    /// </summary>
    public interface IAddons
    {
        /// <summary>
        /// Gets ID list of disabled addons.
        /// </summary>
        List<string> DisabledAddons { get; }

        /// <summary>
        /// Gets ID list of currently installed addons.
        /// </summary>
        List<string> Addons { get; }

        /// <summary>
        /// Gets list of currently loaded plugins.
        /// </summary>
        List<Plugins.Plugin> Plugins { get; }
    }
}
