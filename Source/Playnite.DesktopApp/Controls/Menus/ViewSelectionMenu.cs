using System.Windows;
using System.Windows.Controls;

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
