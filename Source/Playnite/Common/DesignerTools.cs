using System.ComponentModel;

namespace System.Windows
{
    public class DesignerTools
    {
        private static bool? inDesignMode = null;

        public static bool IsInDesignMode
        {
            get
            {
                if (inDesignMode == null)
                {
                    inDesignMode = DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
                }

                return inDesignMode.Value;
            }
        }
    }
}
