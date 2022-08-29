using System;
using System.Collections.Generic;
using OrderSystem;
using OrderSystem.Entities;
using OrderSystem.Observer;
using OrderSystem.Repositories;
using OrderSystem.Results;
using OrderSystem.States;


namespace App
{
    class Program
    {
        public static Dictionary<ConsoleKey, Func<Order, ActionResult>> Keys =
            new Dictionary<ConsoleKey, Func<Order, ActionResult>>();

        public static void Main(string[] args)
        {
            var context = new SystemContext();
            var repository = new OrderRepository(context);

            var client = new Client() { Name = "Olya" };
            client.ReceiveMoney(10000);

            var storekeeper = context.Storekeeper;
            var deliveryMan = context.DeliveryMan;

            repository.CreateOrder(new Order()
            {
                Client = client,
                Context = "Something that I want to buy."
            });

            var currentOrder = repository.CurrentOrderByClient(client);

            var subscribers = new List<Subscriber>()
            {
                client, storekeeper, deliveryMan
            };

            var viewer = new ConsoleViewer();

            viewer.ShowInstructions();

            Keys.Add(ConsoleKey.P, order => client.PayForOrder(order));
            Keys.Add(ConsoleKey.R, order => client.ReceiveOrder(order));
            Keys.Add(ConsoleKey.C, order => client.CancelOrder(order));
            Keys.Add(ConsoleKey.A, order => storekeeper.ApproveOrder(order));
            Keys.Add(ConsoleKey.D, order => deliveryMan.DeliveryOrder(order));

            while (currentOrder.State is not (ReceivedState or CanceledState))
            {
                viewer.ShowSubscribersNotifications(subscribers);

                var key = viewer.ReadConsoleKey();

                if (key == ConsoleKey.Enter) currentOrder.State.UpdateState();

                if (Keys.ContainsKey(key))
                {
                    var result = Keys[key].Invoke(currentOrder);
                    if (!result.Successful) Console.WriteLine($"  Error: {result.Message}");
                }
            }

            viewer.ShowSubscribersNotifications(subscribers);
        }
    
    }
}
