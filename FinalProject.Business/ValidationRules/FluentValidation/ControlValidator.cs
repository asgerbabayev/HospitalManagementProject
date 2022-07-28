using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class ControlValidator : AbstractValidator<ControlDto>
    {
        public ControlValidator()
        {
            RuleFor(x=>x.Complaint).NotEmpty();
            RuleFor(x=>x.RegistryId).NotEmpty();
            RuleFor(x=>x.Date).NotEmpty();
            RuleFor(x=>x.Diagnosis).NotEmpty();
            RuleFor(x=>x.Result).NotEmpty();
        }
    }
}
