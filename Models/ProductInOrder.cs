using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Web.Models
{
    public class ProductInOrder
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        [ForeignKey("OrdertId")]
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
