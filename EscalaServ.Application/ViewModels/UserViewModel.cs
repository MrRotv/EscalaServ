using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string warName, string graduation)
        {
            WarName = warName;
            Graduation = graduation;
        }

        public string WarName { get; private set; }
        public string Graduation { get; private set; }
    }
}
