using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.DeleteMilitary
{
    public class DeleteMilitaryCommand : IRequest<Unit>
    {
        public DeleteMilitaryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
