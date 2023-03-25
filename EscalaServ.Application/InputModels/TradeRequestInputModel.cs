using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.InputModels
{
    public class TradeRequestInputModel
    {
        public TradeRequestInputModel(int userId, string outService, string inService, int militaryId, string motive)
        {
            UserId = userId;
            OutService = outService;
            InService = inService;
            MilitaryId = militaryId;
            Motive = motive;
        }

        public int UserId { get; private set; }
        public string OutService { get; private set; }
        public string InService { get; private set; }
        public int MilitaryId { get; private set; }
        public string Motive { get; private set; }
    }
}
