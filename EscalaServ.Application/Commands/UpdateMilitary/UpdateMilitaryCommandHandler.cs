using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.UpdateMilitary
{
    public class UpdateMilitaryCommandHandler : IRequestHandler<UpdateMilitaryCommand, Unit>
    {
        private readonly EscalaServDbContext _dbContext;

        public UpdateMilitaryCommandHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateMilitaryCommand request, CancellationToken cancellationToken)
        {
            var update = await _dbContext.Military.SingleOrDefaultAsync(x => x.Id == request.Id);

            update.Update(request.Nip, request.WarName, request.Graduation, request.Division, request.Rank);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
