using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.DeleteMilitary
{
    public class DeleteMilitaryCommandHandler : IRequestHandler<DeleteMilitaryCommand, Unit>
    {
        private readonly EscalaServDbContext _dbContext;

        public DeleteMilitaryCommandHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteMilitaryCommand request, CancellationToken cancellationToken)
        {
            var military = await _dbContext.Military.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (military != null)
            {
                military.Delete();
                await _dbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
