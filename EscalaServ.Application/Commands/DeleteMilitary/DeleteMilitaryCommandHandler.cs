﻿using EscalaServ.Core.Repositories;
using EscalaServ.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.DeleteMilitary
{
    public class DeleteMilitaryCommandHandler : IRequestHandler<DeleteMilitaryCommand, Unit>
    {
        private readonly IMilitaryRepository _militaryRepository;

        public DeleteMilitaryCommandHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<Unit> Handle(DeleteMilitaryCommand request, CancellationToken cancellationToken)
        {
            var military = await _militaryRepository.GetByIdAsync(request.Id);

            if (military != null)
            {
                military.Delete();
                await _militaryRepository.DeleteMilitaryAsync(military);
            }
            return Unit.Value;
        }
    }
}
