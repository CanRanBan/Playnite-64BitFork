using System;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace Playnite.Extensions
{
    public static class IProvideValueTargetExtensions
    {
        public static Type GetTargetType(IProvideValueTarget provider)
        {
            if (provider.TargetProperty == null)
            {
                return null;
            }

            var type = provider.TargetProperty.GetType();
            if (type == typeof(DependencyProperty))
            {
                type = ((DependencyProperty)provider.TargetProperty).PropertyType;
            }
            else if (typeof(PropertyInfo).IsAssignableFrom(provider.TargetProperty.GetType()))
            {
                type = ((PropertyInfo)provider.TargetProperty).PropertyType;
            }

            return type;
        }
    }
}
