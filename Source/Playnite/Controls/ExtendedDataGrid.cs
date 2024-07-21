using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Playnite.Controls
{
    public class ExtendedDataGrid : DataGrid
    {
        static ExtendedDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedDataGrid), new FrameworkPropertyMetadata(typeof(ExtendedDataGrid)));
        }

        public ExtendedDataGrid()
        {
            SelectionChanged += ExtendedDataGrid_SelectionChanged;
        }

        private void ExtendedDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItemsList = (IList<object>)SelectedItems;
        }

        public IList<object> SelectedItemsList
        {
            get
            {
                return (IList<object>)GetValue(SelectedItemsListProperty);
            }

            set
            {
                SetValue(SelectedItemsListProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
           DependencyProperty.Register(
               nameof(SelectedItemsList),
               typeof(IList<object>),
               typeof(ExtendedDataGrid),
               new PropertyMetadata(null));
    }
}
