using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Entities
{
    public class TradesRequests : BaseEntity
    {
        public TradesRequests(int userId, DateTime outService, DateTime inService, int militaryId, string motive)
        {
            UserId = userId;
            OutService = outService;
            InService = inService;
            MilitaryId = militaryId;
            Motive = motive;

            CreatedAt= DateTime.Now;
        }

        public int UserId { get; private set; }
        public DateTime OutService { get; private set; }
        public DateTime InService { get; private set; }
        public int MilitaryId { get; private set; }
        public string Motive { get; private set; }        
        public DateTime CreatedAt { get; private set; }
    }
}
