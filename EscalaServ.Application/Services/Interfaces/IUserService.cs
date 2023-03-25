using EscalaServ.Application.InputModels;
using EscalaServ.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserDetailsViewModel GetById(int id);
        public List<UserViewModel> GetAll(string query);
        int Create(CreateUserInputModel inputModel);
    }
}
