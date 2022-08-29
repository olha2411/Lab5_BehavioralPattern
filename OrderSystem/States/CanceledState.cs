namespace OrderSystem.States
{
    public class CanceledState : State
    {
        public CanceledState(Order order) : base(order) { }

        public override void UpdateState()
        {
            Order.NotificationManager.NotifyClient(Order, "Thanks.");
        }

        public override string ToString() => "Canceled";
    }
}
