using FluentValidation;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Validators
{
    public class TestValidator : AbstractValidator<Test>
    {
        public TestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome Inválido");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Status Inválido");

            RuleFor(x => x.DurationInSeconds).NotEmpty().WithMessage("Duração Inválida");
        }
    }
}
