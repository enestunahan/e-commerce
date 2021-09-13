using Shop.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Entities.Concrete
{
   public class CategoryProduct :IEntity
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Product")]
        public int ProdcutId { get; set; }
        public Product Product { get; set; }
    }
}
