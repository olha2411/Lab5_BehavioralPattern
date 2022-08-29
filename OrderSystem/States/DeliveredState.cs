namespace OrderSystem.States
{
    public class DeliveredState : State
    {
        public DeliveredState(Order order) : base(order) { }

        public override void UpdateState()
        {
            Order.NotificationManager.NotifyClient(Order, "Please, receive your order in delivery point.");
        }

        public override string ToString() => "Delivered";
    }
}
