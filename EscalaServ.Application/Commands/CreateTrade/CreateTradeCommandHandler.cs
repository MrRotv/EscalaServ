using EscalaServ.Core.Entities;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.CreateTrade
{
    public class CreateTradeCommandHandler : IRequestHandler<CreateTradeCommand, int>
    {
        private readonly EscalaServDbContext _dbContext;

        public CreateTradeCommandHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
        {
            var trade = new TradeRequest(request.UserId, request.OutService, request.InService, request.MilitaryId, request.Motive);
            await _dbContext.TradeRequest.AddAsync(trade);
            await _dbContext.SaveChangesAsync();

            return trade.Id;
        }
    }
}
