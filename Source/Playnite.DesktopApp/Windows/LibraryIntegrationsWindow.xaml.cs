using Playnite.Controls;
using Playnite.Windows;

namespace Playnite.DesktopApp.Windows
{
    public class LibraryIntegrationsWindowFactory : WindowFactory
    {
        public override WindowBase CreateNewWindowInstance()
        {
            return new LibraryIntegrationsWindow();
        }
    }

    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class LibraryIntegrationsWindow : WindowBase
    {
        public LibraryIntegrationsWindow() : base("LibraryIntegrationsWindow_V2")
        {
            InitializeComponent();
        }
    }
}
