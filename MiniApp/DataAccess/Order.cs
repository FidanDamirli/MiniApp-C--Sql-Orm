using System;
using System.Collections.Generic;

namespace MiniApp.DataAccess

{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
    }
}

