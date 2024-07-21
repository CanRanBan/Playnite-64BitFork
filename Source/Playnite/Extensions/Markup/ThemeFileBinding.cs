using System;
using Playnite.Converters;

namespace Playnite.Extensions.Markup
{
    public class ThemeFileBinding : BindingExtension
    {
        public string PathFormat { get; set; }

        public ThemeFileBinding() : this(null)
        {
        }

        public ThemeFileBinding(string path) : base(path)
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ServiceProvider.IsTargetTemplate(serviceProvider))
            {
                return this;
            }

            if (!PathFormat.IsNullOrEmpty() && !(Converter is GenericTypeConverter))
            {
                if (Converter != null)
                {
                    Converter = new GenericTypeConverter
                    {
                        StringFormat = ThemeFile.GetFilePath(PathFormat, false),
                        TestAsFilePath = true,
                        CustomConverter = Converter
                    };
                }
                else
                {
                    Converter = new GenericTypeConverter
                    {
                        StringFormat = ThemeFile.GetFilePath(PathFormat, false),
                        TestAsFilePath = true
                    };
                }
            }

            return base.ProvideValue(serviceProvider);
        }
    }
}
