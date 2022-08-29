using System;

namespace OrderSystem.Observer
{
    internal class SubscriberViewModel
    {
        internal Subscriber Subscriber { get; set; }

        internal Type State { get; set; }
    }
}
