using System.Windows;
using Playnite.DesktopApp.ViewModels;
using Playnite.SDK;

namespace Playnite.DesktopApp.Controls.Views
{
    public class GridViewGameOverview : GameOverview
    {
        static GridViewGameOverview()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GridViewGameOverview), new FrameworkPropertyMetadata(typeof(GridViewGameOverview)));
        }

        public GridViewGameOverview() : base(DesktopView.Grid)
        {
        }

        public GridViewGameOverview(DesktopAppViewModel mainModel) : base(DesktopView.Grid, mainModel)
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
