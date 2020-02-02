﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;
using RomaniaMea.Repositories;

namespace RomaniaMea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IShoppingCartService _shoppingCart;

        public ShoppingController(IRepositoryWrapper repositoryWrapper, IShoppingCartService shoppingCart)
        {
            _repositoryWrapper = repositoryWrapper;
            _shoppingCart = shoppingCart;
        }

        [Route("[action]/{id}")]
       // [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var selectedProduct = await _repositoryWrapper.Product.GetByIdAsync(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            var result = await _shoppingCart.AddToCartAsync(selectedProduct);
           // var shopping = await _shoppingCart.GetCartCountAndTotalAmmountAsync();

            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedProduct = await _repositoryWrapper.Product.GetByIdAsync(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            await _shoppingCart.RemoveFromCartAsync(selectedProduct);

            return Ok();
        }

        [Route("[action]")]
        //[HttpPost]
        public async Task<IActionResult> RemoveAllCart()
        {
            await _shoppingCart.ClearCartAsync();
            return Ok();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<ShoppingCartItems>> GetCartItems()
        {
           return await _shoppingCart.GetShoppingCartItemsAsync();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public string GetCartItemById()
        {
            return  _shoppingCart.Id;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Product> GetProductById(int id)
        {
            return await  _repositoryWrapper.Product.GetByIdAsync(id);
        }

    }
}