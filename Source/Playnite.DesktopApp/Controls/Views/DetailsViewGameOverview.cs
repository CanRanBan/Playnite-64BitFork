﻿using System.Windows;
using Playnite.DesktopApp.ViewModels;
using Playnite.SDK;

namespace Playnite.DesktopApp.Controls.Views
{
    public class DetailsViewGameOverview : GameOverview
    {
        static DetailsViewGameOverview()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DetailsViewGameOverview), new FrameworkPropertyMetadata(typeof(DetailsViewGameOverview)));
        }

        public DetailsViewGameOverview() : base(DesktopView.Details)
        {
        }

        public DetailsViewGameOverview(DesktopAppViewModel mainModel) : base(DesktopView.Details, mainModel)
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
