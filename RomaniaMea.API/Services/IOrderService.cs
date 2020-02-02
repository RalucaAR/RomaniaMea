using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync(string userId);
        Task CreateOrderAsync(Order order);
        
    }
}
