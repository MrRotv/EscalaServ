using EscalaServ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Infrastructure.Persistence
{
    public class EscalaServDbContext
    {
        public EscalaServDbContext()
        {
            Military = new List<Military>
            {

                new Military("19144504", "Vítor Silva", "CB-RM2-TE", "BNN-11", "6"),
                new Military("17153182", "Araújo", "CB-RM2-TE", "BNN-11.3", "1"),

            };

            User = new List<User>
            {
                new User("19144504", "Vítor Silva","CB-RM2-TE","abcd1234"),
                new User("17153182", "Araújo", "CB-RM2-TE","abcd1234"),

            };

            TradeRequest = new List<TradeRequest>
            {
                new TradeRequest(1,DateOnly.Parse("12/2/2022"), DateOnly.Parse("15/2/2022"),1,"Consulta Médica"),
            };
        }
        public List<Military> Military { get; set; }
        public List<User> User { get; set; }
        public List<TradeRequest> TradeRequest { get; set; }
    }
}
