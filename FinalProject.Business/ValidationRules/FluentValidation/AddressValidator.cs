using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(n => n.City).NotEmpty().MinimumLength(1);
            RuleFor(n => n.Street).NotEmpty().MinimumLength(1);
            RuleFor(n => n.Region).NotEmpty().MinimumLength(1);
            RuleFor(n => n.ApartmentNumber).NotEmpty();
        }
    }
}
