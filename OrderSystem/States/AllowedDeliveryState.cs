namespace OrderSystem.States
{
    public class AllowedDeliveryState : State
    {
        public AllowedDeliveryState(Order order) : base(order) { }

        public override void UpdateState()
        {
            Order.NotificationManager.NotifyClient(Order, "Please, wait for approval from DeliveryMan.");
            Order.NotificationManager.NotifySubscribers(typeof(AllowedShipmentState), 
                "Client waits for delivering by DeliveryMan.");
        }

        public override string ToString() => "Allowed Delivery";
    }
}
