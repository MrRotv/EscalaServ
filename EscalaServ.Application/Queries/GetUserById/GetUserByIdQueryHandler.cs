using EscalaServ.Application.ViewModels;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly EscalaServDbContext _dbContext;
        public GetUserByIdQueryHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.User.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null) return null;

            var userDetailsViewModel = new UserDetailsViewModel(
                user.Nip,
                user.WarName,
                user.Graduation
                );
            return userDetailsViewModel;
        }
    }
}
