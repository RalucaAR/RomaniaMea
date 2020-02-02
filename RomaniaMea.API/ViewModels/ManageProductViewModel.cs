using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API.ViewModels
{
    public class ManageProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }

        public ManageProductViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
