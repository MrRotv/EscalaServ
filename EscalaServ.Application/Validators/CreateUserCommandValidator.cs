using EscalaServ.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscalaServ.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Nip)
                .NotEmpty()
                .WithMessage("Nip precisa ser preenchido");
            RuleFor(p => p.Nip)
                .Length(8)
                .WithMessage("Nip inválido");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha precisa ter no mínimo 8 caracteres e contar com pelo menos um número, uma letra maiúscula, uma minúscula e um caractere especial");
        }

        public bool ValidPassword (string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
