using Azure.Core;
using EscalaServ.Core.Entities;
using EscalaServ.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EscalaServDbContext _dbContext;

        public UserRepository(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
