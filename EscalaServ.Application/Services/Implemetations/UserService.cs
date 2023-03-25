using EscalaServ.Application.InputModels;
using EscalaServ.Application.Services.Interfaces;
using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Entities;
using EscalaServ.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Services.Implemetations
{
    public class UserService : IUserService
    {
        private readonly EscalaServDbContext _dbContext;
        public UserService(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.Nip, inputModel.WarName, inputModel.Graduation, inputModel.Password);
            _dbContext.User.Add(user);
            return user.Id;
        }

        public List<UserViewModel> GetAll(string query)
        {
            var user = _dbContext.User;
            var userViewModel = user
                .Select(u => new UserViewModel(u.WarName, u.Graduation))
                .ToList();

            return userViewModel;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.User.SingleOrDefault(u => u.Id == id);

            if (user == null) return null;
                        
            var userDetailsViewModel = new UserDetailsViewModel(
                user.Nip,
                user.WarName,
                user.Graduation
                );
            return userDetailsViewModel;
        }
    }
}
