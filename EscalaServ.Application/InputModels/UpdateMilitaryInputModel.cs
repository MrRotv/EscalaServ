﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.InputModels
{
    public class UpdateMilitaryInputModel
    {
        public UpdateMilitaryInputModel(int id, string nip, string warName, string graduation, string division, string rank)
        {
            Id = id;
            Nip = nip;
            WarName = warName;
            Graduation = graduation;
            Division = division;
            Rank = rank;
        }

        public int Id { get; set; }
        public string Nip { get; set; }
        public string WarName { get; set; }
        public string Graduation { get; set; }
        public string Division { get; set; }
        public string Rank { get; set; }
    }
}
