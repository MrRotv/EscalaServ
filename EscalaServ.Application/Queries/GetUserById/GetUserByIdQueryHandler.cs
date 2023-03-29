using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Repositories;
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
        private readonly IUserRepository _militaryRepository;
        public GetUserByIdQueryHandler(IUserRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _militaryRepository.GetByIdAsync(request.Id);

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
