using EscalaServ.Application.Commands.CreateTrade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Validators
{
    public class CreateTradeCommandValidator : AbstractValidator<CreateTradeCommand>
    {
        public CreateTradeCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty()
                .WithMessage("É necessário inserir uma Id de usuário para solicitar a troca");

            RuleFor(p => p.MilitaryId)
                .NotEmpty()
                .WithMessage("Insira uma Id do militar que estará saindo do serviço");
        }
    }
}
