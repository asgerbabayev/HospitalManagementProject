using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class AnalysisValidator : AbstractValidator<AnalysisDto>
    {
        public AnalysisValidator()
        {
            RuleFor(x=>x.Date).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.Price).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
            RuleFor(x=>x.Type).NotEmpty();
        }
    }
}
