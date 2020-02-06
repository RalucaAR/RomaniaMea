using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;
using RomaniaMea.Repositories;

namespace RomaniaMea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(IRepositoryWrapper repositoryWrapper, UserManager<IdentityUser> userManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _userManager = userManager;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<MyOrderViewModel>> AllOrders()
        {
            var orders =  await _repositoryWrapper.Order.GetAllAsync();
            var allOrders = new List<MyOrderViewModel>();
                foreach (var order in orders)
                {
                var user = await _userManager.FindByIdAsync(order.UserId);
                    allOrders.Add(new MyOrderViewModel
                    {
                        Id = order.Id,
                        OrderPlacedTime = order.OrderPlacedTime,
                        OrderTotal = order.OrderTotal,
                        OrderPlaceDetails = new OrderViewModel
                        {
                            AddressLine1 = order.AddressLine1,
                            City = order.City,
                            Email = user.Email,
                            Name = user.UserName,
                            PhoneNumber = order.PhoneNumber
                        },
                        ProductOrderInfos = _repositoryWrapper.OrderDetail.GetByCondition(x => x.OrderId == order.Id)
                        .Result.Select(x => new MyProductOrderInfo
                        {
                            Name = x.ProductName,
                            Quantity = x.Quantity,
                            Price = x.Price
                        }),
                        OrderState = order.OrderState
                    });
                }

                return allOrders;
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> ManageProduct()
        {
            return await _repositoryWrapper.Product.GetAllAsync();
        }

        
        [Route("[action]")]
        [HttpGet]
        public async Task<ManageProductViewModel> AddProduct()
        {
            var category = await _repositoryWrapper.Category.GetAllAsync();
            return new ManageProductViewModel
            {
                Categories = category
            };
        }

        [Route("[action]/{product}")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Problem("Invalid action!");
            }
            await _repositoryWrapper.Product.CreateAsync(product);
            await _repositoryWrapper.SaveAsync();
            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ManageProductViewModel> EditProduct(int id)
        {
            var product = await _repositoryWrapper.Product.GetByIdAsync(id);
            var category = await _repositoryWrapper.Category.GetAllAsync();
            
            return new ManageProductViewModel
            {
                Categories = category,
                Product = product
            };
        }

        [Route("[action]/{product}")]
        [HttpPut]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Problem("Invalid action!");
            }
           var productById =  _repositoryWrapper.Product.AsNoTracking().FirstOrDefault(x => x.Name == product.Name);
            product.Id = productById.Id;
            _repositoryWrapper.Product.Update(product);
            await _repositoryWrapper.SaveAsync();

            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repositoryWrapper.Product.GetByIdAsync(id);
            _repositoryWrapper.Product.Delete(product);
            await _repositoryWrapper.SaveAsync();
            return Ok();
        }

        [Route("[action]/{order}")]
        [HttpPut]
        public async Task<IActionResult> SetOrderState(Order order)
        {
            var orderById = _repositoryWrapper.Order.AsNoTracking().FirstOrDefault(x => x.Id == order.Id);
            if (orderById != null)
            {
                orderById.OrderState = order.OrderState;
                _repositoryWrapper.Order.Update(orderById);
                await _repositoryWrapper.SaveAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<MyOrderViewModel> EditOrderState(int id)
        {
            var order = await _repositoryWrapper.Order.GetByIdAsync(id);
            var user = _userManager.FindByIdAsync(order.UserId).Result;

            return new MyOrderViewModel
            {
                Id = order.Id,
                OrderPlacedTime = order.OrderPlacedTime,
                OrderTotal = order.OrderTotal,
                OrderPlaceDetails = new OrderViewModel
                {
                    AddressLine1 = order.AddressLine1,
                    City = order.City,
                    Email = user.Email,
                    Name = user.UserName,
                    PhoneNumber = order.PhoneNumber
                },
                ProductOrderInfos = _repositoryWrapper.OrderDetail.GetByCondition(x => x.OrderId == order.Id)
                        .Result.Select(x => new MyProductOrderInfo
                        {
                            Name = x.ProductName,
                            Quantity = x.Quantity,
                            Price = x.Price
                        }),
                OrderState = order.OrderState

            };
        }
    }
}