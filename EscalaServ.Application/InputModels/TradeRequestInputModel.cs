using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.InputModels
{
    public class TradeRequestInputModel
    {
        public TradeRequestInputModel(int userId, DateOnly outService, DateOnly inService, int militaryId, string motive)
        {
            UserId = userId;
            OutService = outService;
            InService = inService;
            MilitaryId = militaryId;
            Motive = motive;
        }

        public int UserId { get; private set; }
        public DateOnly OutService { get; private set; }
        public DateOnly InService { get; private set; }
        public int MilitaryId { get; private set; }
        public string Motive { get; private set; }
    }
}
