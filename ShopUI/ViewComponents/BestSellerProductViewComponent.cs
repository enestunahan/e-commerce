using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Caching.Memory;
using Shop.Business.Abstarct;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.ViewComponents
{
    public class BestSellerProductViewComponent :ViewComponent
    {
        private IProductService _productService;
        private IMemoryCache _memoryCache;

        public BestSellerProductViewComponent(IProductService productService,
            IMemoryCache memoryCache)
        {
            _productService = productService;
            _memoryCache = memoryCache;
        }
        public ViewViewComponentResult Invoke()
        {
            if(_memoryCache.TryGetValue("bestsellers", out List<Product> products))
            {
                return View(products);
            }
            products = _productService.GetBestSeller();
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            _memoryCache.Set("bestsellers", products, options);
            return View(products);
        }
    }
}
