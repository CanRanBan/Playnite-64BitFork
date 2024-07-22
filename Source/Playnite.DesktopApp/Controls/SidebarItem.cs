using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Playnite.Common;
using Playnite.DesktopApp.ViewModels;

namespace Playnite.DesktopApp.Controls
{
    [TemplatePart(Name = "PART_ProgressStatus", Type = typeof(ProgressBar))]
    public class SidebarItem : Button
    {
        private ProgressBar ProgressStatus;

        static SidebarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SidebarItem), new FrameworkPropertyMetadata(typeof(SidebarItem)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            BindingTools.SetBinding(this,
                CommandProperty,
                nameof(SidebarWrapperItem.Command));
            BindingTools.SetBinding(this,
                ContentPresenter.ContentProperty,
                nameof(SidebarWrapperItem.IconObject));
            BindingTools.SetBinding(this,
                VisibilityProperty,
                nameof(SidebarWrapperItem.Visible),
                converter: new BooleanToVisibilityConverter());
            BindingTools.SetBinding(this,
                ToolTipProperty,
                nameof(SidebarWrapperItem.Title));

            ProgressStatus = Template.FindName("PART_ProgressStatus", this) as ProgressBar;
            if (ProgressStatus != null)
            {
                BindingTools.SetBinding(ProgressStatus,
                    RangeBase.MaximumProperty,
                    nameof(SidebarWrapperItem.ProgressMaximum));
                BindingTools.SetBinding(ProgressStatus,
                    RangeBase.ValueProperty,
                    nameof(SidebarWrapperItem.ProgressValue));
            }
        }
    }
}
