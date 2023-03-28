using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Entities;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetTrades
{
    public class GetAllTradesByUserIdQueryHandler : IRequestHandler<GetAllTradesByUserIdQuery, List<TradeRequestViewModel>>
    {
        private readonly EscalaServDbContext _dbContext;
        public GetAllTradesByUserIdQueryHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TradeRequestViewModel>> Handle(GetAllTradesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var tradeViewModel = await _dbContext.TradeRequest
                .Where(p => p.UserId == request.Id)
                .Select(p => new TradeRequestViewModel(p.UserId, p.InService, p.OutService, p.Motive))
                .ToListAsync();

            var CountTrade = tradeViewModel.Count;

            if (CountTrade == 0) return null;
            
            return tradeViewModel;
            
        }
    }
}
