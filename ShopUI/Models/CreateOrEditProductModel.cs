using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class CreateOrEditProductModel
    {
        public int[] CategoryID { get; set; }
        public int[] IdsToAdd { get; set; }
        public int[] IdsToRemove { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
