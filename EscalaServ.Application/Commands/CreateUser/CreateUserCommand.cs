using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
        public string Password { get; private set; }
    }
}
