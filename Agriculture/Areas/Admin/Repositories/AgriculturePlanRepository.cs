using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;

namespace Agriculture.Areas.Admin.Repositories
{
    public class AgriculturePlanRepository : IAgriculturePlan
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<AgriculturePlanRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public AgriculturePlanRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<AgriculturePlanRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region Program
        public async Task<List<AgricultureProgramViewModel>> GetAllProgram()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.AgricultureProgram.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new AgricultureProgramViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    Title = x.Title,

                    FiscalYearName = x.FiscalYear.Name,
                }).ToListAsync();
        }
        public async Task<AgricultureProgramViewModel> GetProgramById(int id)
        {
            return await _context.AgricultureProgram.Where(x => x.Id == id)
                .Select(x => new AgricultureProgramViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    Title = x.Title,
                }).FirstOrDefaultAsync() ?? new AgricultureProgramViewModel();
        }
        public async Task<bool> InsertUpdateProgram(AgricultureProgramViewModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var Program = await _context.AgricultureProgram.FirstOrDefaultAsync(x => x.Id == model.Id);
                    if (Program != null)
                    {
                        Program.FiscalYearId = model.FiscalYearId;
                        Program.Title = model.Title;

                        Program.UpdatedBy = _userId;
                        Program.UpdatedDate = DateTime.Now;

                        _context.Entry(Program).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();

                    var fiscal = new AgricultureProgram()
                    {
                        FiscalYearId = model.FiscalYearId,
                        Title = model.Title,

                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                        CreatedWardId = wardId,

                    };
                    await _context.AgricultureProgram.AddAsync(fiscal);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Project
        public async Task<List<AgricultureProjectViewModel>> GetAllProject()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.AgricultureProject.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new AgricultureProjectViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectName = x.ProjectName,

                    FiscalYearName = x.FiscalYear.Name,
                    ProgramName = x.AgricultureProgram.Title,
                }).ToListAsync();
        }
        public async Task<AgricultureProjectViewModel> GetProjectById(int id)
        {
            return await _context.AgricultureProject.Where(x => x.Id == id)
                .Select(x => new AgricultureProjectViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectName = x.ProjectName,
                }).FirstOrDefaultAsync() ?? new AgricultureProjectViewModel();
        }
        public async Task<bool> InsertUpdateProject(AgricultureProjectViewModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var Project = await _context.AgricultureProject.FirstOrDefaultAsync(x => x.Id == model.Id);
                    if (Project != null)
                    {
                        Project.FiscalYearId = model.FiscalYearId;
                        Project.ProgramId = model.ProgramId;
                        Project.ProjectName = model.ProjectName;

                        Project.UpdatedBy = _userId;
                        Project.UpdatedDate = DateTime.Now;

                        _context.Entry(Project).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();

                    var fiscal = new AgricultureProject()
                    {
                        FiscalYearId = model.FiscalYearId,
                        ProgramId = model.ProgramId,
                        ProjectName = model.ProjectName,

                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                        CreatedWardId = wardId,

                    };
                    await _context.AgricultureProject.AddAsync(fiscal);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Service
        public async Task<List<AgricultureServiceViewModel>> GetAllService()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.AgricultureService.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new AgricultureServiceViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectId = x.ProjectId,
                    ValidTillDateEng = x.ValidTillDateEng,
                    ValidTillDate = x.ValidTillDate,
                    ServiceName = x.ServiceName,

                    FiscalYearName = x.FiscalYear.Name,
                    ProgramName = x.AgricultureProgram.Title,
                    ProjectName = x.AgricultureProject.ProjectName,
                    AgricultureServiceAdditionalViewModelList = _context.AgricultureServiceAdditional.Where(z => z.ServiceId == x.Id)
                    .Select(z => new AgricultureServiceAdditionalViewModel()
                    {
                        Id = z.Id,
                        ServiceId = z.ServiceId,
                        Questions = z.Questions,
                    }).ToList() ?? new List<AgricultureServiceAdditionalViewModel>(),
                }).ToListAsync()??new List<AgricultureServiceViewModel>();
        }
        public async Task<AgricultureServiceViewModel> GetServiceById(int id)
        {
            return await _context.AgricultureService.Where(x => x.Id == id)
                .Select(x => new AgricultureServiceViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectId = x.ProjectId,
                    ValidTillDate = x.ValidTillDate,
                    ValidTillDateEng = x.ValidTillDateEng,
                    ServiceName = x.ServiceName,
                    AgricultureServiceAdditionalViewModelList = _context.AgricultureServiceAdditional.Where(z => z.ServiceId == x.Id)
                    .Select(z => new AgricultureServiceAdditionalViewModel()
                    {
                        Id = z.Id,
                        ServiceId = z.ServiceId,
                        Questions = z.Questions,
                    }).ToList() ?? new List<AgricultureServiceAdditionalViewModel>(),
                }).FirstOrDefaultAsync() ?? new AgricultureServiceViewModel();
        }
        public async Task<bool> InsertUpdateService(AgricultureServiceViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var Service = await _context.AgricultureService.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (Service != null)
                        {
                            Service.FiscalYearId = model.FiscalYearId;
                            Service.ProgramId = model.ProgramId;
                            Service.ProjectId = model.ProjectId;
                            Service.ValidTillDate = model.ValidTillDate;
                            Service.ValidTillDateEng = model.ValidTillDateEng;
                            Service.ServiceName = model.ServiceName;

                            Service.UpdatedBy = _userId;
                            Service.UpdatedDate = DateTime.Now;

                            _context.Entry(Service).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.AgricultureServiceAdditionalViewModelList != null)
                            {
                                foreach (var item in await _context.AgricultureServiceAdditional.Where(x => x.ServiceId == model.Id).ToListAsync())
                                {
                                    if (!model.AgricultureServiceAdditionalViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.AgricultureServiceAdditional.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.AgricultureServiceAdditionalViewModelList)
                                {
                                    var adata = await _context.AgricultureServiceAdditional.FirstOrDefaultAsync(x => x.Id == item.Id);
                                    if (adata != null)
                                    {
                                        adata.Questions = item.Questions;

                                        _context.Entry(adata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var data = new AgricultureServiceAdditional()
                                        {
                                            ServiceId = model.Id,
                                            Questions = item.Questions,
                                        };
                                        await _context.AgricultureServiceAdditional.AddAsync(data);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        int wardId = await _utility.GetWardNoForLogin_Role_User();
                        var fiscal = new AgricultureService()
                        {
                            FiscalYearId = model.FiscalYearId,
                            ProgramId = model.ProgramId,
                            ProjectId = model.ProjectId,
                            ValidTillDate = model.ValidTillDate,
                            ValidTillDateEng = model.ValidTillDateEng,
                            ServiceName = model.ServiceName,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.AgricultureService.AddAsync(fiscal);
                        await _context.SaveChangesAsync();

                        if (model.AgricultureServiceAdditionalViewModelList != null)
                        {
                            foreach (var item in model.AgricultureServiceAdditionalViewModelList)
                            {
                                var data = new AgricultureServiceAdditional()
                                {
                                    ServiceId = fiscal.Id,
                                    Questions = item.Questions,
                                };
                                await _context.AgricultureServiceAdditional.AddAsync(data);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("AgricultureService Repo create/update with multiple table (AgricultureServiceAdditional) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
        #region ApplicatoionForm
        public async Task<List<AgricultureApplicatoionFormFileViewModel>> GetAllApplicatoionForm()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.AgricultureApplicatoionForm.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new AgricultureApplicatoionFormFileViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectId = x.ProjectId,
                    ServiceId = x.ServiceId,
                    FarmerTypeId = x.FarmerTypeId,
                    FarmerId = x.FarmerId,
                    AgriGroupId = x.AgriGroupId,
                    ContactName = x.ContactName,
                    Remarks = x.Remarks,

                    FiscalYearName = x.FiscalYear.Name,
                    ProgramName = x.AgricultureProgram.Title,
                    ProjectName = x.AgricultureProject.ProjectName,
                    ServiceName = x.AgricultureService.ServiceName,
                    FarmerorAgriGroupName = x.FarmerId == 1 ? x.Farmer.FullName : x.FarmerGroup.Name,
                    FarmerType = x.FarmerTypeId == 1 ? "व्यक्तिगत" : "समूह",
                }).ToListAsync();
        }
        public async Task<AgricultureApplicatoionFormFileViewModel> GetApplicatoionFormById(int id)
        {
            var data = await _context.AgricultureApplicatoionForm.Where(x => x.Id == id)
                .Select(x => new AgricultureApplicatoionFormFileViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectId = x.ProjectId,
                    ServiceId = x.ServiceId,
                    FarmerTypeId = x.FarmerTypeId,
                    FarmerId = x.FarmerId,
                    AgriGroupId = x.AgriGroupId,
                    ContactName = x.ContactName,
                    Remarks = x.Remarks,
                    CitizenPhotoPath = x.CitizenPhotoPath,
                    LandOwnershipPhotoPath = x.LandOwnershipPhotoPath,
                    PlanDetailPhotoPath = x.PlanDetailPhotoPath,
                    PanjikaranPhotoPath = x.PanjikaranPhotoPath,
                    SthailekhaPhotoPath = x.SthailekhaPhotoPath,
                    TaxPhotoPath = x.TaxPhotoPath,
                    MinutePhotoPath = x.MinutePhotoPath,
                    SelfdecisionPhotoPath = x.SelfdecisionPhotoPath
                }).FirstOrDefaultAsync() ?? new AgricultureApplicatoionFormFileViewModel();
            return data;
        }
        public async Task<bool> InsertUpdateApplicatoionForm(AgricultureApplicatoionFormViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var CitizenPhotoPath = "";
                var LandOwnershipPhotoPath = "";
                var PlanDetailPhotoPath = "";
                var PanjikaranPhotoPath = "";
                var SthailekhaPhotoPath = "";
                var TaxPhotoPath = "";
                var MinutePhotoPath = "";
                var SelfdecisionPhotoPath = "";
                try
                {
                    if (model.Id > 0)
                    {
                        var ApplicatoionForm = await _context.AgricultureApplicatoionForm.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (model.CitizenPhoto != null)
                        {
                            CitizenPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.CitizenPhoto, "Citizen").Result.FilePath;
                            if (ApplicatoionForm.CitizenPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.CitizenPhotoPath);
                            }
                        }
                        if (model.LandOwnershipPhoto != null)
                        {
                            LandOwnershipPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.LandOwnershipPhoto, "LandOwnership").Result.FilePath;
                            if (ApplicatoionForm.LandOwnershipPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.LandOwnershipPhotoPath);
                            }
                        }
                        if (model.PlanDetailPhoto != null)
                        {
                            PlanDetailPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.PlanDetailPhoto, "PlanDetail").Result.FilePath;
                            if (ApplicatoionForm.PlanDetailPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.PlanDetailPhotoPath);
                            }
                        }
                        if (model.PanjikaranPhoto != null)
                        {
                            PanjikaranPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.PanjikaranPhoto, "Panjikaran").Result.FilePath;
                            if (ApplicatoionForm.PanjikaranPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.PanjikaranPhotoPath);
                            }
                        }
                        if (model.SthailekhaPhoto != null)
                        {
                            SthailekhaPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.SthailekhaPhoto, "Sthailekha").Result.FilePath;
                            if (ApplicatoionForm.SthailekhaPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.SthailekhaPhotoPath);
                            }
                        }
                        if (model.TaxPhoto != null)
                        {
                            TaxPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.TaxPhoto, "Tax").Result.FilePath;
                            if (ApplicatoionForm.TaxPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.TaxPhotoPath);
                            }
                        }
                        if (model.MinutePhoto != null)
                        {
                            MinutePhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.MinutePhoto, "Minute").Result.FilePath;
                            if (ApplicatoionForm.MinutePhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.MinutePhotoPath);
                            }
                        }
                        if (model.SelfdecisionPhoto != null)
                        {
                            SelfdecisionPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.SelfdecisionPhoto, "Selfdecision").Result.FilePath;
                            if (ApplicatoionForm.SelfdecisionPhotoPath != null)
                            {
                                await _utility.RemoveFileFormServer(ApplicatoionForm.SelfdecisionPhotoPath);
                            }
                        }
                        if (ApplicatoionForm != null)
                        {
                            ApplicatoionForm.FiscalYearId = model.FiscalYearId;
                            ApplicatoionForm.ProgramId = model.ProgramId;
                            ApplicatoionForm.ProjectId = model.ProjectId;
                            ApplicatoionForm.ServiceId = model.ServiceId;
                            ApplicatoionForm.FarmerTypeId = model.FarmerTypeId;
                            ApplicatoionForm.FarmerId = model.FarmerId;
                            ApplicatoionForm.AgriGroupId = model.AgriGroupId;
                            ApplicatoionForm.ContactName = model.ContactName;
                            ApplicatoionForm.Remarks = model.Remarks;
                            ApplicatoionForm.CitizenPhotoPath = CitizenPhotoPath == "" ? ApplicatoionForm.CitizenPhotoPath : CitizenPhotoPath;
                            ApplicatoionForm.LandOwnershipPhotoPath = LandOwnershipPhotoPath == "" ? ApplicatoionForm.LandOwnershipPhotoPath : LandOwnershipPhotoPath;
                            ApplicatoionForm.PlanDetailPhotoPath = PlanDetailPhotoPath == "" ? ApplicatoionForm.PlanDetailPhotoPath : PlanDetailPhotoPath;
                            ApplicatoionForm.PanjikaranPhotoPath = PanjikaranPhotoPath == "" ? ApplicatoionForm.PanjikaranPhotoPath : PanjikaranPhotoPath;
                            ApplicatoionForm.SthailekhaPhotoPath = SthailekhaPhotoPath == "" ? ApplicatoionForm.SthailekhaPhotoPath : SthailekhaPhotoPath;
                            ApplicatoionForm.TaxPhotoPath = TaxPhotoPath == "" ? ApplicatoionForm.TaxPhotoPath : TaxPhotoPath;
                            ApplicatoionForm.MinutePhotoPath = MinutePhotoPath == "" ? ApplicatoionForm.MinutePhotoPath : MinutePhotoPath;
                            ApplicatoionForm.SelfdecisionPhotoPath = SelfdecisionPhotoPath == "" ? ApplicatoionForm .SelfdecisionPhotoPath : SelfdecisionPhotoPath;

                            ApplicatoionForm.UpdatedBy = _userId;
                            ApplicatoionForm.UpdatedDate = DateTime.Now;

                            _context.Entry(ApplicatoionForm).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (model.CitizenPhoto != null)
                        {
                            CitizenPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.CitizenPhoto, "Citizen").Result.FilePath;
                        }
                        if (model.LandOwnershipPhoto != null)
                        {
                            LandOwnershipPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.LandOwnershipPhoto, "LandOwnership").Result.FilePath;
                        }
                        if (model.PlanDetailPhoto != null)
                        {
                            PlanDetailPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.PlanDetailPhoto, "PlanDetail").Result.FilePath;
                        }
                        if (model.PanjikaranPhoto != null)
                        {
                            PanjikaranPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.PanjikaranPhoto, "Panjikaran").Result.FilePath;
                        }
                        if (model.SthailekhaPhoto != null)
                        {
                            SthailekhaPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.SthailekhaPhoto, "Sthailekha").Result.FilePath;
                        }
                        if (model.TaxPhoto != null)
                        {
                            TaxPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.TaxPhoto, "Tax").Result.FilePath;
                        }
                        if (model.MinutePhoto != null)
                        {
                            MinutePhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.MinutePhoto, "Minute").Result.FilePath;
                        }
                        if (model.SelfdecisionPhoto != null)
                        {
                            SelfdecisionPhotoPath = _utility.UploadImgReturnPathAndName("ApplicatoionForm", model.SelfdecisionPhoto, "Selfdecision").Result.FilePath;
                        }
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var fiscal = new AgricultureApplicatoionForm()
                        {
                            FiscalYearId = model.FiscalYearId,
                            ProgramId = model.ProgramId,
                            ProjectId = model.ProjectId,
                            ServiceId = model.ServiceId,
                            FarmerTypeId = model.FarmerTypeId,
                            FarmerId = model.FarmerId,
                            AgriGroupId = model.AgriGroupId,
                            ContactName = model.ContactName,
                            Remarks = model.Remarks,
                            CitizenPhotoPath = CitizenPhotoPath,
                            LandOwnershipPhotoPath = LandOwnershipPhotoPath,
                            PlanDetailPhotoPath = PlanDetailPhotoPath,
                            PanjikaranPhotoPath = PanjikaranPhotoPath,
                            SthailekhaPhotoPath = SthailekhaPhotoPath,
                            TaxPhotoPath = TaxPhotoPath,
                            MinutePhotoPath = MinutePhotoPath,
                            SelfdecisionPhotoPath = SelfdecisionPhotoPath,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.AgricultureApplicatoionForm.AddAsync(fiscal);
                        await _context.SaveChangesAsync();

                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("AgricultureApplicatoionForm Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion

    }
}
