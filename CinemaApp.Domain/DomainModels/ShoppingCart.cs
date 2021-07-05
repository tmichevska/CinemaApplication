using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DomainModels
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public string CinemsAppApplicationUser  { get; set; }

    public ICollection<ProductInShoppingCart> ProductsInShoppingCart { get; set; }


    }
}
