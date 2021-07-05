using System.ComponentModel.DataAnnotations;
using CinemaApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DomainModels
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public CinemaAppApplicationUser OrderedBy { get; set; }

        public List<ProductInOrder> Products { get; set; }
    }
}
