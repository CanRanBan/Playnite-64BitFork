﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Playnite.Common;
using Playnite.DesktopApp.ViewModels;
using Playnite.SDK;

namespace Playnite.DesktopApp.Controls.Views
{
    [TemplatePart(Name = "PART_ButtonClose", Type = typeof(ButtonBase))]
    [TemplatePart(Name = "PART_ButtonDismissAll", Type = typeof(ButtonBase))]
    [TemplatePart(Name = "PART_ItemsMessages", Type = typeof(ItemsControl))]
    public class NotificationPanel : Control
    {
        private readonly DesktopAppViewModel mainModel;
        private ButtonBase ButtonClose;
        private ButtonBase ButtonDismissAll;
        private ItemsControl ItemsMessages;

        static NotificationPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationPanel), new FrameworkPropertyMetadata(typeof(NotificationPanel)));
        }

        public NotificationPanel() : this(DesktopApplication.Current?.MainModel)
        {
        }

        public NotificationPanel(DesktopAppViewModel mainModel)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.mainModel = DesignMainViewModel.DesignIntance;
            }
            else if (mainModel != null)
            {
                this.mainModel = mainModel;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ButtonClose = Template.FindName("PART_ButtonClose", this) as ButtonBase;
            if (ButtonClose != null)
            {
                ButtonClose.Command = mainModel.CloseNotificationPanelCommand;
            }

            ButtonDismissAll = Template.FindName("PART_ButtonDismissAll", this) as ButtonBase;
            if (ButtonDismissAll != null)
            {
                ButtonDismissAll.Command = mainModel.ClearMessagesCommand;
            }

            ItemsMessages = Template.FindName("PART_ItemsMessages", this) as ItemsControl;
            if (ItemsMessages != null)
            {
                if (!DesignerProperties.GetIsInDesignMode(this)) // Because of mainModel.App reference
                {
                    BindingTools.SetBinding(ItemsMessages,
                        ItemsControl.ItemsSourceProperty,
                        mainModel.App.Notifications,
                        nameof(INotificationsAPI.Messages));
                }
            }
        }
    }
}
