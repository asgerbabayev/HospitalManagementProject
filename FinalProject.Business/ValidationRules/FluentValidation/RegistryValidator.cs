using FinalProject.Entities.DTOs;
using FluentValidation;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class RegistryValidator : AbstractValidator<RegistryDto>
    {
        public RegistryValidator()
        {
            RuleFor(x => x.ClinicId).NotEmpty();
            RuleFor(x => x.DoctorId).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.PatientRegistryDate).NotEmpty();
            RuleFor(x => x.PatientLeavingDate).NotEmpty();
            RuleFor(x => x.TotalPrice).NotEmpty();
        }
    }
}
