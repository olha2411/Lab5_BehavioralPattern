using System.Collections.Generic;
using OrderSystem.Entities;
using OrderSystem.Observer;
using OrderSystem.States;

namespace OrderSystem
{
    public class SystemContext
    {
        public List<Order> Orders { get; }

        public Storekeeper Storekeeper { get; }

        public DeliveryMan DeliveryMan { get; }

        internal NotificationManager NotificationManager { get; }

        public SystemContext()
        {
            Orders = new List<Order>();
            Storekeeper = new Storekeeper() { Name = "Storekeeper" };
            DeliveryMan = new DeliveryMan() { Name = "DeliveryMan" };

            NotificationManager = new NotificationManager();
            NotificationManager.Subscribe(typeof(AllowedShipmentState), Storekeeper);
            NotificationManager.Subscribe(typeof(AllowedDeliveryState), DeliveryMan);
        }
    }
}
