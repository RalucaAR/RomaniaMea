using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RomaniaMea.Models
{
    public class ShoppingCartItem : BaseEntity
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemPrice { get; set; }

        [Required]
        [StringLength(255)]
        public string ShoppingCartCookie { get; set; }
    }
}
