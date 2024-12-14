using System;
namespace MiniApp.DataAccess
{
    public class OrderItem
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
        public int Count { get; set; }
    }
}
