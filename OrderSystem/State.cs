using System;

namespace OrderSystem
{
    public abstract class State
    {
        protected Order Order;

        protected State(Order order)
        {
            Order = order;
        }

        public abstract void UpdateState();
    }
}
