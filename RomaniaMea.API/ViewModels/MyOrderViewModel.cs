using Microsoft.AspNetCore.Mvc.Rendering;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RomaniaMea.API.ViewModels
{
    public class MyOrderViewModel
    {
        public int Id { get; set; }
        public OrderViewModel OrderPlaceDetails { get; set; }
        public decimal OrderTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime OrderPlacedTime { get; set; }
        public IEnumerable<MyProductOrderInfo> ProductOrderInfos { get; set; }
        public string OrderState { get; set; }

        public List<SelectListItem> OrderStates { get; set; } = new List<SelectListItem>
         {
             new SelectListItem { Value = "În așteptare", Text = "În așteptare"},
             new SelectListItem { Value = "În livrare", Text = "În livrare"},
             new SelectListItem { Value = "Livrată", Text = "Livrată"}
         };

    }

    public class MyProductOrderInfo
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
