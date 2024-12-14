using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniApp.DataAccess;
using MiniApp.BusinessLogic.Interfaces;
using MiniApp.Migrations;
using Microsoft.EntityFrameworkCore;
using MiniApp.BusinessLogic.Interfaces;

namespace MiniApp.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        public async Task AddOrderAsync(List<OrderItem> orderItems)
        {
            using var context = new RestaurantDbContext();
            var order = new Order
            {
                OrderItems = orderItems,
                TotalAmount = orderItems.Sum(oi => oi.MenuItem.Price * oi.Count),
                Date = DateTime.Now
            };

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            using var context = new RestaurantDbContext();
            var order = await context.Orders.FindAsync(orderId);
            if (order == null)
                throw new Exception("Order not found.");

            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            using var context = new RestaurantDbContext();
            return await context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            using var context = new RestaurantDbContext();
            return await context.Orders
                .Where(o => o.Date >= startDate && o.Date <= endDate)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByPriceIntervalAsync(decimal minAmount, decimal maxAmount)
        {
            using var context = new RestaurantDbContext();
            return await context.Orders
                .Where(o => o.TotalAmount >= minAmount && o.TotalAmount <= maxAmount)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByDateAsync(DateTime date)
        {
            using var context = new RestaurantDbContext();
            return await context.Orders
                .Where(o => o.Date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            using var context = new RestaurantDbContext();
            return await context.Orders
                .FindAsync(orderId);
        }
    }
}
