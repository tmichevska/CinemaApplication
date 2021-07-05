﻿using CinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Product SelectedProduct  { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
       // public Product SelectedProduct { get; set; }
    }
}
