using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Playnite.Controls
{
    public class ExtendedListView : ListView
    {
        static ExtendedListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedListView), new FrameworkPropertyMetadata(typeof(ExtendedListView)));
        }

        public ExtendedListView()
        {
            SelectionChanged += ExtendedListView_SelectionChanged;
        }

        private void ExtendedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
               typeof(ExtendedListView),
               new PropertyMetadata(null));
    }
}
