using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class MilitaryViewModel
    {
        public MilitaryViewModel(string nip, string warName)
        {
            Nip = nip;
            WarName = warName;
        }

        public string Nip { get; set; }
        public string WarName { get; set; }
    }
}
