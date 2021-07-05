using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DomainModels
{
    public class ProductInShoppingCart
    {
       
        public int ProductId { get; set; }
        public int CartId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
