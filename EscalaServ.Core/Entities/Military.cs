using EscalaServ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Entities
{
    public class Military : BaseEntity
    {
        public Military(string nip, string warName, string graduation, string division, string rank)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
            Division = division;
            Rank = rank;

            CreatedAt= DateTime.Now;
            Status = MilitaryStatusEnum.Respite;

            Requests = new List<TradesRequests>();
        }

        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
        public string Division { get; private set; }
        public string Rank { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public MilitaryStatusEnum Status { get; private set; }
        public List<TradesRequests> Requests { get; private set; }
    }
}
