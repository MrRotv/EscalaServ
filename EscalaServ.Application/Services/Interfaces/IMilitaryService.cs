using EscalaServ.Application.InputModels;
using EscalaServ.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Services.Interfaces
{
    public interface IMilitaryService
    {
        public List<MilitaryViewModel> GetAll(string query);
        MilitaryDetailsViewModel GetById(int id);
        int Create(AddMilitaryInputModel inputModel);
        int CreateRequest(TradeRequestInputModel inputModel);
        void Update(UpdateMilitaryInputModel inputModel);
        void Delete(int id);
    }
}
