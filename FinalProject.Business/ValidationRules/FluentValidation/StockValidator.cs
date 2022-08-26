using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class StockValidator : AbstractValidator<StockDto>
    {
        public StockValidator()
        {
            RuleFor(n => n.Name).NotEmpty().MinimumLength(1);
            RuleFor(n => n.Price).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin"); ;
            RuleFor(n => n.Count).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin"); ;
        }
    }
}
