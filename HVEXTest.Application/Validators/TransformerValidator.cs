using FluentValidation;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Validators
{
    public class TransformerValidator : AbstractValidator<Transformer>
    {
        public TransformerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome Inválido");

            RuleFor(x => x.InternalNumber).NotEmpty().WithMessage("Internal Number Inválido");

            RuleFor(x => x.Potency).NotEmpty().WithMessage("Potency Inválido");

            RuleFor(x => x.Current).NotEmpty().WithMessage("Current Inválido");

            RuleFor(x => x.TensionClass).NotEmpty().WithMessage("Tension Class Inválido");
        }
    }
}
