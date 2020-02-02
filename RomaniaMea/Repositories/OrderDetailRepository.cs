using RomaniaMea.IRepositories;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomaniaMea.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }
    }
}
