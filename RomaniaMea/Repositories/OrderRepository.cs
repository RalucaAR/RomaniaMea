using RomaniaMea.IRepositories;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RomaniaMea.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }

        
    }
}
