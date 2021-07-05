using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Web.Models
{
    public class ShoppingCartDto
    {
        public List<ProductInShoppingCart> ProducstInShoppingCart { get; set; }
        
            
        public float TotalPrice { get; set; }
    }
}
