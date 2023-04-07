using EscalaServ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string nip, string warName, string graduation, string password, string role)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
            Password = password;
            Role = role;

            CreatedAt = DateTime.Now;
            Active = true;
            
        }

        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }

        public List<TradeRequest> TradesRequests { get; private set; }      

        public void Update(string nip, string warName, string graduation,string password, string role)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
            Password = password;
            Role = role;
        }
    }
}
