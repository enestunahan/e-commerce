using FluentValidation;
using ShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.ValidationRules.FluentValidation
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.UserName).MaximumLength(20);           
            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Parolalar uyuşmuyor");
        }
    }
}
