using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniApp.DataAccess;
using MiniApp.Migrations;

namespace MiniApp.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderAsync(List<OrderItem> orderItems);
        Task RemoveOrderAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByDateIntervalAsync(DateTime startDate, DateTime endDate);
        Task<List<Order>> GetOrdersByPriceIntervalAsync(decimal minAmount, decimal maxAmount);
        Task<List<Order>> GetOrdersByDateAsync(DateTime date);
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
