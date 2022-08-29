using System;

namespace OrderSystem.Observer
{
    public class Notification
    {
        public string Message { get; set; }

        public DateTimeOffset Time { get; set; }

        public override string ToString() => $"{Time.DateTime}  -  {Message}";
    }
}
