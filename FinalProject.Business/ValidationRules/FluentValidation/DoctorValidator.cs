using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class DoctorValidator : AbstractValidator<EmployeeDto>
    {
        public DoctorValidator()
        {
            RuleFor(n => n.Name).NotEmpty().MinimumLength(1).MaximumLength(50);
            RuleFor(n => n.Surname).NotEmpty().MinimumLength(1).MaximumLength(50);
            RuleFor(e => e.Email).NotEmpty().WithMessage("Email adres məcburidir").Matches(new Regex(@"^([a-zA-Z]+[a-zA-z.!#$%&'*+-=?^`{|}~]{0,64})+[@]+[a-zA-z-]+[.]+[a-zA-z]+$")).WithMessage("Düzgün email formatı yazın");
            RuleFor(e => e.PhoneNumber).NotEmpty().WithMessage("Mobil nömrə məcburidir").Matches(new Regex(@"^(\+?994|0)(77|51|50|55|70|40|60|12)(\-|)(\d){3}(\-|)(\d){2}(\-|)(\d){2}$")).WithMessage("Mobil nömrəni düzgün formatda yazın");
        }
    }
}
