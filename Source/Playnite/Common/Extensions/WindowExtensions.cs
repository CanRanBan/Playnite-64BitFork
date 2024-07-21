using System.Windows.Forms;
using Playnite.Common;

namespace System.Windows
{
    public static class WindowExtensions
    {
        public static ComputerScreen GetScreen(this Window window)
        {
            return Screen.FromPoint(new System.Drawing.Point((int)window.Left, (int)window.Top)).ToComputerScreen();
        }
    }
}
