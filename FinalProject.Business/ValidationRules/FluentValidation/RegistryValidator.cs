using FinalProject.Entities.DTOs;
using FluentValidation;
using System;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class RegistryValidator : AbstractValidator<RegistryDto>
    {
        public RegistryValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
            RuleFor(x => x.RoomId).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
        }
    }
}
