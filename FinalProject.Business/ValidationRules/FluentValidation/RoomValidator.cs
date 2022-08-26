using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
    public class RoomValidator : AbstractValidator<RoomDto>
    {
        public RoomValidator()
        {
            RuleFor(n => Convert.ToInt32(n.Number)).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
            RuleFor(n => n.Capacity).NotEmpty().Must(x => (x > 0)).WithMessage("0-dan böyük ədəd daxil edin");
        }
    }
}
