using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken (string nip, string role);
        string ComputeSha256Hash(string passowrd);
    }
}
