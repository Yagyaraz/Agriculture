using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Areas.Admin.Repositories
{
    public class GunasoRepository : IGunaso
    {
        private readonly AgricultureDbContext _dbContext;

        public GunasoRepository(AgricultureDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateGunaso(GunasoViewModel model)
        {
            try
            {
                var entity = new Gunaso
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Description = model.Description,
                    Status = true
                };
                _dbContext.Gunasos.Add(entity);
                await _dbContext.SaveChangesAsync();
                model.Id = entity.Id;
                return true;
            }
            catch (Exception ) 
            {
                Console.WriteLine("Failed to insert gunaso");
                return false;
            }
            
        }

        public async Task<GunasoViewModel> GetGunasoById(int id)
        {
            var entity = await _dbContext.Gunasos.FindAsync(id);
            if (entity == null) return null;

            return new GunasoViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Description = entity.Description,
                Status = entity.Status
            };
        }

        public async Task<List<GunasoViewModel>> GunasoList()
        {
            return await _dbContext.Gunasos
                       .Select(c => new GunasoViewModel
                       {
                           Id = c.Id,
                           Name = c.Name,
                           PhoneNumber = c.PhoneNumber,
                           Description = c.Description,
                           Status = c.Status
                       })
                       .ToListAsync();
        }
    }
}
