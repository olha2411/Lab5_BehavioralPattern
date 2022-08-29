using System;
using System.Collections.Generic;
using OrderSystem.Observer;


namespace App
{
    public class ConsoleViewer
    {
        public void ShowInstructions()
        {
            Console.WriteLine("Keys:");
            Console.WriteLine("\tEnter - go on");
            Console.WriteLine("\tP - pay for order in the Client role");
            Console.WriteLine("\tR - receive an order in the Client role");
            Console.WriteLine("\tC - cancel an order in the Client role");
            Console.WriteLine("\tA - approve a shipment in the Storekeeper role");
            Console.WriteLine("\tD - delivery an order in the DeliveryMan role");
            Console.WriteLine();
        }

        public void ShowSubscriberNotifications(Subscriber subscriber)
        {
            if (!subscriber.HasNewNotifications) return;
            Console.WriteLine($"{subscriber} has new notifications");
            foreach (var notification in subscriber.ReadNotifications())
                Console.WriteLine($"\t{notification}");
        }

        public void ShowSubscribersNotifications(IEnumerable<Subscriber> subscribers)
        {
            foreach (var subscriber in subscribers)
                ShowSubscriberNotifications(subscriber);
        }

        public ConsoleKey ReadConsoleKey()
        {
            Console.Write("Please, enter the key to continue ... ");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            return key;
        }
    }
}
