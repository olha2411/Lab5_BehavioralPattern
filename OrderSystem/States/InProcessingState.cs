namespace OrderSystem.States
{
    public class InProcessingState : State
    {
        public InProcessingState(Order order) : base(order) { }

        public override void UpdateState()
        {
            Order.NotificationManager.NotifyClient(Order, "Please, pay for your order to continue.");
            Order.NotificationManager.NotifySubscribers(typeof(InProcessingState), "Waiting for paying by client.");
        }

        public override string ToString() => "In Processing";
    }
}
