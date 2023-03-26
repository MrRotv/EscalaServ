using EscalaServ.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Queries.GetAllUser
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery(string query)
        {
            Query = query;
        }
        public string Query { get; set; }
    }
}
