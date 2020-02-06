using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;

namespace RomaniaMeaShop.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "ManageProducts")]
        public IActionResult ManageProduct()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/ManageProduct");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var productObj = JsonConvert.DeserializeObject<IEnumerable<Product>>(product);
                return View(productObj);
            }
            else
            {
                return View(null);
            }
        }

        [Authorize(Policy = "ManageProducts")]
        public IActionResult AddProduct()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AddProduct");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var productObj = JsonConvert.DeserializeObject<ManageProductViewModel>(product);
                return View(productObj);
            }
            else
            {
                return View(null);
            }
        }

        [Authorize(Policy = "ManageProducts")]
        public IActionResult AddProductAction([FromForm]ManageProductViewModel manageProductViewModel)
        {
            var product = new Product
            {
                Name = manageProductViewModel.Product.Name,
                Description = manageProductViewModel.Product.Description,
                Price = manageProductViewModel.Product.Price,
                ImageUrl = manageProductViewModel.Product.ImageUrl,
                IsProductOfTheWeek = manageProductViewModel.Product.IsProductOfTheWeek,
                CategoryId = manageProductViewModel.Product.CategoryId
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AddProduct/" + product);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(product);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, 
                new StringContent( json, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                
                return View("Submit");
            }
            else
            {
                return RedirectToAction("AddProduct", "Management");
            }
        }

        [Authorize(Policy = "ManageProducts")]
        public IActionResult EditProduct(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/administration/EditProduct/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var productObj = JsonConvert.DeserializeObject<ManageProductViewModel>(product);
                return View(productObj);
            }
            else
            {
                return View(null);
            }
        }

        [Authorize(Policy = "ManageProducts")]
        public IActionResult EditProductAction([FromForm] ManageProductViewModel manageProductViewModel)
        {
            var product = new Product
            {
                Name = manageProductViewModel.Product.Name,
                Description = manageProductViewModel.Product.Description,
                Price = manageProductViewModel.Product.Price,
                ImageUrl = manageProductViewModel.Product.ImageUrl,
                IsProductOfTheWeek = manageProductViewModel.Product.IsProductOfTheWeek,
                CategoryId = manageProductViewModel.Product.CategoryId
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/EditProduct/" + product);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(product);
            HttpResponseMessage response = client.PutAsync(client.BaseAddress,
                new StringContent(json, Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return View("Submit");
            }
            else
            {
                return RedirectToAction("EditProduct", "Management");
            }
        }

        [Authorize(Policy = "ManageProducts")]
        public IActionResult DeleteProduct(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/DeleteProduct/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                return View("Submit");
            }
            else
            {
                return RedirectToAction("EditProduct", "Management");
            }
        }

        [Authorize(Policy = "ManageOrders")]
        public IActionResult AllOrders()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AllOrders");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var order = response.Content.ReadAsStringAsync().Result;
                var orderObj = JsonConvert.DeserializeObject<IEnumerable<MyOrderViewModel>>(order);

                var newOrder = new MyOrderViewModel();
                foreach(var orderr  in orderObj)
                {
                    orderr.OrderStates = newOrder.OrderStates;
                }
                
                return View(orderObj);
            }
            else
            {
                return View(null);
            }
        }

        public class OrderTemp
        {
            public string orderState;
        }

        [Authorize(Policy = "ManageOrders")]
        [HttpPost]
        public IActionResult SetOrderState(int id, string orderState)
        {
            var order = new Order
            {
                Id = id,
                OrderState = orderState
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/SetOrderState/" + order);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")); 
            var json = JsonConvert.SerializeObject(order, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress,
                content).Result;

            if (response.IsSuccessStatusCode)
            {
                return View("Submit");
            }
            else
            {
                return RedirectToAction("AllOrders", "Management");
            }
        }

        [Authorize(Policy = "ManageOrders")]
        public IActionResult EditOrderState(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/EditOrderState/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var order = response.Content.ReadAsStringAsync().Result;
                var orderObj = JsonConvert.DeserializeObject<MyOrderViewModel>(order);
                return View(orderObj);
            }
            else
            {
                return View(null);
            }
        }
    }
}