using EscalaServ.Application.InputModels;
using EscalaServ.Application.Services.Interfaces;
using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Entities;
using EscalaServ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Services.Implemetations
{
    public class MilitaryService : IMilitaryService
    {
        private readonly EscalaServDbContext _dbContext;
        public MilitaryService(EscalaServDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public int Create(AddMilitaryInputModel inputModel)
        {
            var military = new Military(inputModel.Nip, inputModel.WarName, inputModel.Graduation, inputModel.Division, inputModel.Rank);
            _dbContext.Military.Add(military);
            _dbContext.SaveChanges();

            return military.Id;
        }

        public List<MilitaryViewModel> GetAll(string query)
        {
            var military = _dbContext.Military;
            var militaryViewModel = military
                .Select(p => new MilitaryViewModel(p.Nip, p.WarName))
                .ToList();

            return militaryViewModel;
        }

        public MilitaryDetailsViewModel GetById(int id)
        {
            var military = _dbContext.Military.SingleOrDefault(x => x.Id == id);

            if (military == null) return null;

            var militaryDetailsViewModel = new MilitaryDetailsViewModel(
                military.Id,
                military.Nip,
                military.WarName,
                military.Graduation,
                military.Division,
                military.Rank
                );
            return militaryDetailsViewModel;
        }

        public int CreateRequest(TradeRequestInputModel inputModel)
        {
            var request = new TradeRequest(inputModel.UserId, inputModel.OutService,inputModel.InService, inputModel.MilitaryId, inputModel.Motive);
            _dbContext.TradeRequest.Add(request);
            _dbContext.SaveChanges();

            return request.Id;
        }

        public void Delete(int id)
        {
            var military = _dbContext.Military.SingleOrDefault(x => x.Id == id);
            
            if (military != null)
            {
                military.Delete();
                _dbContext.SaveChanges();
            }
                           
        }

        public void Update(UpdateMilitaryInputModel inputModel, int id)
        {
            var update = _dbContext.Military.SingleOrDefault(x => x.Id == id);
            
            update.Update(inputModel.Nip, inputModel.WarName, inputModel.Graduation, inputModel.Division, inputModel.Rank );
            _dbContext.SaveChanges();
        }
    }
}
