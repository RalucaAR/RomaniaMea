﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;

namespace RomaniaMeaShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //read cookie from IHttpContextAccessor  
            string cookieValueFromContext = HttpContext.Request.Cookies["CartId-cookie"];

            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:5001/api/Shopping/GetCartItems");
            cookieContainer.Add(client.BaseAddress, new Cookie("CartId-cookie", cookieValueFromContext));

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var shoppingCart =  await response.Content.ReadAsStringAsync();
                var shoppingCartObj = JsonConvert.DeserializeObject<IEnumerable<ShoppingCartItems>>(shoppingCart);

                var model = new ShoppingCartViewModel {
                    ShoppingCartItems = shoppingCartObj,
                    ShoppingCartId = cookieValueFromContext,
                    ShoppingCartItemsTotal = shoppingCartObj.Count(),
                    ShoppingCartTotal = shoppingCartObj.ToList().Sum(x => x.ItemPrice)
                    
                };
                return View(model);
            }
            else
            {
                return View(null);
            }
        }

        public Product GetProductById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Shopping/GetProductById/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var productObj = JsonConvert.DeserializeObject<Product>(product);
                return productObj;
            }
            else
            {
                return null;
            }
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            string cookieValueFromContext = HttpContext.Request.Cookies["CartId-cookie"];

            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:5001/api/Shopping/AddToCart/" + id);
            cookieContainer.Add(client.BaseAddress, new Cookie("CartId-cookie", cookieValueFromContext));
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var product = GetProductById(id);
            var shoppingCartObj = new ShoppingCartItem
            {
                Product = new Product
                {
                    Id = product.Id,
                    Price = product.Price,
                    Category = product.Category,
                    ImageUrl = product.ImageUrl,
                    IsProductOfTheWeek = product.IsProductOfTheWeek,
                    Name = product.Name,
                },
                Quantity = 1,
                ShoppingCartCookie = cookieValueFromContext,
                ItemPrice = product.Price
            };

            var json = JsonConvert.SerializeObject(shoppingCartObj);
            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, 
                                            new StringContent(json, Encoding.UTF8,  "application/json"));

            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult RemoveAllCart()
        {
            //read cookie from IHttpContextAccessor  
            string cookieValueFromContext = HttpContext.Request.Cookies["CartId-cookie"];

            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:5001/api/Shopping/RemoveAllCart");
            cookieContainer.Add(client.BaseAddress, new Cookie("CartId-cookie", cookieValueFromContext));

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress).Result;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveFromShoppingCart(int id)
        {
            //read cookie from IHttpContextAccessor  
            string cookieValueFromContext = HttpContext.Request.Cookies["CartId-cookie"];

            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:5001/api/Shopping/RemoveFromShoppingCart/" + id);
            cookieContainer.Add(client.BaseAddress, new Cookie("CartId-cookie", cookieValueFromContext));

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress).Result;

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}