using RomaniaMea.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RomaniaMea.Models
{
    public interface IShoppingCartService
    {
        string Id { get; set; }
        IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
        IEnumerable<ShoppingCartItem> ShoppingCartObjects { get; set; }
        Task<int> AddToCartAsync(Product product, int qty = 1);
        Task ClearCartAsync();
        Task<IEnumerable<ShoppingCartItems>> GetShoppingCartItemsAsync();
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartObjectsAsync();
        Task<int> RemoveFromCartAsync(Product product);
        Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync();
    }
}