using RomaniaMea.Models;
using System.Collections.Generic;

namespace RomaniaMea.API.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string ShoppingCartId { get; set; }
        public IShoppingCartService ShoppingCartService { get; set; }
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public int ShoppingCartItemsTotal { get; set; }
    }
}
