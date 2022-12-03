using Crm.UpSchool.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş geçmeyiniz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karekter giriniz");
            RuleFor(x => x.Title).MinimumLength(20).WithMessage("En çok 20 karekter giriniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Boş geçmeyiniz");
        }
    }
}
