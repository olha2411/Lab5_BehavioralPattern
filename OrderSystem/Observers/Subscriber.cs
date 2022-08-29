using System.Collections.Generic;
using System.Linq;

namespace OrderSystem.Observer
{
    public abstract class Subscriber
    {
        public string Name { get; set; }

        protected List<Notification> Notifications { get; }

        protected Subscriber()
        {
            Notifications = new List<Notification>();
        }

        internal void ReceiveNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public bool HasNewNotifications => Notifications.Any();

        public List<Notification> ReadNotifications()
        {
            var notifications = Notifications.ToList();
            Notifications.Clear();
            return notifications;
        }
    }
}
