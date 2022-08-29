using OrderSystem.Observer;
using OrderSystem.Results;
using OrderSystem.States;

namespace OrderSystem.Entities
{
    public class Client : Subscriber
    {
        public decimal Balance { get; private set; }

        public void ReceiveMoney(decimal value)
        {
            Balance += value;
        }

        public ActionResult PayForOrder(Order order)
        {
            if (order is null)
                return new ActionResult()
                {
                    Message = "Order can't be null.",
                    Successful = false
                };

            if (Balance < order.Price)
                return new ActionResult()
                {
                    Message = "Your balance is less than the order price.",
                    Successful = false
                };

            if (order.State is not InProcessingState)
                return new ActionResult()
                {
                    Message = "A state of the order is not In Processing.",
                    Successful = false
                };

            Balance -= order.Price;

            var result = order.MakePaid();

            if (result.Successful) order.ChangeState(new PaidState(order));
            else return result;

            return new ActionResult()
            {
                Message = "The operation is successful.",
                Successful = true
            };
        }

        public ActionResult ReceiveOrder(Order order)
        {
            if (order is null)
                return new ActionResult()
                {
                    Message = "An order can't be null.",
                    Successful = false
                };
            if (order.State is not DeliveredState)
                return new ActionResult()
                {
                    Message = "A state of the order is not Delivered.",
                    Successful = false
                };

            order.ChangeState(new ReceivedState(order));
            return new ActionResult()
            {
                Message = "The operation is successful.",
                Successful = true
            };
        }

        public ActionResult CancelOrder(Order order)
        {
            if (order is null)
                return new ActionResult()
                {
                    Message = "An order can't be null.",
                    Successful = false
                };

            order.Cancel();
            order.ChangeState(new CanceledState(order));
            return new ActionResult()
            {
                Message = "The operation is successful.",
                Successful = true
            };
        }
    }
}
