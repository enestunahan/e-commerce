﻿using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class CartItemModel
    {       
        public int ProductId { get; set; }
        public double Price { get; set; } 
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    } 
}
