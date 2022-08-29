namespace OrderSystem.States
{
    public class ReceivedState : State
    {
        public ReceivedState(Order order) : base(order) {}

        public override void UpdateState()
        {
            Order.NotificationManager.NotifySubscribers(typeof(ReceivedState), $"#{Order.Id} order has been received.");
        }

        public override string ToString() => "Received";
    }
}
