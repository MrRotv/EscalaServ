using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.InputModels
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string nip, string warName, string graduation, string password)
        {
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
            Password = password;
        }

        public string Nip { get; private set; }
        public string WarName { get; private set; }
        public string Graduation { get; private set; }
        public string Password { get; private set; }
    }
}
