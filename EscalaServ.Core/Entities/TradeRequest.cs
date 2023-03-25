using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Entities
{
    public class TradeRequest : BaseEntity
    {
        public TradeRequest(int userId, DateOnly outService, DateOnly inService, int militaryId, string motive)
        {
            UserId = userId;
            OutService = outService;
            InService = inService;
            MilitaryId = militaryId;
            Motive = motive;

            CreatedAt= DateTime.Now;
        }

        public User MilitaryUser { get; private set; }
        public int UserId { get; private set; }
        public DateOnly OutService { get; private set; }
        public DateOnly InService { get; private set; }
        public int MilitaryId { get; private set; }
        public string Motive { get; private set; }        
        public DateTime CreatedAt { get; private set; }
    }
}
