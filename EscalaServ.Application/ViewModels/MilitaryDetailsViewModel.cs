using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class MilitaryDetailsViewModel
    {
        public MilitaryDetailsViewModel(string nip, string warName, string graduation, string division, string rank)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
            Division = division;
            Rank = rank;
        }

        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
        public string Division { get; private set; }
        public string Rank { get; private set; }
    }
}
