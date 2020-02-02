
using RomaniaMea.Interfaces;
using RomaniaMea.IRepositories;
using System.Threading.Tasks;

namespace RomaniaMea.Repositories
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        IShoppingCartItemRepository ShoppingCartItem { get; }
        IFeedbackRepository Feedback { get; }
        Task SaveAsync();
    }
}
