using Microsoft.AspNetCore.Mvc;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartService _shoppingCart;

        public ShoppingCartSummary(IShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ShoppingCartCountTotal = await _shoppingCart.GetCartCountAndTotalAmmountAsync();
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCartService = _shoppingCart,
                ShoppingCartItemsTotal = ShoppingCartCountTotal.ItemCount,
                ShoppingCartTotal = ShoppingCartCountTotal.TotalAmmount
            };
            return View(shoppingCartViewModel);
        }

    }
}
