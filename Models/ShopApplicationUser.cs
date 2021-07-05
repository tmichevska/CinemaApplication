using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Web.Models
{
    public class ShopApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }
    }
}
