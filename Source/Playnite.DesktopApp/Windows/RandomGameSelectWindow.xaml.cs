using Playnite.Controls;
using Playnite.Windows;

namespace Playnite.DesktopApp.Windows
{
    public class RandomGameSelectWindowFactory : WindowFactory
    {
        public override WindowBase CreateNewWindowInstance()
        {
            return new RandomGameSelectWindow();
        }
    }

    /// <summary>
    /// Interaction logic for RandomGameSelectWindow.xaml
    /// </summary>
    public partial class RandomGameSelectWindow : WindowBase
    {
        public RandomGameSelectWindow() : base()
        {
            InitializeComponent();
        }
    }
}
