using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class ProductListViewModel
    { 
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
