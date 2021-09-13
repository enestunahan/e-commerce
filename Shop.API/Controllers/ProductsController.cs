using Microsoft.AspNetCore.Mvc;
using Shop.Business.Abstarct;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult>  GetAllProducts()
        {
            var products = await _productService.GetAll();
            return Ok(products); // return 200+data
        }


        // aşağıdaki şekilde de yazabiliriz fakat birden fazla get sorgumuz olduğu zaman mesela productları sadece 
        // id bilgisine göre değil name bilgisine göre getirmek istersek napıcaktık ? 
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var product = _productService.GetProduct(id);
        //    if(product != null)
        //    {
        //        return Ok(product); //return 200 + data
        //    }
        //    return NotFound(); // return 404
        //}

        [HttpGet]
        [Route("[action]/{name}")]  //api/Products/GetHotelByName/name
        public async Task<IActionResult>  GetProductByName(string name)
        {
            var product = await _productService.SearchProduct(name);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")] // api/Products/GetProductById
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            // controller api controller olduğu için kontrolleri kendisi otomatik yapıyor
            var createdProduct = await _productService.AddProductAsync(product);
            return CreatedAtAction("Get", new { id = createdProduct.ProductId }, createdProduct); // return 201 + data
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Put([FromBody] Product product)
        {
            if (_productService.GetProduct(product.ProductId) != null)
            {
               // _productService.ProductUpdate(product);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Product product)
        {
            if (_productService.GetProduct(product.ProductId) != null)
            {
                _productService.DeleteProduct(product);
                return Ok();
            }
            return NotFound();
        }



        // Bu aşağıda yazmış olduğumuz senaryo sadece pozitif durumlarda iş görür
        // mesela get metodunda veritabanında olmayan bir id değeri girdiğimizde bize 204 no content döner
        // fakat veritabanında böyle bir değer olmadığı için bize asıl dönmesi gereken değer 404 notfound olmalıdır
        //yada post işlemi yaparken eğer bilgiler null gelirse kullanıcıyı tekrar aynı sayfaya yönlendirmemiz gerekir
        // işte böyle şeyler yapmak içinde ıactionresult geri dönüş tipinin kullananacağız


        //[HttpGet]
        //public List<Product> Get()
        //{
        //   return _productService.GetAll();
        //}

        //[HttpGet("{id}")]
        //public Product Get(int id)
        //{
        //    return _productService.GetProduct(id);
        //}

        //[HttpPost]
        //public void Post([FromBody] Product product)
        //{
        //    _productService.AddProduct(product);
        //}

        //[HttpPut]
        //public void Put([FromBody] Product product)
        //{
        //    _productService.UpdateProdcut(product);
        //}

        //[HttpDelete]
        //public void Delete([FromBody] Product product)
        //{
        //    _productService.DeleteProduct(product);
        //}

    }
}
