using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private IAddressService _addressService;
        private IOrderService _orderService;
        public UserController(UserManager<User> userManager , IAddressService addressService , IOrderService orderService)
        {
            _userManager = userManager;
            _addressService = addressService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetUserAddressess()
        {
            var model = new UserAddressViewModel
            {
                Addresses = await _addressService.Addresses(_userManager.GetUserId(User))
            };
            return PartialView("~/Views/Shared/_userAddress.cshtml",model);
        }

       [HttpGet]
       public IActionResult AddUserAddress()
        {
            return View("~/Views/Shared/_userAddressAdd.cshtml");
        }

        public ActionResult AddUserAddress(UserAddressViewModel userAddress)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userid = _userManager.GetUserId(User);
            var address = new Address
            {
                UserId = userid,
                AddressTitle =userAddress.AddressTitle,
                County = userAddress.City,
                District = userAddress.District,
                OpenAddress = userAddress.OpenAddress,               
            };
            var createdaddress = _addressService.CreateAddress(address);
            return Json(createdaddress);
        }

        public ActionResult AddressDetail(int id)
        {
            var address = _addressService.GetAddress(id);
            return PartialView("~/Views/Shared/_userAddressDetail.cshtml", address);
        }

        public  ActionResult UpdateUserAddress(Address address)
        {
            address.UserId = _userManager.GetUserId(User);
            _addressService.UpdateAddress(address);
            return Json("");
        }

        public JsonResult DeleteUserAddress(int id)
        {
            var address = _addressService.GetAddress(id);
            _addressService.DeleteAddress(address);
            return Json(new { name =address.AddressTitle });
        }

        public IActionResult GetUserOrders()
        {
            var orders = _orderService.Orders(_userManager.GetUserId(User));
            var model = orders.Select(x =>
             
                  new UserOrderViewModel
                     {
                        Address = x.Address,
                        OrderId =x.Id,
                        OrderItems = x.OrderItems
                      }
             ).ToList();
            return View("~/Views/Shared/_userOrders.cshtml",model);
        }
    }
}
