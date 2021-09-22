using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()//constuctor method
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar maili boş geçilemez!"); 
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında alanı boş geçilemez!");
            RuleFor(x => x.WriterTıtle).NotEmpty().WithMessage("Ünvan alanı boş geçilemez!");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız!");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girmeyiniz!");
        }
    }
}
