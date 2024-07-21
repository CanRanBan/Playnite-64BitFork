using System.Windows.Controls;
using Playnite.DesktopApp.ViewModels;

namespace Playnite.DesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for LibraryStatistics.xaml
    /// </summary>
    public partial class LibraryStatistics : UserControl
    {
        public LibraryStatistics()
        {
            InitializeComponent();
        }

        public LibraryStatistics(StatisticsViewModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
