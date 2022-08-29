using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem.Observer
{
    internal class NotificationManager
    {
        private readonly List<SubscriberViewModel> _subscribers;

        internal NotificationManager()
        {
            _subscribers = new List<SubscriberViewModel>();
        }

        internal void Subscribe(Type state, Subscriber subscriber)
        {
            _subscribers.Add(new SubscriberViewModel()
            {
                Subscriber = subscriber,
                State = state,
            });
        }

        internal void Unsubscribe(Type state, Subscriber subscriber)
        {
            var item = _subscribers.FirstOrDefault(vm => vm.State == state && vm.Subscriber == subscriber);
            if(item != null) _subscribers.Remove(item);
        }

        internal void Notify(Type state, Order order)
        {
            var notification = new Notification()
            {
                Time = DateTimeOffset.Now,
                Message = $"Order #{order.Id} is updated to {order.State} state."
            };

            order.Client.ReceiveNotification(notification);

            foreach (var vm in _subscribers.Where(s => s.State == state))
                vm.Subscriber.ReceiveNotification(notification);
        }

        internal void NotifyClient(Order order, string message)
        {
            var notification = new Notification()
            {
                Time = DateTimeOffset.Now,
                Message = message
            };

            order.Client.ReceiveNotification(notification);
        }

        internal void NotifySubscribers(Type state, string message)
        {
            var notification = new Notification()
            {
                Time = DateTimeOffset.Now,
                Message = message
            };

            foreach (var vm in _subscribers.Where(s => s.State == state))
                vm.Subscriber.ReceiveNotification(notification);
        }
    }
}
