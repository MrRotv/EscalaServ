using EscalaServ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Infrastructure.Persistence
{
    public class EscalaServDbContext
    {
        public List<Military> Military { get; set; }
        public List<User> User { get; set; }
    }
}
