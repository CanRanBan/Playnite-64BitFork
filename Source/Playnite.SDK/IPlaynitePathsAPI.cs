namespace Playnite.SDK
{
    /// <summary>
    /// Describes paths API.
    /// </summary>
    public interface IPlaynitePathsAPI
    {
        /// <summary>
        /// Gets value indicating whether the application is running in portable mode.
        /// </summary>
        bool IsPortable { get; }

        /// <summary>
        /// Gets Playnite's installation path.
        /// </summary>
        string ApplicationPath { get; }

        /// <summary>
        /// Gets path where Playnite's configuration is stored.
        /// </summary>
        string ConfigurationPath { get; }

        /// <summary>
        /// Gets path dedicated for plugins to store data.
        /// </summary>
        string ExtensionsDataPath { get; }
    }
}
