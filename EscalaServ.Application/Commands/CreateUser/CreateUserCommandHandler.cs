using EscalaServ.Core.Entities;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly EscalaServDbContext _dbContext;

        public CreateUserCommandHandler(EscalaServDbContext dbContext) 
        { 
            _dbContext = dbContext; 
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Nip, request.WarName, request.Graduation, request.Password);
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }
    }
}
