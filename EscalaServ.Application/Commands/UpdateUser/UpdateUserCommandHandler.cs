using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly EscalaServDbContext _dbContext;

        public UpdateUserCommandHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var update = await _dbContext.User.SingleOrDefaultAsync(x => x.Id == request.Id);

            update.Update(request.Nip, request.WarName, request.Graduation);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
