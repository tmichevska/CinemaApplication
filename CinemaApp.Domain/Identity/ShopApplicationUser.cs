
using CinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Identity
{
    public class CinemaAppApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }
    }
}
