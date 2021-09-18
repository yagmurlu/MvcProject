using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class SkillValidator:AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Lütfen Yetenek Girin!");
            RuleFor(x => x.SkillName).MaximumLength(50).WithMessage("25 Karakterden Uzun Olamaz!");
        }
    }
}
