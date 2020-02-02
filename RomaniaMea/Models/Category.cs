using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomaniaMea.Models
{
    [Table("Category")]
    public class Category : BaseEntity
    { 
        [Required(ErrorMessage = "Name type is required")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
