using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class TradeRequestViewModel
    {
        public TradeRequestViewModel(int userId, string motive)
        {
            UserId = userId;
            Motive = motive;
        }

        public int UserId { get; private set; }
        public string Motive { get; private set; }
    }
}
