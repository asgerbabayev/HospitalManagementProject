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
            RuleFor(x=>x.RegistryId).NotEmpty();
            RuleFor(x=>x.Count).NotEmpty();
        }
    }
}
