using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetTrades
{
    public class GetAllTradesByUserIdQuery : IRequest<List<TradeRequestViewModel>>
    {
        public GetAllTradesByUserIdQuery(int id, string query)
        {
            Id = id;
            Query = query;
        }
        public int Id { get; set; }
        public string Query { get; set; }
    }
}
