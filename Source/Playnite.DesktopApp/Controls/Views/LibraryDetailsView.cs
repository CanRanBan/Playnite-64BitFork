using System.Windows;
using Playnite.Behaviors;
using Playnite.Common;
using Playnite.Converters;
using Playnite.DesktopApp.ViewModels;
using Playnite.SDK;

namespace Playnite.DesktopApp.Controls.Views
{
    public class LibraryDetailsView : BaseGamesView
    {
        static LibraryDetailsView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LibraryDetailsView), new FrameworkPropertyMetadata(typeof(LibraryDetailsView)));
        }

        public LibraryDetailsView() : base(DesktopView.Details)
        {
        }

        public LibraryDetailsView(DesktopAppViewModel mainModel) : base(DesktopView.Details, mainModel)
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (ListGames != null)
            {
                ScrollViewerBehaviours.SetCustomScrollEnabled(ListGames, true);
                BindingTools.SetBinding(ListGames,
                    ScrollViewerBehaviours.SensitivityProperty,
                    mainModel.AppSettings,
                    nameof(PlayniteSettings.DetailsViewScrollSensitivity));
                BindingTools.SetBinding(ListGames,
                    ScrollViewerBehaviours.SpeedProperty,
                    mainModel.AppSettings,
                    nameof(PlayniteSettings.DetailsViewScrollSpeed),
                    converter: new TicksToTimeSpanConverter());
                BindingTools.SetBinding(ListGames,
                    ScrollViewerBehaviours.SmoothScrollEnabledProperty,
                    mainModel.AppSettings,
                    nameof(PlayniteSettings.DetailsViewSmoothScrollEnabled));
            }
        }
    }
}
