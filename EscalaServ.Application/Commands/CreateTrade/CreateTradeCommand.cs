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
        public int UserId { get;  set; }
        public string OutService { get;  set; }
        public string InService { get;  set; }
        public int MilitaryId { get;  set; }
        public string Motive { get;  set; }
    }
}
