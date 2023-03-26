using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.UpdateMilitary
{
    public class UpdateMilitaryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nip { get; set; }
        public string WarName { get; set; }
        public string Graduation { get; set; }
        public string Division { get; set; }
        public string Rank { get; set; }
    }
}
