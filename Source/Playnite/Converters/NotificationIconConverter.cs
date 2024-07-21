using System;
using System.Windows.Data;
using System.Windows.Markup;
using Playnite.SDK;

namespace Playnite.Converters
{
    public class NotificationIconConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var icon = (NotificationType)value;

            switch (icon)
            {
                case NotificationType.Info:
                    return @"/Images/Icons/info.png";
                case NotificationType.Error:
                    return @"/Images/Icons/warn.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
