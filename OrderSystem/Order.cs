using OrderSystem.Entities;
using OrderSystem.Observer;
using OrderSystem.Results;
using OrderSystem.States;

namespace OrderSystem
{
    public class Order
    {
        public int Id { get; internal set; }

        public string Context { get; set; }

        public decimal Price { get; internal set; }

        public bool IsPaid { get; private set; }

        public State State { get; private set; }

        public Client Client { get; set; }

        internal NotificationManager NotificationManager { get; set; }

        public void ChangeState(State state)
        {
            State = state;
            NotificationManager.Notify(state.GetType(), this);
        }

        internal ActionResult MakePaid()
        {
            if (IsPaid)
                return new ActionResult()
                {
                    Message = "The order is already paid.",
                    Successful = false
                };

            if (State is not InProcessingState)
                return new ActionResult()
                {
                    Message = "The order can't be paid yet.",
                    Successful = false
                };

            IsPaid = true;
            return new ActionResult()
            {
                Message = "The operation is successful.",
                Successful = true
            };
        }

        public void Cancel()
        {
            if (!IsPaid) return;
            Client.ReceiveMoney(Price);
            IsPaid = false;
        }

        public override string ToString()
        {
            return $"#{Id} order - State : {State} - {Price} UAH - {Context}";
        }
    }
}
