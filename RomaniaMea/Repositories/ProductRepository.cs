using Microsoft.EntityFrameworkCore;
using RomaniaMea.Interfaces;
using RomaniaMea.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        protected RepositoryContext repositoryContext { get; set; }
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
