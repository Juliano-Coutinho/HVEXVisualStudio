using FluentValidation;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome Inválido");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Inválido");
        }
    }
}
