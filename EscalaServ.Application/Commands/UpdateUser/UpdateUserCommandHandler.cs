using EscalaServ.Application.Commands.UpdateUser;
using EscalaServ.Core.Repositories;
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

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var update = await _userRepository.GetByIdAsync(request.Id);

            update.Update(request.Nip, request.WarName, request.Graduation);

            await _userRepository.UpdateUserAsync(update);

            return Unit.Value;
        }
    }
}