using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.TaxNo).NotEmpty();
            RuleFor(x => x.IdentificationNumber).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.RegistryId).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Mobil nömrə məcburidir").Matches(new Regex(@"^(\+?994|0)(77|51|50|55|70|40|60|12)(\-|)(\d){3}(\-|)(\d){2}(\-|)(\d){2}$")).WithMessage("Mobil nömrəni düzgün formatda yazın");
        }
    }
}
