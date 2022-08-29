using OrderSystem.Observer;
using OrderSystem.Results;
using OrderSystem.States;

namespace OrderSystem.Entities
{
    public class Storekeeper : Subscriber
    {
        public ActionResult ApproveOrder(Order order)
        {
            if (order.State is not AllowedShipmentState)
                return new ActionResult()
                {
                    Message = "A state of the order is not Allowed Shipment.",
                    Successful = false
                };

            order.NotificationManager.NotifyClient(order, $"Storekeeper had approved the #{order.Id} order.");
            order.ChangeState(new AllowedDeliveryState(order));

            return new ActionResult()
            {
                Message = "The operation is successful.",
                Successful = true
            };
        }
    }
}
