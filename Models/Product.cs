using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Web.Models
{
    public class Product
    {[Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Rating { get; set; }
        public ICollection<ProductInShoppingCart> ProductsInShoppingCart { get; set; }

    }
}
