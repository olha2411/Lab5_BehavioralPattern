using OrderSystem.Observer;
using OrderSystem.Results;
using OrderSystem.States;

namespace OrderSystem.Entities
{
    public class DeliveryMan : Subscriber
    {
        public ActionResult DeliveryOrder(Order order)
        {
            if (order.State is not AllowedDeliveryState)
                return new ActionResult()
                {
                    Message = "A state of the order is not Allowed Delivery.",
                    Successful = false
                };

            order.NotificationManager.NotifyClient(order, $"DeliveryMan had delivered the #{order.Id} order.");
            order.ChangeState(new DeliveredState(order));

            return new ActionResult()
            {
                Message = "The operation is successful.",
                Successful = true
            };
        }
    }
}
