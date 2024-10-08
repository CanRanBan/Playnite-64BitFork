﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Playnite.Common;
using Playnite.DesktopApp.ViewModels;

namespace Playnite.DesktopApp.Controls.Views
{
    [TemplatePart(Name = "PART_Sidebar", Type = typeof(Sidebar))]
    [TemplatePart(Name = "PART_ContentView", Type = typeof(ContentControl))]
    public class MainWindow : Control
    {
        private readonly DesktopAppViewModel mainModel;
        private Sidebar Sidebar;
        private ContentControl ContentView;

        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow), new FrameworkPropertyMetadata(typeof(MainWindow)));
        }

        public MainWindow() : this(DesktopApplication.Current?.MainModel)
        {
        }

        public MainWindow(DesktopAppViewModel mainModel)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.mainModel = DesignMainViewModel.DesignIntance;
            }
            else if (mainModel != null)
            {
                this.mainModel = mainModel;
            }

            DataContext = this.mainModel;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Sidebar = Template.FindName("PART_Sidebar", this) as Sidebar;
            if (Sidebar != null)
            {
                BindingTools.SetBinding(Sidebar,
                    VisibilityProperty,
                    mainModel.AppSettings,
                    nameof(PlayniteSettings.ShowSidebar),
                    converter: new BooleanToVisibilityConverter());
            }

            ContentView = Template.FindName("PART_ContentView", this) as ContentControl;
            if (ContentView != null)
            {
                BindingTools.SetBinding(ContentView,
                    ContentControl.ContentProperty,
                    mainModel,
                    nameof(mainModel.ActiveView));
            }

            ControlTemplateTools.InitializePluginControls(
                mainModel.Extensions,
                Template,
                this,
                SDK.ApplicationMode.Desktop,
                mainModel,
                $"{nameof(DesktopAppViewModel.SelectedGameDetails)}.{nameof(GameDetailsViewModel.Game)}.{nameof(GameDetailsViewModel.Game.Game)}");
        }
    }
}
