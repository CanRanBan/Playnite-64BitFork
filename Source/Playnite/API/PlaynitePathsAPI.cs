using Playnite.SDK;

namespace Playnite.API
{
    public class PlaynitePathsAPI : IPlaynitePathsAPI
    {
        public bool IsPortable { get => PlayniteSettings.IsPortable; }

        public string ApplicationPath { get => PlaynitePaths.ProgramPath; }

        public string ConfigurationPath { get => PlaynitePaths.ConfigRootPath; }

        public string ExtensionsDataPath { get => PlaynitePaths.ExtensionsDataPath; }
    }
}
