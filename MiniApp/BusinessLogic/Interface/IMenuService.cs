using System.Collections.Generic;
using System.Threading.Tasks;
using MiniApp.DataAccess;
using MiniApp.Migrations;

namespace MiniApp.BusinessLogic.Interfaces
{
    public interface IMenuService
    {
        Task AddMenuItemAsync(string name, decimal price, string category);
        Task EditMenuItemAsync(int id, string newName, decimal newPrice);
        Task RemoveMenuItemAsync(int id);
        Task<List<MenuItem>> GetAllMenuItemsAsync();
        Task<List<MenuItem>> GetMenuItemsByCategoryAsync(string category);
        Task<List<MenuItem>> GetMenuItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<MenuItem>> SearchMenuItemsByNameAsync(string searchText);
    }
}
