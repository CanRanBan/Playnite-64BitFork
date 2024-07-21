using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Playnite.Common;
using Playnite.Extensions.Markup;
using Playnite.Plugins;
using Playnite.SDK;

namespace Playnite
{
    public class ThemeManager
    {
        private static ILogger logger = LogManager.GetLogger();
        public static System.Version DesktopApiVersion => new System.Version("2.6.0");
        public static ThemeManifest CurrentTheme { get; private set; }
        public static ThemeManifest DefaultTheme { get; private set; }
        public const string DefaultDesktopThemeId = "Playnite_builtin_DefaultDesktop";
        public const string DefaultThemeDirName = "Default";

        public static System.Version GetApiVersion(ApplicationMode mode)
        {
            return DesktopApiVersion;
        }

        public static string GetThemeRootDir(ApplicationMode mode)
        {
            return "Desktop";
        }

        public static void SetCurrentTheme(ThemeManifest theme)
        {
            CurrentTheme = theme;
        }

        public static void SetDefaultTheme(ThemeManifest theme)
        {
            DefaultTheme = theme;
        }

        public static AddonLoadError ApplyTheme(Application app, ThemeManifest theme, ApplicationMode mode)
        {
            if (theme.Id.IsNullOrEmpty())
            {
                logger.Error($"Theme {theme.Name}, doesn't have ID.");
                return AddonLoadError.Unknown;
            }

            var apiVersion = DesktopApiVersion;
            if (!theme.ThemeApiVersion.IsNullOrEmpty())
            {
                var themeVersion = new Version(theme.ThemeApiVersion);
                if (themeVersion.Major != apiVersion.Major || themeVersion > apiVersion)
                {
                    logger.Error($"Failed to apply {theme.Name} theme, unsupported API version {theme.ThemeApiVersion}.");
                    return AddonLoadError.SDKVersion;
                }
            }

            var acceptableXamls = new List<string>();
            var defaultRoot = $"Themes/{mode.GetDescription()}/{DefaultTheme.DirectoryName}/";
            foreach (var dict in app.Resources.MergedDictionaries)
            {
                if (dict.Source.OriginalString.StartsWith(defaultRoot))
                {
                    acceptableXamls.Add(dict.Source.OriginalString.Replace(defaultRoot, "").Replace('/', '\\'));
                }
            }

            var allLoaded = true;
            foreach (var accXaml in acceptableXamls)
            {
                var xamlPath = Path.Combine(theme.DirectoryPath, accXaml);
                if (!File.Exists(xamlPath))
                {
                    continue;
                }

                try
                {
                    var xaml = Xaml.FromFile(xamlPath);
                }
                catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                {
                    logger.Error(e, $"Failed to load xaml {xamlPath}");
                    allLoaded = false;
                    break;
                }
            }

            if (!allLoaded)
            {
                return AddonLoadError.Unknown;
            }

            try
            {
                var cursorFile = ThemeFile.GetFilePath("cursor.cur");
                if (cursorFile.IsNullOrEmpty())
                {
                    cursorFile = ThemeFile.GetFilePath("cursor.ani");
                }

                if (!cursorFile.IsNullOrEmpty())
                {
                    Mouse.OverrideCursor = new Cursor(cursorFile, true);
                }
            }
            catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
            {
                logger.Error(e, "Failed to set custom mouse cursor.");
            }

            var themeRoot = $"Themes\\{mode.GetDescription()}\\{theme.DirectoryName}\\";
            // This is sad that we have to do this, but it fixes issues like #2328
            // We need to remove all loaded theme resources and reload them in specific order:
            //      default/1.xaml -> theme/1.xaml -> default/2.xaml -> theme/2.xaml etc.
            //
            // We can't just load custom theme files at the end or insert them in already loaded pool of resources
            // because styling with static references won't reload data from custom theme files.
            // That's why we also have to create new instances of default styles.
            foreach (var defaultRes in app.Resources.MergedDictionaries.ToList())
            {
                if (defaultRes.Source.OriginalString.StartsWith(defaultRoot))
                {
                    app.Resources.MergedDictionaries.Remove(defaultRes);
                }
            }

            foreach (var themeXamlFile in acceptableXamls)
            {
                var defaultPath = Path.Combine(PlaynitePaths.ThemesProgramPath, mode.GetDescription(), DefaultThemeDirName, themeXamlFile);
                var defaultXaml = Xaml.FromFile(defaultPath);
                if (defaultXaml is ResourceDictionary xamlDir)
                {
                    xamlDir.Source = new Uri(defaultPath, UriKind.Absolute);
                    app.Resources.MergedDictionaries.Add(xamlDir);
                }

                var xamlPath = Path.Combine(theme.DirectoryPath, themeXamlFile);
                if (!File.Exists(xamlPath))
                {
                    continue;
                }

                var xaml = Xaml.FromFile(xamlPath);
                if (xaml is ResourceDictionary themeDir)
                {
                    themeDir.Source = new Uri(xamlPath, UriKind.Absolute);
                    app.Resources.MergedDictionaries.Add(themeDir);
                }
                else
                {
                    logger.Error($"Skipping theme file {xamlPath}, it's not resource dictionary.");
                }
            }

            try
            {
                Localization.LoadAddonLocalization(theme.DirectoryPath);
            }
            catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
            {
                logger.Error(e, "Failed to load theme's localization files.");
                return AddonLoadError.Unknown;
            }

            return AddonLoadError.None;
        }

