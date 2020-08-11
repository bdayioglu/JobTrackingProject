using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using DTO.DTOs.AciliyetDtos;

namespace Business.ValidationRules.FluentValidation
{
    public class AciliyetAddValidator : AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
