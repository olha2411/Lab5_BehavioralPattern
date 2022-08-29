using System;

namespace OrderSystem.States
{
    public class PaidState : State
    {
        public PaidState(Order order) : base(order) { }

        public override void UpdateState()
        {
            Order.ChangeState(new AllowedShipmentState(Order));
        }

        public override string ToString() => "Paid";
    }
}
