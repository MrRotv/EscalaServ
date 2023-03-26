using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.CreateTrade
{
    public class CreateTradeCommand : IRequest<int>
    {
        public int UserId { get; private set; }
        public string OutService { get; private set; }
        public string InService { get; private set; }
        public int MilitaryId { get; private set; }
        public string Motive { get; private set; }
    }
}
