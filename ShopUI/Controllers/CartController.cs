using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Shop.Business.Abstarct;
using Shop.Entities.Concrete;
using ShopUI.Identity;
using ShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Controllers
{

    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        private IProductService _productService;
        private ICartItemService _cartItemService;
        private IAddressService _addressService;
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;
        private IMemoryCache _memoryCache;
        public CartController(ICartService cartService,
            UserManager<User> userManager,
            IProductService productService,
            ICartItemService cartItemService,
            IAddressService addressService,
            IOrderService orderService,
            IOrderItemService orderItemService,
            IMemoryCache memoryCache)
        {
            _cartService = cartService;
            _userManager = userManager;
            _productService = productService;
            _cartItemService = cartItemService;
            _addressService = addressService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetByUserIdCard(_userManager.GetUserId(User));
            var model = new CartViewModel
            {
                CartId = cart.Id,
                CartItemModels = cart.CartItems.Select(x => new CartItemModel()
                {
                    ProductId = x.Product.ProductId,
                    Price = x.Product.Price,
                    Name = x.Product.Name,
                    ImageUrl = x.Product.ImageUrl,
                    Quantity = x.Quantity

                }).ToList()
            };
            return View(model);
        }
        public JsonResult AddToCart(CartModel model)
        {
            var userid = _userManager.GetUserId(User);
            _cartService.AddToCard(userid, model.Quantity, model.ProductId);
            var product = _productService.GetProduct(model.ProductId);
            return Json(new { name = product.Name, quantity = model.Quantity });
        }

        public JsonResult DeleteFromCart(int productid)
        {
            var userid = _userManager.GetUserId(User);
            var cart = _cartService.GetByUserIdCard(userid);
            _cartItemService.DeleteFromCart(cart.Id, productid);
            return Json("");
        }

        [HttpGet]
        public async Task<IActionResult>  Order(int cartid)
        {
            var userid = _userManager.GetUserId(User);
            var cart = _cartService.GetByCartId(cartid);
            OrderViewModel model = new OrderViewModel
            {
                Addresses = await _addressService.Addresses(userid),
                OrderItemModels = cart.CartItems.Select(x => new OrderItemModel()
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Quantity

                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Order(OrderModel model)
        {
            var userid = _userManager.GetUserId(User);
            var cart = _cartService.GetByUserIdCard(userid);
            var result = true;
            foreach (var item in cart.CartItems)
            {
                result = _productService.ProductControlForOrder(item.Product.ProductId, item.Quantity);
                if (result == false)
                    break;
            }

            if (result == false)
            {
                // uyarı mesajı verilmeli
                return View("Index");
            }
            else
            {
                var order = new Order
                {                   
                    AddressId = model.Addressid,
                    UserId = userid,
                    OrderDate = DateTime.Now,
                };

                var addedorder = _orderService.AddOrder(order); 
                List<OrderItem> orderItems = cart.CartItems.Select(x => new OrderItem()
                {
                    ProductName = x.Product.Name,                  
                    ProductId = x.ProductId,
                    OrderId = addedorder.Id,
                    ProductImageUrl = x.Product.ImageUrl,
                    ProductPrice = x.Product.Price,
                    ProductQuantity = x.Quantity
                }).ToList();
                
                foreach (var item in orderItems)
                {
                    _orderItemService.Add(item);
                    _productService.ProductOrderUpdate(item.ProductId, item.ProductQuantity);
                    _cartItemService.DeleteFromCart(cart.Id, item.ProductId);
                }
            }
            return View();
        }

       

        [HttpPost]
        public JsonResult AddAddress(AddressModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ValidationMessageForAddress(model));
            }
            var userid = _userManager.GetUserId(User);
            var address = new Address
            {
                UserId = userid,
                AddressTitle = model.AddressTitle,
                OpenAddress = model.OpenAddress,
                County = model.County,
                District = model.District
            };
            var createAddress = _addressService.CreateAddress(address);
            return Json(createAddress);
        }
        public int CountCart()
        {
            var userid = _userManager.GetUserId(User);
            var cart = _cartService.GetByUserIdCard(userid);

            if(_memoryCache.TryGetValue("cartcount",out int cartsayi))
            {
                return cartsayi;
            }

            cartsayi = _cartService.GetTheCount(cart);
            MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions();
            memoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            _memoryCache.Set("cartcount", cartsayi, memoryCacheEntryOptions);
            return cartsayi;
        }

        public string ValidationMessageForAddress(AddressModel model)
        {
            var mesaj = "";
            if(model.AddressTitle == null)
            {
                mesaj += "Adres Başlığı Boş Olamaz";                
            }
            if (model.County == null)
            {               
                mesaj += "İl Bilgisi Boş Olamaz";
            }
            return mesaj;
        }
    }
}
