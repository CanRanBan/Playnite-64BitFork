using System.ComponentModel;

namespace Playnite.SDK.Models
{
    /// <summary>
    /// Represents game installation status.
    /// </summary>
    public enum InstallationStatus : int
    {
        /// <summary>
        /// Game is installed.
        /// </summary>
        [Description("LOCGameIsInstalledTitle")]
        Installed = 0,

        /// <summary>
        /// Game is not installed.
        /// </summary>
        [Description("LOCGameIsUnInstalledTitle")]
        Uninstalled = 1
    }
}
