﻿using System;
using System.ComponentModel;
using System.Windows.Controls;
using Playnite.SDK.Models;

namespace Playnite.SDK
{
    /// <summary>
    ///
    /// </summary>
    public enum PlaytimeImportMode
    {
        /// <summary>
        ///
        /// </summary>
        [Description("LOCSettingsPlaytimeImportModeAlways")]
        Always,
        /// <summary>
        ///
        /// </summary>
        [Description("LOCSettingsPlaytimeImportModeNewImportsOnly")]
        NewImportsOnly,
        /// <summary>
        ///
        /// </summary>
        [Description("LOCSettingsPlaytimeImportModeNever")]
        Never
    }

    /// <summary>
    /// Describes interface for completion status related settings.
    /// </summary>
    public interface ICompletionStatusSettingsApi
    {
        /// <summary>
        /// Gets ID of status to be assigned to newly added games.
        /// </summary>
        Guid DefaultStatus { get; }

        /// <summary>
        /// Gets ID of status to be assigned when a game is played for the first time.
        /// </summary>
        Guid PlayedStatus { get; }
    }

    /// <summary>
    /// Describes application settings API.
    /// </summary>
    public interface IPlayniteSettingsAPI
    {
        /// <summary>
        ///
        /// </summary>
        int Version { get; }

        /// <summary>
        ///
        /// </summary>
        int GridItemWidthRatio { get; }

        /// <summary>
        ///
        /// </summary>
        int GridItemHeightRatio { get; }

        /// <summary>
        ///
        /// </summary>
        bool FirstTimeWizardComplete { get; }

        /// <summary>
        ///
        /// </summary>
        bool DisableHwAcceleration { get; }

        /// <summary>
        ///
        /// </summary>
        bool AsyncImageLoading { get; }

        /// <summary>
        ///
        /// </summary>
        bool DownloadMetadataOnImport { get; }

        /// <summary>
        ///
        /// </summary>
        string DatabasePath { get; }

        /// <summary>
        ///
        /// </summary>
        bool MinimizeToTray { get; }

        /// <summary>
        ///
        /// </summary>
        bool CloseToTray { get; }

        /// <summary>
        ///
        /// </summary>
        bool EnableTray { get; }

        /// <summary>
        ///
        /// </summary>
        string Language { get; }

        /// <summary>
        ///
        /// </summary>
        bool UpdateLibStartup { get; }

        /// <summary>
        ///
        /// </summary>
        string DesktopTheme { get; }

        /// <summary>
        ///
        /// </summary>
        bool StartMinimized { get; }

        /// <summary>
        ///
        /// </summary>
        bool StartOnBoot { get; }

        /// <summary>
        ///
        /// </summary>
        [Obsolete("Use new PlaytimeImportMode property instead.")]
        bool ForcePlayTimeSync { get; }

        /// <summary>
        ///
        /// </summary>
        PlaytimeImportMode PlaytimeImportMode { get; }

        /// <summary>
        ///
        /// </summary>
        string FontFamilyName { get; }

        /// <summary>
        ///
        /// </summary>
        ///
        AgeRatingOrg AgeRatingOrgPriority { get; }

        /// <summary>
        ///
        /// </summary>
        bool SidebarVisible { get; }

        /// <summary>
        ///
        /// </summary>
        Dock SidebarPosition { get; }

        /// <summary>
        /// Gets completion status related settings.
        /// </summary>
        ICompletionStatusSettingsApi CompletionStatus { get; }

        /// <summary>
        /// Checks if game is added on import exclusion list.
        /// </summary>
        /// <param name="gameId">Game ID.</param>
        /// <param name="libraryId">Library plugin ID.</param>
        /// <returns>True if game is on exclusion list.</returns>
        bool GetGameExcludedFromImport(string gameId, Guid libraryId);
    }
}
