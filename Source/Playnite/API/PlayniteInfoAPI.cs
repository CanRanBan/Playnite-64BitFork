using Playnite.SDK;

namespace Playnite.API
{
    public class PlayniteInfoAPI : IPlayniteInfoAPI
    {
        public System.Version ApplicationVersion { get => Updater.CurrentVersion; }

        public ApplicationMode Mode => PlayniteApplication.Current.Mode;

        public bool IsPortable => PlayniteSettings.IsPortable;

        public bool InOfflineMode => PlayniteEnvironment.InOfflineMode;

        public bool IsDebugBuild => PlayniteEnvironment.IsDebugBuild;

        public bool ThrowAllErrors => PlayniteEnvironment.ThrowAllErrors;
    }
}
