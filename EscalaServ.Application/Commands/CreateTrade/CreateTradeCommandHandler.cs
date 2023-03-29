using EscalaServ.Core.Entities;
using EscalaServ.Core.Repositories;
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
        private readonly IMilitaryRepository _militaryRepository;

        public CreateTradeCommandHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<int> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
        {
            var tradeRequest = new TradeRequest(request.UserId, request.OutService, request.InService, request.MilitaryId, request.Motive);
            
            await _militaryRepository.AddTradeAsync(tradeRequest);

            return tradeRequest.Id;
        }
    }
}
