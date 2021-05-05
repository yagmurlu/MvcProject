using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı 3 Karaketerden Küçük Olamaz!");
            RuleFor(x => x.CategoryName).MaximumLength(25).WithMessage("Kategori Adı 25 Karakterden Büyük Olamaz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Lütfen Açıklama Giriniz!");
        }
    }
}
