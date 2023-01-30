using FluentValidation;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Validators
{
    public class ReportValidator : AbstractValidator<Report>
    {
        public ReportValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome Inválido");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Staus Inválido");

            RuleFor(x => x.TransformersId).NotEmpty().WithMessage("Um relatório precisa de pelo menos um transformador");

            RuleFor(x => x.TestId).NotEmpty().WithMessage("Um relatório precisa de pelo menos um ensaio");
        }
    }
}
