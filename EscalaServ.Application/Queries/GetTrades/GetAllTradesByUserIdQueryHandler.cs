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
            var trade = await _dbContext.TradeRequest.SingleOrDefaultAsync(p => p.UserId == request.Id);

            if (trade == null) return null;

            var tradeView = _dbContext.TradeRequest;

            var tradeViewModel = await tradeView
                .Select(u => new TradeRequestViewModel(u.UserId, u.Motive))
                .ToListAsync();

            return tradeViewModel;
        }
    }
}
