using EscalaServ.Application.Commands.CreateMilitary;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Validators
{
    public class CreateMilitaryCommandValidator : AbstractValidator<CreateMilitaryCommand>
    {
        public CreateMilitaryCommandValidator()
        {
            RuleFor(p => p.Nip)
                .Length(8)
                .WithMessage("NIP precisa conter 8 caracteres")
                .NotEmpty()
                .WithMessage("NIP precisa ser preenchido");

            RuleFor(p => p.Rank)
                .NotNull()
                .WithMessage("Antiguidade precisa ser preenchida");

            RuleFor(p => p.Division)
                .MaximumLength(6)
                .WithMessage("Divisão com nome muito grande, abrevie ou use as representações numéricas")
                .NotEmpty()
                .WithMessage("Divisão precisa ser preenchida");

            RuleFor(p => p.Graduation)
                .MaximumLength(10)
                .WithMessage("Abrevie a graduação")
                .NotEmpty()
                .WithMessage("Graduação precisa ser preenchida");
        }
    }
}
