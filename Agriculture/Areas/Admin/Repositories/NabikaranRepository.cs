using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Areas.Admin.Repositories
{
    public class NabikaranRepository : INabikaran
    {
        private readonly AgricultureDbContext _dbContext;

        public NabikaranRepository(AgricultureDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateNabikaran(NabikaranViewModel model)
        {
            try
            {
                var entity = new Nabikaran
                {
                    RenewDate = model.RenewDate,
                    ExpireDate = model.ExpireDate,
                    FirmId = model.FirmId,
                    RasidNumber = model.RasidNumber,
                    ReneweFee = model.ReneweFee,
                    Fine = model.Fine,
                };
                _dbContext.Nabikarans.Add(entity);
                await _dbContext.SaveChangesAsync();
                model.Id = entity.Id;
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to insert Nabikaran");
                return false;
            }

        }

        public async Task<NabikaranViewModel> GetNabikaranById(int id)
        {
            return await _dbContext.Nabikarans.Where(x => x.FirmId == id).Select(entity => new NabikaranViewModel
            {
                RenewDate = entity.RenewDate,
                ExpireDate = entity.ExpireDate,
                FirmId = entity.FirmId,
                RasidNumber = entity.RasidNumber,
                ReneweFee = entity.ReneweFee,
                Fine = entity.Fine,
            }).FirstOrDefaultAsync() ?? new NabikaranViewModel();
        }

        public async Task<List<NabikaranViewModel>> NabikaranList()
        {
            return await _dbContext.Nabikarans
                       .Select(model => new NabikaranViewModel
                       {
                           RenewDate = model.RenewDate,
                           ExpireDate = model.ExpireDate,
                           FirmId = model.FirmId,
                           RasidNumber = model.RasidNumber,
                           ReneweFee = model.ReneweFee,
                           Fine = model.Fine,
                       }).ToListAsync();
        }
    }
}
