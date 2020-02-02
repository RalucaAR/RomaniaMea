using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RomaniaMea.Models;
using RomaniaMea.Repositories;

namespace RomaniaMea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> ProductOfTheWeek()
        {
            var productOfTheWeek = await _repositoryWrapper.Product.GetByCondition(product => product.IsProductOfTheWeek == true);

            return productOfTheWeek;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> CeramicObject()
        {
            var ceramicObject = await _repositoryWrapper.Product.GetByCondition(product => product.Category.Name == "CeramicObject");

            return ceramicObject;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> WoodObject()
        {
            var woodObject = await _repositoryWrapper.Product.GetByCondition(product => product.Category.Name == "WoodObject");

            return woodObject;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> ReligionObject()
        {
            var religionObject = await _repositoryWrapper.Product.GetByCondition(product => product.Category.Name == "ReligionObject");

            return religionObject;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> TraditionalClothes()
        {
            var traditionalClothes = await _repositoryWrapper.Product.GetByCondition(product => product.Category.Name == "TraditionalClothes");

            return traditionalClothes;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Product>> Toys()
        {
            var toys = await _repositoryWrapper.Product.GetByCondition(product => product.Category.Name == "Toys");

            return toys;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Product> ProductDetail(int id)
        {

            var product = await _repositoryWrapper.Product.GetByIdAsync(id);

            return product;
        }
    }
}