using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string nip, string warName, string graduation)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
        }

        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
    }
}
