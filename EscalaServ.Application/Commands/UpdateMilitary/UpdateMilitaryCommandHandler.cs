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
    public class UpdateMilitaryCommandHandler : IRequestHandler<UpdateMilitaryCommand, Unit>
    {
        private readonly IMilitaryRepository _militaryRepository;

        public UpdateMilitaryCommandHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<Unit> Handle(UpdateMilitaryCommand request, CancellationToken cancellationToken)
        {
            var update = await _militaryRepository.GetByIdAsync(request.Id);

            update.Update(request.Nip, request.WarName, request.Graduation, request.Division, request.Rank);

            await _militaryRepository.UpdateMilitaryAsync(update);

            return Unit.Value;
        }
    }
}
