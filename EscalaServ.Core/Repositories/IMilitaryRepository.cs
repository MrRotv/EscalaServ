using EscalaServ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Repositories
{
    public interface IMilitaryRepository
    {
        Task<List<Military>> GetAllAsync();
        Task<Military> GetByIdAsync(int id);
        Task<List<TradeRequest>> GetAllTradesByIdAsync(int id, string query);
        Task AddMilitaryAsync(Military military);
        Task AddTradeAsync(TradeRequest tradeRequest);
        Task UpdateMilitaryAsync(Military military);
        Task DeleteMilitaryAsync(Military military);
    }
}
