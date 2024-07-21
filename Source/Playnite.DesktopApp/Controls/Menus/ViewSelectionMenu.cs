﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Playnite.Common;
using Playnite.Converters;
using Playnite.Extensions.Markup;
using Playnite.SDK;
using Playnite.Settings;
using Playnite.ViewModels;

namespace Playnite.DesktopApp.Controls
{
    public class ViewSelectionMenu : ContextMenu
    {
        private readonly PlayniteSettings settings;

        static ViewSelectionMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewSelectionMenu), new FrameworkPropertyMetadata(typeof(ViewSelectionMenu)));
        }

        public ViewSelectionMenu() : this(PlayniteApplication.Current?.AppSettings)
        {
        }

        public ViewSelectionMenu(PlayniteSettings settings)
        {
            this.settings = settings;
            InitializeItems();
            Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            StaysOpen = false;
        }

        public void InitializeItems()
        {
            if (settings == null)
            {
                return;
            }
        }
    }
}
