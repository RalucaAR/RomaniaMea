using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomaniaMea.Models
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters!")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Price is required!")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { set; get; }

        [StringLength(1600, ErrorMessage = "Description can't be longer than 160 characters!")]
        public string Description { set; get; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        public bool IsProductOfTheWeek { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
