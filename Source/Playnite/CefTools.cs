﻿using System.IO;
using CefSharp;
using CefSharp.Wpf;
using Playnite.Common;

namespace Playnite
{
    public class CefTools
    {
        public static bool IsInitialized { get; private set; }

        public static void ConfigureCef(bool enableLogs)
        {
            FileSystem.CreateDirectory(PlaynitePaths.BrowserCachePath);
            var settings = new CefSettings();
            settings.WindowlessRenderingEnabled = true;

            if (settings.CefCommandLineArgs.ContainsKey("disable-gpu"))
            {
                settings.CefCommandLineArgs.Remove("disable-gpu");
            }

            if (settings.CefCommandLineArgs.ContainsKey("disable-gpu-compositing"))
            {
                settings.CefCommandLineArgs.Remove("disable-gpu-compositing");
            }

            settings.CefCommandLineArgs.Add("disable-gpu", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-compositing", "1");

            // Use CefSharp from subfolder
            settings.BrowserSubprocessPath = Path.Combine(PlaynitePaths.ProgramPath, "Include", "CefSharp", "CefSharp.BrowserSubprocess.exe");
            settings.CachePath = PlaynitePaths.BrowserCachePath;
            settings.LocalesDirPath = Path.Combine(PlaynitePaths.ProgramPath, "Include", "CefSharp", "Locales");
            // Using resources directory would require additional robocopy commands.
            // settings.ResourcesDirPath = Path.Combine(PlaynitePaths.ProgramPath, "Include", "CefSharp", "Resources");
            settings.RootCachePath = PlaynitePaths.BrowserCachePath;

            settings.PersistSessionCookies = true;
            settings.LogFile = Path.Combine(PlaynitePaths.ConfigRootPath, "CefSharp.log");
            settings.LogSeverity = enableLogs ? LogSeverity.Error : LogSeverity.Disable;
            // Firefox user agent gives the best compatibility because some websites complain
            // about unsecure browser if we try to pretend to be Chrome (which is CefSharp's default).
            // Plugins can change this on an individual level anyways.
            settings.UserAgent = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:130.0) Gecko/20100101 Firefox/130.0 Playnite/{PlayniteApplication.CurrentVersion.ToString(2)}";
            IsInitialized = Cef.Initialize(settings);
        }

        public static void Shutdown()
        {
            Cef.Shutdown();
            IsInitialized = false;
        }
    }
}
