using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shop.Business.Abstarct;
using Shop.Entities.Concrete;
using ShopUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Controllers
{
    public class HomeController : Controller
    {      
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IMemoryCache _memoryCache;
        public HomeController(IProductService productService ,ICategoryService categoryService , IMemoryCache memoryCache)
        {           
            _productService = productService;
            _categoryService = categoryService;
            _memoryCache = memoryCache;
        }

        public async Task<List<Category>> Categories()
        {
            if(_memoryCache.TryGetValue("categories", out List<Category> categories))
            {
                return categories;
            }
            categories = await _categoryService.GetAll();
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            _memoryCache.Set("categories", categories, options);
            return categories;
        }

        public async Task<IActionResult>  Index(int id)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = id==0 ? await _productService.GetAll() : await _productService.GetProductsByCategory(id),
                Categories = await Categories()
            };
            return View(model);
        }


        public async Task<IActionResult>  ProductsGetByCategory(int id)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = await _productService.GetProductsByCategory(id),             
            };
            return PartialView("~/Views/Shared/_product.cshtml",model);
        }

        public IActionResult ProductDetail(int id)
        {
            Product product = _productService.GetProductDetails(id);
            ProductDetail model = new ProductDetail()
            {
                Product = product,
                Categories = product.CategoryProducts.Select(x=>x.Category).ToList()
            };
            return View(model);
        }

       
        public async Task<IActionResult>  Search(string searchvalue)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = await _productService.SearchProduct(searchvalue)
            };
            return PartialView("~/Views/Shared/_product.cshtml", model);
        }


    }
}
