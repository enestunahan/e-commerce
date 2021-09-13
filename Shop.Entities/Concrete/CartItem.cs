﻿using Shop.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities.Concrete
{
   public class CartItem :IEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
       
    }
}
