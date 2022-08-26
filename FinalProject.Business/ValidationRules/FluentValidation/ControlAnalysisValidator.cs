using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class ControlAnalysisValidator : AbstractValidator<ControlAnalysisDto>
    {
        public ControlAnalysisValidator()
        {
            RuleFor(x=>x.ControlId).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
            RuleFor(x=>x.AnalysisId).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
        }
    }
}
