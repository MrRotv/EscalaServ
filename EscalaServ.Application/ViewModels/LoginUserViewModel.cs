using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string nip, string token)
        {
            Nip = nip;
            Token = token;
        }

        public string Nip { get; private set; }
        public string Token { get; private set; }
    }
}
