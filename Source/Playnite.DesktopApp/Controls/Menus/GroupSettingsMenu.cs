using System.Windows;
using System.Windows.Controls;

namespace Playnite.DesktopApp.Controls
{
    public class GroupSettingsMenu : ContextMenu
    {
        private readonly PlayniteSettings settings;

        static GroupSettingsMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GroupSettingsMenu), new FrameworkPropertyMetadata(typeof(GroupSettingsMenu)));
        }

        public GroupSettingsMenu() : this(PlayniteApplication.Current?.AppSettings)
        {
        }

        public GroupSettingsMenu(PlayniteSettings settings)
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

            ViewSettingsMenu.GenerateGroupMenu(Items, settings);
        }
    }
}
