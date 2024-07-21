using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using NLog;
using Playnite;
using Playnite.Common;
using Playnite.Common.Web;
using Playnite.Database;
using Playnite.Settings;

namespace Playnite.Converters
{
    public class ImageStringToImageConverter : MarkupExtension, IValueConverter
    {
        public bool Cached { get; set; }

        public ImageStringToImageConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            var image = ImageSourceManager.GetImage((string)value, Cached);
            return image ?? DependencyProperty.UnsetValue;
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
