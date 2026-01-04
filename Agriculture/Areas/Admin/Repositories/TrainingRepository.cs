using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class TrainingRepository : ITraining
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<TrainingRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public TrainingRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<TrainingRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        public async Task<List<TrainingViewModel>> GetAllTraining()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Training.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new TrainingViewModel()
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    EndDate = x.EndDate,
                    EndDateEng = x.EndDateEng,
                    FiscalYearId = x.FiscalYearId,
                    Organizer = x.Organizer,
                    PremiumId = x.PremiumId,
                    StartDate = x.StartDate,
                    StartDateEng = x.StartDateEng,
                    TrainerName = x.TrainerName,
                    TrainingPlace = x.TrainingPlace,
                    TrainingTypeId = x.TrainingTypeId,
                    Description = x.Description,
                    Title = x.Title,
                    FilePath = x.FilePath,
                   TrainingTypeName =  x.AgriSector.Name,
                   PremiumName = x.PremiumId == 1 ? "प्रीमियम" + " " + "( " + x.Amount + " )" : "नि:शुल्क",

                }).ToListAsync();
        }

        public async Task<TrainingViewModel> GetTrainingById(int id)
        {
            return await _context.Training.Where(x => x.Id == id)
               .Select(x => new TrainingViewModel()
               {
                   Id = x.Id,
                   FiscalYearId = x.FiscalYearId,
                   Title = x.Title,
                   TrainerName = x.TrainerName,
                   TrainingPlace = x.TrainingPlace,
                   PremiumId = x.PremiumId,
                   Amount = x.Amount,
                   TrainingTypeId = x.TrainingTypeId,
                   StartDate = x.StartDate,
                   StartDateEng = x.StartDateEng,
                   EndDate = x.EndDate,
                   EndDateEng = x.EndDateEng,
                   Organizer = x.Organizer,
                   Description = x.Description,
                   FilePath = x.FilePath,
               }).FirstOrDefaultAsync() ?? new TrainingViewModel();
        }

        public async Task<bool> InsertUpdateTraining(TrainingViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var photo = "";
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.Training.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("Training", model.FilePoto, "Training").Result.FilePath;
                            if (app.FilePath != null)
                            {
                                await _utility.RemoveFileFormServer(app.FilePath);
                            }
                        }
                        if (app != null)
                        {
                            app.FiscalYearId = model.FiscalYearId;
                            app.Title = model.Title;
                            app.TrainerName = model.TrainerName;
                            app.TrainingPlace = model.TrainingPlace;
                            app.PremiumId = model.PremiumId;
                            app.Amount = model.Amount;
                            app.TrainingTypeId = model.TrainingTypeId;
                            app.StartDate = model.StartDate;
                            app.StartDateEng = model.StartDateEng;
                            app.EndDate = model.EndDate;
                            app.EndDateEng = model.EndDateEng;
                            app.Organizer = model.Organizer;
                            app.Description = model.Description;
                            app.FilePath = photo == "" ? app.FilePath : photo;

                            app.UpdatedBy = _userId;
                            app.UpdatedDate = DateTime.Now;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                        }
                        else return false;

                    }
                    else
                    {
                        if (model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("Training", model.FilePoto, "Training").Result.FilePath;
                        }
                        int wardId = await _utility.GetWardNoForLogin_Role_User();
                        var data = new Training()
                        {
                            FiscalYearId = model.FiscalYearId,
                            Title = model.Title,
                            TrainerName = model.TrainerName,
                            TrainingPlace = model.TrainingPlace,
                            PremiumId = model.PremiumId,
                            Amount = model.Amount,
                            TrainingTypeId = model.TrainingTypeId,
                            StartDate = model.StartDate,
                            StartDateEng = model.StartDateEng,
                            EndDate = model.EndDate,
                            EndDateEng = model.EndDateEng,
                            Organizer = model.Organizer,
                            Description = model.Description,
                            FilePath = photo,

                            CreatedWardId = wardId,
                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.Training.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Training Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
