using Azure.Core;
using EscalaServ.Core.Entities;
using EscalaServ.Core.Enums;
using EscalaServ.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Infrastructure.Persistence.Repositories
{
    public class MilitaryRepository : IMilitaryRepository
    {
        private readonly EscalaServDbContext _dbContext;

        public MilitaryRepository(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Military>> GetAllAsync()
        {
            return await _dbContext.Military.ToListAsync();
        }

        public async Task<Military> GetByIdAsync(int id)
        {
            return await _dbContext.Military.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TradeRequest>> GetAllTradesByIdAsync(int id, string query)
        {
            return await _dbContext.TradeRequest.Where(p=> p.UserId == id).ToListAsync();
        }

        public async Task AddMilitaryAsync(Military military)
        {
            await _dbContext.Military.AddAsync(military);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTradeAsync(TradeRequest tradeRequest)
        {
            await _dbContext.TradeRequest.AddAsync(tradeRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMilitaryAsync(Military military)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMilitaryAsync( Military military)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
