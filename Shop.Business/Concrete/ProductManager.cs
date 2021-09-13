using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
       
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;           
        }

        public Product AddProduct(Product product)
        {
           return _productDal.Add(product);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productDal.CreateProductAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            _productDal.Delete(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return  await _productDal.GetList();
        }

        public List<Product> GetBestSeller()
        {
            return _productDal.BestSellers();
        }

        public Product GetProduct(int id)
        {
            return _productDal.Get(filter:x=>x.ProductId==id);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public async Task<List<Product>>  GetProductsByCategory(int categoryid)
        {
            return  await _productDal.GetProductsByCategory(categoryid);
        }

        public bool ProductControlForOrder(int productid, int quantity)
        {
            var product = GetProduct(productid);
            return product.Stock > quantity ? true : false;         
        }

        public void ProductOrderUpdate(int productid, int quantity)
        {
            var product = GetProduct(productid);
            product.Stock -= quantity;
            product.QuantitySold += quantity;
            _productDal.Update(product);
        }

       
        public async Task<List<Product>>  SearchProduct(string name)
        {
            return await _productDal.GetList(filter: x => x.Name.Contains(name));
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
