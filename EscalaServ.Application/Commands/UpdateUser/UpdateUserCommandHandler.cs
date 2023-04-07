using EscalaServ.Application.Commands.UpdateUser;
using EscalaServ.Core.Repositories;
using EscalaServ.Core.Services;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var update = await _userRepository.GetByIdAsync(request.Id);

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            update.Update(request.Nip, request.WarName, request.Graduation, passwordHash, request.Role);

            await _userRepository.UpdateUserAsync(update);

            return Unit.Value;
        }
    }
}