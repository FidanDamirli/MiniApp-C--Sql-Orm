using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniApp.BusinessLogic.Interfaces;
using MiniApp.DataAccess;
using MiniApp.BusinessLogic.Interfaces;
using MiniApp.Migrations;
using Microsoft.EntityFrameworkCore;

namespace MiniApp.BusinessLogic.Services
{
    public class MenuService : IMenuService
    {
        public async Task AddMenuItemAsync(string name, decimal price, string category)
        {
            using var context = new RestaurantDbContext();
            if (context.MenuItems.Any(mi => mi.Name == name))
                throw new Exception("A menu item with the same name already exists.");

            var menuItem = new MenuItem { Name = name, Price = price, Category = category };
            await context.MenuItems.AddAsync(menuItem);
            await context.SaveChangesAsync();
        }

        public async Task EditMenuItemAsync(int id, string newName, decimal newPrice)
        {
            using var context = new RestaurantDbContext();
            var menuItem = await context.MenuItems.FindAsync(id);
            if (menuItem == null)
                throw new Exception("Menu item not found.");

            menuItem.Name = newName;
            menuItem.Price = newPrice;
            await context.SaveChangesAsync();
        }

        public async Task RemoveMenuItemAsync(int id)
        {
            using var context = new RestaurantDbContext();
            var menuItem = await context.MenuItems.FindAsync(id);
            if (menuItem == null)
                throw new Exception("Menu item not found.");

            context.MenuItems.Remove(menuItem);
            await context.SaveChangesAsync();
        }

        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            using var context = new RestaurantDbContext();
            return await context.MenuItems.ToListAsync();
        }

        public async Task<List<MenuItem>> GetMenuItemsByCategoryAsync(string category)
        {
            using var context = new RestaurantDbContext();
            return await context.MenuItems.Where(mi => mi.Category == category).ToListAsync();
        }

        public async Task<List<MenuItem>> GetMenuItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            using var context = new RestaurantDbContext();
            return await context.MenuItems.Where(mi => mi.Price >= minPrice && mi.Price <= maxPrice).ToListAsync();
        }

        public async Task<List<MenuItem>> SearchMenuItemsByNameAsync(string searchText)
        {
            using var context = new RestaurantDbContext();
            return await context.MenuItems
                .Where(mi => mi.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }
    }
}
