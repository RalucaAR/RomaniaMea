using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RomaniaMea.Models;

namespace RomaniaMeaShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Product/ProductOfTheWeek");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var productObj = JsonConvert.DeserializeObject<IEnumerable<Product>>(product);
                return View(productObj);             
            } else
            {
                return View(null);
            }            
        }

        public IActionResult Privacy()
        {
            return View();
        }

   }
}
