﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Playnite.SDK;

namespace Playnite.API
{
    public class NotificationsAPI : ObservableObject, INotificationsAPI
    {
        public class MessageEventArgs : EventArgs
        {
            public NotificationMessage Message { get; }

            public MessageEventArgs(NotificationMessage message)
            {
                Message = message;
            }
        }

        private readonly SynchronizationContext context;

        public event EventHandler<MessageEventArgs> ActivationRequested;
        public event EventHandler<MessageEventArgs> CloseRequested;

        public ObservableCollection<NotificationMessage> Messages
        {
            get;
        }

        public int Count
        {
            get => Messages.Count;
        }

        public NotificationsAPI()
        {
            context = SynchronizationContext.Current;
            Messages = new ObservableCollection<NotificationMessage>();
        }

        private void Message_Activated(object sender, EventArgs e)
        {
            ActivationRequested(this, new MessageEventArgs(sender as NotificationMessage));
        }

        private void Message_Closed(object sender, EventArgs e)
        {
            CloseRequested(this, new MessageEventArgs(sender as NotificationMessage));
        }

        public void Add(NotificationMessage message)
        {
            context.Send((c =>
            {
                if (!Messages.Any(a => a.Id == message.Id))
                {
                    message.Activated += Message_Activated;
                    message.Closed += Message_Closed;
                    Messages.Add(message);
                    OnPropertyChanged(nameof(Count));
                }
            }), null);
        }

        public void Add(string id, string text, NotificationType type)
        {
            context.Send((c =>
            {
                if (!Messages.Any(a => a.Id == id))
                {
                    Add(new NotificationMessage(id, text, type));
                }
            }), null);
        }

        public void Remove(string id)
        {
            context.Send((c =>
            {
                var message = Messages.FirstOrDefault(a => a.Id == id);
                if (message != null)
                {
                    message.Activated -= Message_Activated;
                    message.Closed -= Message_Closed;
                    Messages.Remove(message);
                    OnPropertyChanged(nameof(Count));
                }
            }), null);
        }

        public void RemoveAll()
        {
            context.Send((c =>
            {
                foreach (var message in Messages)
                {
                    message.Activated -= Message_Activated;
                    message.Closed -= Message_Closed;
                }

                Messages.Clear();
                OnPropertyChanged(nameof(Count));
            }), null);
        }
    }
}
