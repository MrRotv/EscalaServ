using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Repositories;
using EscalaServ.Infrastructure.Persistence;
using EscalaServ.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetAllMilitary
{
    public class GetAllMilitaryQueryHandler : IRequestHandler<GetAllMilitaryQuery, List<MilitaryViewModel>>
    {
        private readonly IMilitaryRepository _militaryRepository;
        public GetAllMilitaryQueryHandler(IMilitaryRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }
        public async Task<List<MilitaryViewModel>> Handle(GetAllMilitaryQuery request, CancellationToken cancellationToken)
        {
            var military = await _militaryRepository.GetAllAsync();

            var militaryViewModel = military
                .Select(p =>  new MilitaryViewModel(p.Nip, p.WarName))
                .ToList();

            return militaryViewModel;
        }
    }
}
