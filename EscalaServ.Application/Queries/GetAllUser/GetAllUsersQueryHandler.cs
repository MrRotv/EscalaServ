using EscalaServ.Application.ViewModels;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetAllUser
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly EscalaServDbContext _dbContext;
        public GetAllUsersQueryHandler(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.User;
            var userViewModel = await user
                .Select(u => new UserViewModel(u.WarName, u.Graduation))
                .ToListAsync();

            return userViewModel;
        }
    }
}
