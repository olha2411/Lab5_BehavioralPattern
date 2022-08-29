namespace OrderSystem.States
{
    public class AcceptedState : State
    {
        public AcceptedState(Order order) : base(order) { }

        public override void UpdateState()
        {
            Order.ChangeState(new InProcessingState(Order));
        }

        public override string ToString() => "Accepted";
    }
}
