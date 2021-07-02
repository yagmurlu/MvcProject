using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.RecevierMail).NotEmpty().WithMessage("Alıcı Adresi Boş Geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Geçilemez!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 Karakter Girişi Yapın!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("100 Karakterden Fazla Giriş Yapamazsınız!");

        }
    }
}
