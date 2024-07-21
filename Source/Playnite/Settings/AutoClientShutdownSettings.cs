using System;
using System.Collections.Generic;

namespace Playnite
{
    public class AutoClientShutdownSettings : ObservableObject
    {
        private uint graceTimeout = 60;
        public uint GraceTimeout
        {
            get => graceTimeout;
            set
            {
                graceTimeout = value;
                OnPropertyChanged();
            }
        }

        private uint minimalSessionTime = 120;
        public uint MinimalSessionTime
        {
            get => minimalSessionTime;
            set
            {
                minimalSessionTime = value;
                OnPropertyChanged();
            }
        }

        private bool shutdownClients = false;
        public bool ShutdownClients
        {
            get => shutdownClients;
            set
            {
                shutdownClients = value;
                OnPropertyChanged();
            }
        }

        private List<Guid> shutdownPlugins = new List<Guid>();
        public List<Guid> ShutdownPlugins
        {
            get => shutdownPlugins;
            set
            {
                shutdownPlugins = value;
                OnPropertyChanged();
            }
        }
    }
}
