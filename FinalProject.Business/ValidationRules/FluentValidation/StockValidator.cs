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
            RuleFor(n => n.Price).NotEmpty();
            RuleFor(n => n.Count).NotEmpty();
        }
    }
}
