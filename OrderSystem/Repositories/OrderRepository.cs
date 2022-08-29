using System;
using System.Collections.Generic;
using System.Linq;
using OrderSystem.Entities;
using OrderSystem.States;

namespace OrderSystem.Repositories
{
    public class OrderRepository
    {
        private readonly SystemContext _context;

        public OrderRepository(SystemContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order clientOrder)
        {
            var order = new Order()
            {
                Id = GetId(),
                Price = GeneratePrice(),
                Client = clientOrder.Client,
                Context = clientOrder.Context ?? string.Empty,
                NotificationManager = _context.NotificationManager
            };

            order.ChangeState(new AcceptedState(order));
            _context.Orders.Add(order);
        }

        public Order CurrentOrderByClient(Client client)
        {
            return _context.Orders.LastOrDefault(x => x.Client == client);
        }

        private decimal GeneratePrice() => new Random().Next(10, 50);

        private int GetId()
        {
            return _context.Orders.Any() ? _context.Orders.Max(o => o.Id) + 1 : 1;
        }
    }
}
