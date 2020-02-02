using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API.ViewModels
{
    public class ShoppingCartItems
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductId { get; set; }
        public string ProductUrl { get; set; }
        public bool ProductIsProductOfTheWeek { get; set; }
        public decimal ItemPrice { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
