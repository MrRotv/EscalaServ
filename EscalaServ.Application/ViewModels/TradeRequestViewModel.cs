using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class TradeRequestViewModel
    {
        public TradeRequestViewModel(int userId, string outService, string inService, string motive)
        {
            UserId = userId;
            OutService = outService;
            InService = inService;
            Motive = motive;
        }

        public int UserId { get; private set; }
        public string OutService { get; private set; }
        public string InService { get; private set; }
        public string Motive { get; private set; }
    }
}
