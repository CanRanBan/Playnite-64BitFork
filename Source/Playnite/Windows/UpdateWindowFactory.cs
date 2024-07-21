﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playnite.Controls;

namespace Playnite.Windows
{
    public class UpdateWindowFactory : WindowFactory
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
