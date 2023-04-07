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
        public string Nip { get;  set; }
        public string WarName { get;  set; }
        public string Graduation { get;  set; }
        public string Password { get;  set; }
        public string Role { get; set; }
    }
}
