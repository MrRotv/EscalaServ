using EscalaServ.Application.Commands.UpdateMilitary;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Validators
{
    public class UpdateMilitaryCommandValidator : AbstractValidator<UpdateMilitaryCommand>
    {
        public UpdateMilitaryCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id precisa ser preenchida");

            RuleFor(p => p.Nip)
                .NotEmpty()
                .WithMessage("Nip precisa ser preenchido");
            RuleFor(p => p.Nip)
                .Length(8)
                .WithMessage("Nip inválido");
                
        }

    }
}
