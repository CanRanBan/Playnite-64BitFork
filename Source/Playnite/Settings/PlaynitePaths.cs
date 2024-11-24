using System;
using System.IO;
using System.Linq;
using Playnite.Common;
using Playnite.Native;
using Playnite.SDK;

namespace Playnite
{
    public class PlaynitePaths
    {
        public const string ExtensionManifestFileName = "extension.yaml";
        public const string ThemeManifestFileName = "theme.yaml";
        public const string PackedThemeFileExtention = ".pthm";
        public const string PackedExtensionFileExtention = ".pext";
        public const string EngLocSourceFileName = "en_US.xaml";

        public const string ThemeSlnFileName = "Theme.sln";
        public const string ThemeProjFileName = "Theme.csproj";
        public const string AppXamlFileName = "App.xaml";

        public const string ExtensionsDirName = "Extensions";
        public const string ExtensionsDataDirName = "ExtensionsData";
        public const string ThemesDirName = "Themes";
        public const string ConfigFileName = "Config.json";
        public const string WindowPositionsFileName = "WindowPositions.json";
        public const string LocalizationsDirName = "Localization";

        public static string SavedGamesPath { get; }
        public static string UserProgramDataPath { get; }
        public static string ProgramPath { get; }
        public static string ConfigRootPath { get; }
        public static string LocalizationsPath { get; }
        public static string DataCachePath { get; }

        public static string DesktopExecutablePath { get; }
        public static string PlayniteAssemblyPath { get; }
        public static string PlayniteSDKAssemblyPath { get; }
        public static string ExtensionsUserDataPath { get; }
        public static string ExtensionsProgramPath { get; }
        public static string ExtensionsDataPath { get; }
        public static string ExtensionQueueFilePath { get; }
        public static string AddonLicenseAgreementsFilePath { get; }
        public static string LocalizationsStatusPath { get; }
        public static string ThemesProgramPath { get; }
        public static string ThemesUserDataPath { get; }
        public static string UninstallerPath { get; }
        public static string BrowserCachePath { get; }
        public static string TempPath { get; }
        public static string LogPath { get; }
        public static string ConfigFilePath { get; }
        public static string WindowPositionsPath { get; }
        public static string BackupConfigFilePath { get; }
        public static string BackupWindowPositionsPath { get; }
        public static string ImagesCachePath { get; }
        public static string IconsCachePath { get; }
        public static string JitProfilesPath { get; }
        public static string EmulationDatabasePath { get; }
        public static string SafeStartupFlagFile { get; }
        public static string BackupActionFile { get; }
        public static string RestoreBackupActionFile { get; }

        public static bool IsPortable { get; }

        static PlaynitePaths()
        {
            SavedGamesPath = Shell32.GetKnownFolderPathForSavedGames();
            UserProgramDataPath = Path.Combine(SavedGamesPath, "Playnite");
            ProgramPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            IsPortable = PlayniteSettings.GetAppConfigBoolValue("PortableInstallation");
            ConfigRootPath = IsPortable ? ProgramPath : UserProgramDataPath;
            LocalizationsPath = Path.Combine(ProgramPath, LocalizationsDirName);
            DataCachePath = Path.Combine(ConfigRootPath, "Cache");

            DesktopExecutablePath = Path.Combine(ProgramPath, "Playnite.DesktopApp.exe");
            PlayniteAssemblyPath = Path.Combine(ProgramPath, "Playnite.dll");
            PlayniteSDKAssemblyPath = Path.Combine(ProgramPath, "Playnite.SDK.dll");
            ExtensionsUserDataPath = Path.Combine(ConfigRootPath, ExtensionsDirName);
            ExtensionsProgramPath = Path.Combine(ProgramPath, ExtensionsDirName);
            ExtensionsDataPath = Path.Combine(ConfigRootPath, ExtensionsDataDirName);
            ExtensionQueueFilePath = Path.Combine(ConfigRootPath, "extinstalls.json");
            AddonLicenseAgreementsFilePath = Path.Combine(ConfigRootPath, "licenseagreements.json");
            LocalizationsStatusPath = Path.Combine(LocalizationsPath, "locstatus.json");
            ThemesProgramPath = Path.Combine(ProgramPath, ThemesDirName);
            ThemesUserDataPath = Path.Combine(ConfigRootPath, ThemesDirName);

            BrowserCachePath = Path.Combine(ConfigRootPath, "BrowserCache");
            TempPath = Path.Combine(Path.GetTempPath(), "Playnite");
            LogPath = Path.Combine(ConfigRootPath, "Playnite.log");
            ConfigFilePath = Path.Combine(ConfigRootPath, ConfigFileName);
            WindowPositionsPath = Path.Combine(ConfigRootPath, WindowPositionsFileName);
            BackupConfigFilePath = Path.Combine(ConfigRootPath, "Backup", ConfigFileName);
            BackupWindowPositionsPath = Path.Combine(ConfigRootPath, "Backup", WindowPositionsFileName);
            ImagesCachePath = Path.Combine(DataCachePath, "Images");
            IconsCachePath = Path.Combine(DataCachePath, "Icons");
            JitProfilesPath = Path.Combine(ConfigRootPath, "JITProfiles");
            EmulationDatabasePath = Path.Combine(ProgramPath, "Emulation", "Database");
            SafeStartupFlagFile = Path.Combine(ConfigRootPath, "safestart.flag");
            BackupActionFile = Path.Combine(ConfigRootPath, "Backup.json");
            RestoreBackupActionFile = Path.Combine(ConfigRootPath, "restoreBackup.json");
        }

        public static string ExpandVariables(string inputString, string emulatorDir = null, bool fixSeparators = false)
        {
            if (string.IsNullOrEmpty(inputString) || !inputString.Contains('{'))
            {
                return inputString;
            }

            var result = inputString;
            if (!emulatorDir.IsNullOrEmpty())
            {
                emulatorDir = emulatorDir.Replace(ExpandableVariables.PlayniteDirectory, ProgramPath, StringComparison.Ordinal);
            }

            result = result.Replace(ExpandableVariables.PlayniteDirectory, ProgramPath, StringComparison.Ordinal);
            result = result.Replace(ExpandableVariables.EmulatorDirectory, emulatorDir, StringComparison.Ordinal);
            return fixSeparators ? Paths.FixSeparators(result) : result;
        }
    }
}
