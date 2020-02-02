using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly RepositoryContext _context;
       // private readonly IRepositoryWrapper _repositoryWrapper;

        public string Id { get; set; }
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartObjects { get; set; }

        private ShoppingCartService(RepositoryContext context/*, IRepositoryWrapper repositoryWrapper*/)
        {
            _context = context;
            //_repositoryWrapper = repositoryWrapper;
        }

        public static ShoppingCartService GetCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var context = services.GetRequiredService<RepositoryContext>();

            var request = httpContext.Request;
            var response = httpContext.Response;

            var cardId = request.Cookies["CartId-cookie"] ?? Guid.NewGuid().ToString();

            response.Cookies.Append("CartId-cookie", cardId, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(2)
            });

            return new ShoppingCartService(context)
            {
                Id = cardId
            };
        }

        public async Task<int> AddToCartAsync(Product product, int quantity = 1)
        {
            return await AddOrRemoveCart(product, quantity);

        }

        public async Task<int> RemoveFromCartAsync(Product product)
        {
            return await AddOrRemoveCart(product, -1);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartObjectsAsync()
        {
            ShoppingCartObjects = ShoppingCartObjects ?? await _context.ShoppingCartItems
                .Where(e => e.ShoppingCartCookie == Id)
                .Include(e => e.Product)
                .ToListAsync();

            return ShoppingCartObjects;

        }

        public async Task<IEnumerable<ShoppingCartItems>> GetShoppingCartItemsAsync()
        {
            var shopCartItems = await _context.ShoppingCartItems
                .Where(e => e.ShoppingCartCookie == Id)
                .Include(e => e.Product)
                .ToListAsync();

            List<ShoppingCartItems> shopCartVm = new List<ShoppingCartItems>();

            foreach (var shop in shopCartItems)
            {
                shopCartVm.Add(new ShoppingCartItems
                {
                    ShoppingCartId = Id,
                    ProductId = shop.Product.Id,
                    ProductDescription = shop.Product.Description,
                    ProductName = shop.Product.Name,
                    ProductPrice = shop.Product.Price,
                    ProductUrl = shop.Product.ImageUrl,
                    ItemPrice = shop.Product.Price * shop.Quantity,
                    Quantity = shop.Quantity,
                    ProductIsProductOfTheWeek = shop.Product.IsProductOfTheWeek
                });
            }

            return shopCartVm;
        }

        public async Task ClearCartAsync()
        {
            var shoppingCartItems = _context
                .ShoppingCartItems
                .Where(s => s.ShoppingCartCookie == Id);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            ShoppingCartObjects = new List<ShoppingCartItem>() ; //reset
            await _context.SaveChangesAsync();
        }

        public async Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync()
        {
            var subTotal = ShoppingCartObjects?
                .Select(c => c.Product.Price * c.Quantity) ??
                await _context.ShoppingCartItems
                .Where(c => c.ShoppingCartCookie == Id)
                .Select(c => c.Product.Price * c.Quantity)
                .ToListAsync();

            return (subTotal.Count(), subTotal.Sum());
        }

        private async Task<int> AddOrRemoveCart(Product product, int quatity)
        {
            var shoppingCartItem = await _context.ShoppingCartItems
                            .SingleOrDefaultAsync(s => s.Product.Id == product.Id && s.ShoppingCartCookie == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartCookie = Id,
                    Product = product,
                    Quantity = 0
                };

                await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
            }

            shoppingCartItem.Quantity += quatity;

            if (shoppingCartItem.Quantity <= 0)
            {
                shoppingCartItem.Quantity = 0;
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            await _context.SaveChangesAsync();

            ShoppingCartItems = null; // Reset

            return await Task.FromResult(shoppingCartItem.Quantity);
        }

    }
}
