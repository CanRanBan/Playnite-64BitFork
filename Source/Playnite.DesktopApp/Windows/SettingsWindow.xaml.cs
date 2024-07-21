using Playnite.Controls;
using Playnite.Windows;

namespace Playnite.DesktopApp.Windows
{
    public class SettingsWindowFactory : WindowFactory
    {
        public override WindowBase CreateNewWindowInstance()
        {
            return new SettingsWindow();
        }
    }

    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class SettingsWindow : WindowBase
    {
        private WindowPositionHandler positionManager;

        public SettingsWindow() : base(nameof(SettingsWindow), true)
        {
            InitializeComponent();
            if (PlayniteApplication.Current.AppSettings != null)
            {
                positionManager = new WindowPositionHandler(this, "SettingsWindow", PlayniteApplication.Current.AppSettings.WindowPositions);
            }
        }
    }
}
