using EscalaServ.Application.ViewModels;
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

namespace EscalaServ.Application.Queries.GetTrades
{
    public class GetAllTradesByUserIdQueryHandler : IRequestHandler<GetAllTradesByUserIdQuery, List<TradeRequestViewModel>>
    {
        private readonly IMilitaryRepository _militaryRepository;
        public GetAllTradesByUserIdQueryHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<List<TradeRequestViewModel>> Handle(GetAllTradesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var trade = await _militaryRepository.GetAllTradesByIdAsync(request.Id, request.Query);

            var tradeViewModel = trade
                .Select(p => new TradeRequestViewModel(
                    p.UserId,
                    p.OutService,
                    p.InService,
                    p.Motive))
                .ToList();

            var CountTrade = tradeViewModel.Count;

            if (CountTrade == 0) return null;
            
            return tradeViewModel;
            
        }
    }
}
