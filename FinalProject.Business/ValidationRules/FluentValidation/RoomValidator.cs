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
            RuleFor(n => n.Number).NotEmpty().MinimumLength(1);
            RuleFor(n => n.Capacity).NotEmpty();
            RuleFor(n => n.Type).NotEmpty().MinimumLength(1);
        }
    }
}
