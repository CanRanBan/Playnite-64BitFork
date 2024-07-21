using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Playnite.Database;
using Playnite.SDK;
using Playnite.SDK.Models;

namespace Playnite.API
{
    public class CompletionStatusSettingsApi : ICompletionStatusSettingsApi
    {
        private readonly GameDatabase db;
        public CompletionStatusSettingsApi(GameDatabase database)
        {
            db = database;
        }

        public Guid DefaultStatus => db.GetCompletionStatusSettings().DefaultStatus;
        public Guid PlayedStatus => db.GetCompletionStatusSettings().DefaultStatus;
    }

    public class PlayniteSettingsAPI : IPlayniteSettingsAPI
    {
        private readonly PlayniteSettings settings;
        private readonly GameDatabase db;

        public int Version => settings.Version;
        public int GridItemWidthRatio => settings.GridItemWidthRatio;
        public int GridItemHeightRatio => settings.GridItemHeightRatio;
        public bool FirstTimeWizardComplete => settings.FirstTimeWizardComplete;
        public bool DisableHwAcceleration => settings.DisableHwAcceleration;
        public bool AsyncImageLoading => settings.AsyncImageLoading;
        public bool DownloadMetadataOnImport => settings.DownloadMetadataOnImport;
        public bool InstallSizeScanUseSizeOnDisk => settings.InstallSizeScanUseSizeOnDisk;
        public bool ScanLibInstallSizeOnLibUpdate => settings.ScanLibInstallSizeOnLibUpdate;
        public string DatabasePath => settings.DatabasePath;
        public bool MinimizeToTray => settings.MinimizeToTray;
        public bool CloseToTray => settings.CloseToTray;
        public bool EnableTray => settings.EnableTray;
        public string Language => settings.Language == "english" ? "en_US" : settings.Language;
        public bool UpdateLibStartup => settings.CheckForLibraryUpdates == LibraryUpdateCheckFrequency.OnEveryStartup;
        public string DesktopTheme => settings.Theme;
        public bool StartMinimized => settings.StartMinimized;
        public bool StartOnBoot => settings.StartOnBoot;
        public string FontFamilyName => settings.FontFamilyName;
        public AgeRatingOrg AgeRatingOrgPriority => settings.AgeRatingOrgPriority;
        public bool SidebarVisible => settings.ShowSidebar;
        public Dock SidebarPosition => settings.SidebarPosition;
        public ICompletionStatusSettingsApi CompletionStatus { get; }
        public bool ForcePlayTimeSync => false;
        public PlaytimeImportMode PlaytimeImportMode => settings.PlaytimeImportMode;

        public PlayniteSettingsAPI(PlayniteSettings settings, GameDatabase db)
        {
            this.settings = settings;
            this.db = db;
            CompletionStatus = new CompletionStatusSettingsApi(db);
        }

        public bool GetGameExcludedFromImport(string gameId, Guid libraryId)
        {
            if (gameId.IsNullOrEmpty() || libraryId == Guid.Empty)
            {
                throw new ArgumentNullException("gameId and libraryId must be specified.");
            }

            return db.ImportExclusions.Get(ImportExclusionItem.GetId(gameId, libraryId)) != null;
        }
    }
}
