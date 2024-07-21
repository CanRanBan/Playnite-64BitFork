using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Playnite.SDK;

namespace Playnite.Converters
{
    public class DockToStringConverter : MarkupExtension, IValueConverter
    {
        public static string GetString(Dock value)
        {
            switch (value)
            {
                case Dock.Left:
                    return ResourceProvider.GetString("LOCDockLeft");
                case Dock.Right:
                    return ResourceProvider.GetString("LOCDockRight");
                case Dock.Top:
                    return ResourceProvider.GetString("LOCDockTop");
                case Dock.Bottom:
                    return ResourceProvider.GetString("LOCDockBottom");
            }

            return "<UnknownDockMode>";
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return GetString((Dock)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
