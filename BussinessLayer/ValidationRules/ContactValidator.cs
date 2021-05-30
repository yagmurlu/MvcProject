using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()//constractor method
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın! bir mesaj giriniz!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız!");
        }
    }
}
