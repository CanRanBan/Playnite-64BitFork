using System.Windows.Input;

namespace Playnite.Commands
{
    public static class GenericCommands
    {
        public static RoutedUICommand ZoomInCmd
            = new RoutedUICommand("Zoom in view command", "ZoomInCmd", typeof(GenericCommands));
        public static RoutedUICommand ZoomOutCmd
            = new RoutedUICommand("zoom out view command", "ZoomOutCmd", typeof(GenericCommands));
        public static RoutedUICommand PlayGameCmd
            = new RoutedUICommand("play game command", "PlayGameCmd", typeof(GenericCommands));
        public static RoutedUICommand ShowDetailsCmd
            = new RoutedUICommand("show game details command", "ShowDetailsCmd", typeof(GenericCommands));
    }
}
