using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class PrescriptionValidator:AbstractValidator<PrescriptionDto>
    {
        public PrescriptionValidator()
        {
            RuleFor(n => n.RegistryId).NotEmpty();
            RuleFor(n => n.MedicineId).NotEmpty();
            RuleFor(n => n.Description).NotEmpty().MinimumLength(1).MaximumLength(200);
            RuleFor(n => n.DailyDose).NotEmpty();
        }
    }
}
