using EscalaServ.Core.Entities;
using EscalaServ.Core.Repositories;
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
        private readonly IMilitaryRepository _militaryRepository;
        
        public CreateMilitaryCommandHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<int> Handle(CreateMilitaryCommand request, CancellationToken cancellationToken)
        {
            var military = new Military(request.Nip, request.WarName, request.Graduation, request.Division, request.Rank);

            await _militaryRepository.AddMilitaryAsync(military);

            return military.Id;
        }
    }
}
