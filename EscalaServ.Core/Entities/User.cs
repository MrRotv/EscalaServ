using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string nip, string warName, string graduation)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;

            CreatedAt = DateTime.Now;
            Active = true;
            
        }

        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
