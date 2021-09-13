using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class ProductModel
    {
        public List<Category> Categories { get; set; }
        public List<Category> LinkedCategories { get; set; }
        public List<Category> UnLinkedCategories { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }            
    }
}
