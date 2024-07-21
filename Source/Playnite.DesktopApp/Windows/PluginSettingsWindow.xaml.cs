using Playnite.Controls;
using Playnite.Windows;

namespace Playnite.DesktopApp.Windows
{
    public class PluginSettingsWindowFactory : WindowFactory
    {
        public override WindowBase CreateNewWindowInstance()
        {
            return new PluginSettingsWindow();
        }
    }

    /// <summary>
    /// Interaction logic for PluginSettingsWindow.xaml
    /// </summary>
    public partial class PluginSettingsWindow : WindowBase
    {
        public PluginSettingsWindow()
        {
            InitializeComponent();
        }
    }
}
