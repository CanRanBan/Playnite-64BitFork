using System.Diagnostics;

namespace Playnite
{
    public class PlayniteProcess
    {
        public static long WorkingSetMemory
        {
            get => Process.GetCurrentProcess().WorkingSet64;
        }

        public static string Path
        {
            get => Process.GetCurrentProcess().MainModule.FileName;
        }

        public static string Cmdline
        {
            get => Process.GetCurrentProcess().GetCommandLine();
        }
    }
}
