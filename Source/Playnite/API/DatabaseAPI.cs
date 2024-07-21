﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Playnite.Database;
using Playnite.SDK;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;

namespace Playnite.API
{
    public class DatabaseAPI : IGameDatabaseAPI
    {
        private GameDatabase database;

#pragma warning disable CS0067
        public event EventHandler DatabaseOpened;
#pragma warning restore CS0067

        public IItemCollection<Game> Games => database.Games;
        public IItemCollection<Platform> Platforms => database.Platforms;
        public IItemCollection<Emulator> Emulators => database.Emulators;
        public IItemCollection<Genre> Genres => database.Genres;
        public IItemCollection<Company> Companies => database.Companies;
        public IItemCollection<Tag> Tags => database.Tags;
        public IItemCollection<Category> Categories => database.Categories;
        public IItemCollection<Series> Series => database.Series;
        public IItemCollection<AgeRating> AgeRatings => database.AgeRatings;
        public IItemCollection<Region> Regions => database.Regions;
        public IItemCollection<GameSource> Sources => database.Sources;
        public IItemCollection<GameFeature> Features => database.Features;
        public IItemCollection<GameScannerConfig> GameScanners => database.GameScanners;
        public IItemCollection<CompletionStatus> CompletionStatuses => database.CompletionStatuses;
        public IItemCollection<ImportExclusionItem> ImportExclusions => database.ImportExclusions;
        public IItemCollection<FilterPreset> FilterPresets => database.FilterPresets;

        public string DatabasePath
        {
            get => database?.DatabasePath;
        }

        public bool IsOpen
        {
            get => database?.IsOpen == true;
        }

        public DatabaseAPI(GameDatabase database)
        {
            this.database = database;
        }

        public string AddFile(string path, Guid parentId)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Cannot add file to database, file not found.");
            }

            return database.AddFile(path, parentId, false, CancellationToken.None);
        }

        public void SaveFile(string id, string path)
        {
            database.CopyFile(id, path);
        }

        public void RemoveFile(string id)
        {
            database.RemoveFile(id);
        }

        public IDisposable BufferedUpdate()
        {
            return database.BufferedUpdate();
        }

        public string GetFileStoragePath(Guid parentId)
        {
            return database.GetFileStoragePath(parentId);
        }

        public string GetFullFilePath(string databasePath)
        {
            return database.GetFullFilePath(databasePath);
        }

        public Game ImportGame(GameMetadata game)
        {
            return database.ImportGame(game);
        }

        public Game ImportGame(GameMetadata game, LibraryPlugin sourcePlugin)
        {
            return database.ImportGame(game, sourcePlugin.Id);
        }

        public void BeginBufferUpdate()
        {
            database.BeginBufferUpdate();
        }

        public void EndBufferUpdate()
        {
            database.EndBufferUpdate();
        }

        public bool GetGameMatchesFilter(Game game, FilterPresetSettings filterSettings)
        {
            return database.GetGameMatchesFilter(game, filterSettings, false);
        }

        public IEnumerable<Game> GetFilteredGames(FilterPresetSettings filterSettings)
        {
            return database.GetFilteredGames(filterSettings, false);
        }

        public bool GetGameMatchesFilter(Game game, FilterPresetSettings filterSettings, bool useFuzzyNameMatch)
        {
            return database.GetGameMatchesFilter(game, filterSettings, useFuzzyNameMatch);
        }

        public IEnumerable<Game> GetFilteredGames(FilterPresetSettings filterSettings, bool useFuzzyNameMatch)
        {
            return database.GetFilteredGames(filterSettings, useFuzzyNameMatch);
        }
    }
}
