using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RomaniaMea.Models;

namespace RomaniaMeaShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CeramicObject()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Product/CeramicObject");

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

        public IActionResult WoodObject()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Product/WoodObject");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var rpoductObja = JsonConvert.DeserializeObject<IEnumerable<Product>>(product);
                return View(rpoductObja);
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult ReligionObject()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Product/ReligionObject");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var rpoductObja = JsonConvert.DeserializeObject<IEnumerable<Product>>(product);
                return View(rpoductObja);
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult TraditionalClothes()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Product/TraditionalClothes");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var rpoductObja = JsonConvert.DeserializeObject<IEnumerable<Product>>(product);
                return View(rpoductObja);
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult Toys()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Product/Toys");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsStringAsync().Result;
                var rpoductObja = JsonConvert.DeserializeObject<IEnumerable<Product>>(product);
                return View(rpoductObja);
            }
            else
            {
                return View(null);
            }
        }

    }
}