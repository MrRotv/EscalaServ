using EscalaServ.Core.Entities;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.CreateMilitary
{
    public class CreateMilitaryCommandHandler : IRequestHandler<CreateMilitaryCommand, int>
    {
        private readonly EscalaServDbContext _dbContext;
        
        public CreateMilitaryCommandHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateMilitaryCommand request, CancellationToken cancellationToken)
        {
            var military = new Military(request.Nip, request.WarName, request.Graduation, request.Division, request.Rank);
            await _dbContext.Military.AddAsync(military);
            await _dbContext.SaveChangesAsync();

            return military.Id;
        }
    }
}
