using RomaniaMea.IRepositories;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomaniaMea.Repositories
{
    public class ShoppingCartItemRepository : RepositoryBase<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
