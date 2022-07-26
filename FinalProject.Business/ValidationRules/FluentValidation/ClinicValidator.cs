using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class ClinicValidator : AbstractValidator<ClinicDto>
    {
        public ClinicValidator()
        {
            RuleFor(n => n.Name).NotEmpty().MinimumLength(1).MaximumLength(50);
            RuleFor(e => e.PhoneNumber).NotEmpty().WithMessage("Mobil nömrə məcburidir").Matches(new Regex(@"^(\+?994|0)(77|51|50|55|70|40|60|12)(\-|)(\d){3}(\-|)(\d){2}(\-|)(\d){2}$")).WithMessage("Mobil nömrəni düzgün formatda yazın");
        }
    }
}
