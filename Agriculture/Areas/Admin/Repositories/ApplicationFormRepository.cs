using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class ApplicationFormRepository : IApplicationForm
    {  
        private readonly AgricultureDbContext _context;
        private readonly ILogger<ApplicationFormRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public ApplicationFormRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<ApplicationFormRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        public async Task<List<ApplicationFormViewModel>> GetAllApplicationForm()
        {
            return await _context.ApplicationForms
                .Select(x => new ApplicationFormViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Program = x.Program,
                    Email = x.Email,
                    Phone = x.Phone,
                }).ToListAsync();
        }

        public async Task<ApplicationFormViewModel> GetApplicationFormById(int id)
        {
            return await _context.ApplicationForms.Where(data => data.Id == id)
               .Select(data => new ApplicationFormViewModel()
               {
                   Id = data.Id,
                   FullName = data.FullName,
                   Email = data.Email,
                   Phone = data.Phone,
                   Dob = data.Dob,
                   Address = data.Address,
                   Program = data.Program,
                   Batch = data.Batch,
                   Qualification = data.Qualification,
                   Institution = data.Institution,
                   Experience = data.Experience,
                   ResumePath = data.ResumePath,
                   Source = data.Source,
                   Message = data.Message
               }).FirstOrDefaultAsync() ?? new ApplicationFormViewModel();
        }

        public async Task<bool> InsertUpdateApplicationForm(ApplicationFormViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var photo = "";
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.ApplicationForms.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (model.Resume != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("ApplicationForm", model.Resume, "ApplicationForm").Result.FilePath;
                            if (app.ResumePath != null)
                            {
                                await _utility.RemoveFileFormServer(app.ResumePath);
                            }
                        }
                        if (app != null)
                        {
                            app.Id = model.Id;
                            app.FullName = model.FullName;
                            app.Email = model.Email;
                            app.Phone = model.Phone;
                            app.Dob = model.Dob;
                            app.Address = model.Address;
                            app.Program = model.Program;
                            app.Batch = model.Batch;
                            app.Qualification = model.Qualification;
                            app.Institution = model.Institution;
                            app.Experience = model.Experience;
                            app.ResumePath = model.ResumePath;
                            app.Source = model.Source;
                            app.Message = model.Message;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                        }
                        else return false;

                    }
                    else
                    {
                        if (model.Resume != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("ApplicationForm", model.Resume, "ApplicationForm").Result.FilePath;
                        }
                        var data = new ApplicationForm()
                        {
                            FullName = model.FullName,
                            Email = model.Email,
                            Phone = model.Phone,
                            Dob = model.Dob,
                            Address = model.Address,
                            Program = model.Program,
                            Batch = model.Batch,
                            Qualification = model.Qualification,
                            Institution = model.Institution,
                            Experience = model.Experience,
                            ResumePath = model.ResumePath,
                            Source = model.Source,
                            Message = model.Message
                        };
                        await _context.ApplicationForms.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("ApplicationForm Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
