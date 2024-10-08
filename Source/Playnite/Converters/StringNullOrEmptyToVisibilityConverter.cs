﻿using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Playnite.Converters
{
    public class StringNullOrEmptyToVisibilityConverter : MarkupExtension, IValueConverter
    {
        enum Parameters
        {
            Normal, Inverted
        }

        public static StringNullOrEmptyToVisibilityConverter Instance { get; } = new StringNullOrEmptyToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var direction = parameter == null ? Parameters.Normal : (Parameters)Enum.Parse(typeof(Parameters), (string)parameter);
            if (direction == Parameters.Inverted)
            {
                return string.IsNullOrEmpty(value as string) ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return string.IsNullOrEmpty(value as string) ? Visibility.Collapsed : Visibility.Visible;
            }
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
