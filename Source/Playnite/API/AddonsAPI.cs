﻿using System.Collections.Generic;
using System.Linq;
using Playnite.Plugins;
using Playnite.SDK;
using Playnite.SDK.Plugins;

namespace Playnite.API
{
    public class AddonsAPI : IAddons
    {
        private readonly ExtensionFactory extensions;
        private readonly PlayniteSettings settings;

        public List<string> DisabledAddons => settings.DisabledPlugins.ToList();

        public List<string> Addons => ExtensionFactory.GetInstalledManifests().Select(a => a.Id).ToList();

        public List<Plugin> Plugins => extensions.Plugins.Select(a => a.Value.Plugin).ToList();

        public AddonsAPI(ExtensionFactory extensions, PlayniteSettings settings)
        {
            this.extensions = extensions;
            this.settings = settings;
        }
    }
}
