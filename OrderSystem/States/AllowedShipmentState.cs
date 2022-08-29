namespace OrderSystem.States
{
    public class AllowedShipmentState : State
    {
        public AllowedShipmentState(Order order) : base(order) { }
        public override void UpdateState()
        {
            Order.NotificationManager.NotifyClient(Order, "Please, wait for approval from Storekeeper.");
            Order.NotificationManager.NotifySubscribers(typeof(AllowedShipmentState), 
                "Client waits for approval by Storekeeper.");
        }

        public override string ToString() => "Allowed Shipment";
    }
}
