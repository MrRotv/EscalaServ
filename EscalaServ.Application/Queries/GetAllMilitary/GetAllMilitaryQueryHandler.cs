using EscalaServ.Application.ViewModels;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetAllMilitary
{
    public class GetAllMilitaryQueryHandler : IRequestHandler<GetAllMilitaryQuery, List<MilitaryViewModel>>
    {
        private readonly EscalaServDbContext _dbContext;
        public GetAllMilitaryQueryHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MilitaryViewModel>> Handle(GetAllMilitaryQuery request, CancellationToken cancellationToken)
        {
            var military = _dbContext.Military;
            var militaryViewModel = await military
                .Select(p => new MilitaryViewModel(p.Nip, p.WarName))
                .ToListAsync();

            return militaryViewModel;
        }
    }
}
