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

namespace EscalaServ.Application.Queries.GetMilitaryById
{
    public class GetMilitaryByIdQueryHandler : IRequestHandler<GetMilitaryByIdQuery, MilitaryDetailsViewModel>
    {
        private readonly IMilitaryRepository _militaryRepository;
        public GetMilitaryByIdQueryHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<MilitaryDetailsViewModel> Handle(GetMilitaryByIdQuery request, CancellationToken cancellationToken)
        {

            var military = await _militaryRepository.GetByIdAsync(request.Id);

            if (military == null) return null;

            var militaryDetailsViewModel = new MilitaryDetailsViewModel(
                military.Id,
                military.Nip,
                military.WarName,
                military.Graduation,
                military.Division,
                military.Rank
                );
            return militaryDetailsViewModel;
        }
    }
}
