using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace Playnite.Converters
{
    public class NullToBoolConverter : MarkupExtension, IValueConverter
    {
        public static NullToBoolConverter Instance { get; } = new NullToBoolConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
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
