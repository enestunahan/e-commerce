using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private ICategoryProductService _categoryProductService;

        public AdminController(ICategoryService categoryService,
            IProductService productService, RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager, ICategoryProductService categoryProductService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _roleManager = roleManager;
            _userManager = userManager;
            _categoryProductService = categoryProductService;
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(RoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetail
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userıd in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userıd);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            ///
                        }
                    }
                }
                foreach (var userıd in model.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userıd);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            ///
                        }
                    }
                }
            }
            return RedirectToAction("RoleList");
        }

        public async Task<IActionResult> Index()
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = await _productService.GetAll()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ProductModel model = new ProductModel
            {
                Categories = await _categoryService.GetAll()
            };
            return View("ProductForm", model);
        }
        [HttpPost]
        public IActionResult SaveProduct(CreateOrEditProductModel model)
        {
            if (model.ProductId == 0)
            {
                _productService.AddProduct(new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Stock = model.Stock,
                    ImageUrl = model.ImageUrl,
                    CategoryProducts = model.CategoryID.Select(x => new CategoryProduct { CategoryId = x }).ToList()
                });
                return Redirect("Index");
            }
            else
            {
                var product = _productService.GetProductDetails(model.ProductId);
                product.Name = model.Name;
                product.Price = model.Price;
                product.Stock = model.Stock;
                product.ImageUrl = model.ImageUrl;
                product.Description = model.Description;
                foreach (var item in model.IdsToAdd ?? new int[] { })
                {
                    product.CategoryProducts.Add(new CategoryProduct { CategoryId = item });
                }
                foreach (var item in model.IdsToRemove ?? new int[] { })
                {
                    //var removingCategory = product.CategoryProducts.FirstOrDefault(x => x.CategoryId == item);
                    //product.CategoryProducts.Remove(removingCategory);
                    //// product.CategoryProducts.Remove(_categoryProductService.Get(item , model.ProductId));
                    _categoryProductService.Delete(item, model.ProductId);
                }
                _productService.Update(product);

                return Redirect("Index");
            }
        }


        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = _productService.GetProductDetails(id);
            var allcategory = new List<Category>();
            var members = new List<Category>();
            allcategory = await _categoryService.GetAll();
            members = product.CategoryProducts.Select(x => x.Category).ToList();
            var result = allcategory.Where(x => !product.CategoryProducts.Any(y => y.CategoryId == x.CategoryId)).ToList();
            ProductModel model = new ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                LinkedCategories = members,
                UnLinkedCategories = result,
            };
            return View("ProductForm", model);
        }





        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(_productService.GetProduct(id));
            return RedirectToAction("Index");
        }
    }
}
