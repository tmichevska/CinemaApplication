using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<ProductInShoppingCart> ProducstInShoppingCart { get; set; }
        
            
        public float TotalPrice { get; set; }
    }
}
