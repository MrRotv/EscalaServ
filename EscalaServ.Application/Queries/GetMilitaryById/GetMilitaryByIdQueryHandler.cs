using EscalaServ.Application.ViewModels;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetMilitaryById
{
    public class GetMilitaryByIdQueryHandler : IRequestHandler<GetMilitaryByIdQuery, MilitaryDetailsViewModel>
    {
        private readonly EscalaServDbContext _dbContext;
        public GetMilitaryByIdQueryHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MilitaryDetailsViewModel> Handle(GetMilitaryByIdQuery request, CancellationToken cancellationToken)
        {
            var military = await _dbContext.Military.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (military == null) return null;

            var militaryDetailsViewModel = new MilitaryDetailsViewModel(
                military.Id,
                military.Nip,
                military.WarName,
                military.Graduation,
                military.Division,
                military.Rank
                );
            return militaryDetailsViewModel;
        }
    }
}
