using AutoMapper;
using RomaniaMea.API.ViewModels;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API.Services
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();
        }
    }
}
