using Shop.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities.Concrete
{
  public class Product :IEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public int QuantitySold { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; }
    }
}
