using EscalaServ.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetMilitaryById
{
    public class GetMilitaryByIdQuery : IRequest<MilitaryDetailsViewModel>
    {
        public GetMilitaryByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
