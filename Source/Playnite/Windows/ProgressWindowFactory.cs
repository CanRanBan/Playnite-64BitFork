using System;
using Playnite.Controls;

namespace Playnite.Windows
{
    public class ProgressWindowFactory : WindowFactory
    {
        public static Type WindowType { get; private set; }

        public static void SetWindowType<TType>() where TType : WindowBase
        {
            WindowType = typeof(TType);
        }

        public override WindowBase CreateNewWindowInstance()
        {
            return WindowType.CrateInstance<WindowBase>();
        }
    }
}
