using FluentValidation;
using ShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.ValidationRules.FluentValidation
{
    public class ProductModelValidator : AbstractValidator<ProductModel>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Ürün resim alanı boş bırakılamaz");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat alanı eksi olamaz").LessThan(100000).WithMessage("Fiyat alanı 100 000 den fazla olamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz");
            RuleFor(x => x.Description).Length(10, 100).WithMessage("Açıklama alanı 10 ile 50 karakter arasında olmalıdır");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.Stock).GreaterThan(10).WithMessage("Üründen en az 10 adet olması gerekmektedir");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok alanı boş bırakılamaz");
        }
    }
}
