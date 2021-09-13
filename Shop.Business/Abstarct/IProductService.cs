using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Abstarct
{
   public interface IProductService
    {
        Task<List<Product>>  GetAll();
        Task<List<Product>>  SearchProduct(string name);
        Product GetProductDetails(int id);
        Task<List<Product> > GetProductsByCategory(int categoryid);
        void DeleteProduct(Product product);
        Product GetProduct(int id);
        Product AddProduct(Product product);
        Task<Product> AddProductAsync(Product product);
        bool ProductControlForOrder(int productid, int quantity);
        List<Product> GetBestSeller();
        void ProductOrderUpdate(int productid, int quantity);
        void Update(Product product);
    }
}
