using System.Windows;
using System.Windows.Controls;

namespace Playnite.DesktopApp.Controls
{
    public class SortSettingsMenu : ContextMenu
    {
        private readonly PlayniteSettings settings;

        static SortSettingsMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SortSettingsMenu), new FrameworkPropertyMetadata(typeof(SortSettingsMenu)));
        }

        public SortSettingsMenu() : this(PlayniteApplication.Current?.AppSettings)
        {
        }

        public SortSettingsMenu(PlayniteSettings settings)
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

            ViewSettingsMenu.GenerateSortMenu(Items, settings);
        }
    }
}
