using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class MaterialValidator : AbstractValidator<MaterialDto>
    {
        public MaterialValidator()
        {
            RuleFor(x=>x.StockId).NotEmpty();
            RuleFor(x=>x.RegistryId).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
            RuleFor(x=>x.Count).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
        }
    }
}