        public static IEnumerable<ThemeManifest> GetAvailableThemes()
        {
            foreach (var theme in GetAvailableThemes(ApplicationMode.Desktop))
            {
                yield return theme;
            }
        }

        public static List<ThemeManifest> GetAvailableThemes(ApplicationMode mode)
        {
            var modeDir = GetThemeRootDir(mode);
            var user = new List<BaseExtensionManifest>();
            var install = new List<BaseExtensionManifest>();

            var userPath = Path.Combine(PlaynitePaths.ThemesUserDataPath, modeDir);
            if (!PlayniteSettings.IsPortable && Directory.Exists(userPath))
            {
                foreach (var dir in Directory.GetDirectories(userPath))
                {
                    try
                    {
                        var descriptorPath = Path.Combine(dir, PlaynitePaths.ThemeManifestFileName);
                        if (File.Exists(descriptorPath))
                        {
                            var info = new FileInfo(descriptorPath);
                            var man = new ThemeManifest(descriptorPath);
                            if (!man.Id.IsNullOrEmpty())
                            {
                                user.Add(man);
                            }
                        }
                    }
                    catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                    {
                        logger.Error(e, $"Failed to load theme info {dir}");
                    }
                }
            }

            var programPath = Path.Combine(PlaynitePaths.ThemesProgramPath, modeDir);
            if (Directory.Exists(programPath))
            {
                foreach (var dir in Directory.GetDirectories(programPath))
                {
                    try
                    {
                        var descriptorPath = Path.Combine(dir, PlaynitePaths.ThemeManifestFileName);
                        if (File.Exists(descriptorPath))
                        {
                            var info = new FileInfo(descriptorPath);
                            var man = new ThemeManifest(descriptorPath);
                            if (!man.Id.IsNullOrEmpty())
                            {
                                if (user.Any(a => a.Id == man.Id))
                                {
                                    continue;
                                }
                                else
                                {
                                    install.Add(man);
                                }
                            }
                        }
                    }
                    catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                    {
                        logger.Error(e, $"Failed to load theme info {dir}");
                    }
                }
            }

            var result = new List<ThemeManifest>();
            result.AddRange(ExtensionFactory.DeduplicateExtList(user).Cast<ThemeManifest>());
            result.AddRange(ExtensionFactory.DeduplicateExtList(install).Cast<ThemeManifest>());
            return result;
        }
    }
}
