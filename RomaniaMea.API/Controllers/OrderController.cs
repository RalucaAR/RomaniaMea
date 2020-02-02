﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RomaniaMea.API.Services;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;

namespace RomaniaMea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;

        public OrderController(IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        [Route("[action]")]
       // [HttpPost]
        public async Task<IEnumerable<ShoppingCartItems>> Checkout()
        {
            return await _shoppingCartService.GetShoppingCartItemsAsync();

        }

        [Route("[action]/{order}")]
        [HttpPost]
        public async Task<IActionResult> CheckoutOrder(Order order)
        {
            var cartItems = await Checkout();

            if (cartItems?.Count() <= 0)
            {
                return NoContent();
            }
           
            await _orderService.CreateOrderAsync(order);
            await _shoppingCartService.ClearCartAsync();
            
            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IEnumerable<MyOrderViewModel>> MyOrder(string id)
        {

            var userId = id;
            return await _orderService.GetAllOrdersAsync(userId);
        }
    }
}