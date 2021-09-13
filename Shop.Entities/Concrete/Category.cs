using Shop.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities.Concrete
{
   public class Category :IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; }
    }
}
