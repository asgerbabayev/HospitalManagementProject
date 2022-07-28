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
            RuleFor(x=>x.ControlId).NotEmpty();
            RuleFor(x=>x.AnalysisId).NotEmpty();
        }
    }
}
