﻿using System;
using System.IO;
using System.Linq;
using Playnite.Common;
using Playnite.SDK;
using YamlDotNet.Serialization;

namespace Playnite
{
    public class ThemeManifest : BaseExtensionManifest
    {
        public string ThemeApiVersion { get; set; }

        public ApplicationMode Mode { get; set; }

        [YamlIgnore]
        public bool IsBuiltInTheme { get; }

        [YamlIgnore]
        public bool IsCustomTheme => !IsBuiltInTheme;

        [YamlIgnore]
        public bool IsCompatible { get; } = false;

        public ThemeManifest()
        {
        }

        public ThemeManifest(string manifestPath)
        {
            var thm = Serialization.FromYaml<ThemeManifest>(File.ReadAllText(manifestPath));
            thm.CopyProperties(this, false);
            DescriptionPath = manifestPath;
            DirectoryPath = Path.GetDirectoryName(manifestPath);
            DirectoryName = Path.GetFileName(DirectoryPath);
            if (Mode == ApplicationMode.Desktop)
            {
                IsBuiltInTheme = BuiltinExtensions.BuiltinThemeIds.Contains(thm.Id);
            }
            else
            {
                IsBuiltInTheme = BuiltinExtensions.BuiltinThemeIds.Contains(thm.Id);
            }

            var apiVersion = ThemeManager.DesktopApiVersion;
            if (!ThemeApiVersion.IsNullOrEmpty())
            {
                var themeVersion = new Version(ThemeApiVersion);
                if (themeVersion.Major == apiVersion.Major && themeVersion <= apiVersion)
                {
                    IsCompatible = true;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
