using System;
namespace Practico1.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Address { get; set; }
        public int PurchaseNumber { get; set; }
        public int Price { get; set; }
        public DateTime DeliveryDateTime { get; set; }
    }
}

