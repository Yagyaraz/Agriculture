using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Models;
using Agriculture.Security;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Utilities
{
    public class Utility : IUtility
    {
        private readonly AgricultureDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<Utility> _logger;
        private readonly string _userId;

        public Utility(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHost, ILogger<Utility> logger)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHost;
            _logger = logger;
            _userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task<SelectList> GetFarmerSelectListItems()
        {
            return new SelectList(await _context.Farmer.ToListAsync(), "Id", "FullName");
        }
        public async Task<int> GetWardNoForLogin_Role_User()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int? wardId = await _context.Users.Where(x => x.Id == userId).Select(x => x.WardId).FirstOrDefaultAsync();
            return wardId == null ? 0 : wardId.Value;
        }
        public async Task<int> GetWardNoForLogin_Role_FarmerId()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var farmerId = await (from u in _context.Users
                                  join f in _context.Farmer on u.Email equals f.Email
                                  where u.Id == userId
                                  select f.Id)
                          .FirstOrDefaultAsync();

            return farmerId > 0 ? farmerId : 0;
        }
        public async Task<SelectList> GetWardNoSelectListItems()
        {
            return new SelectList(await _context.Ward.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetStateSelectListItems()
        {
            return new SelectList(await _context.State.ToListAsync(), "StateId", "StateNameNep");
        }
        public async Task<SelectList> GetFiscalYearSelectListItems()
        {
            return new SelectList(await _context.FiscalYear.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetDistrictSelectListItems(int? stateId)
        {
            return new SelectList(await _context.District.Where(x => (x.StateId == stateId || stateId == null)).ToListAsync(), "DistrictId", "DistrictNameNep");
        }
        public async Task<SelectList> GetPalikaSelectListItems(int? distId)
        {
            return new SelectList(await _context.Palika.Where(x => (x.DistrictId == distId || distId == null)).ToListAsync(), "PalikaId", "PalikaNameNep");
        }
        public async Task<SelectList> GetPalikaEngSelectListItems(int? distId)
        {
            distId = distId == 0 ? null : distId;
            return new SelectList(await _context.District.Where(x => (x.StateId == distId || distId == null)).ToListAsync(), "DistrictId", "DistrictNameNep");
        }
        public async Task<FileUploadModel> UploadImgReturnPathAndName(string folderName, IFormFile file, string name)
        {
            try
            {
                var model = new FileUploadModel();
                string defaultFolder = "UploadAllFiles";
                if (file == null) return model;
                name = string.IsNullOrEmpty(name) ? "Agriculture" : name;
                var fileExt = Path.GetExtension(file.FileName).Substring(1);
                folderName = string.IsNullOrEmpty(folderName) ? defaultFolder : folderName;
                folderName = folderName.Equals(defaultFolder) ? $"{defaultFolder}/AppImage/" : $"{defaultFolder}/{folderName}/";
                model.FileName = name + "_" + Guid.NewGuid().ToString() + "." + fileExt;
                var returnPath = folderName + model.FileName;
                if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                {
                    _webHostEnvironment.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);// if Path not present than create

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, returnPath);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                model.FilePath = "/" + returnPath;
                return model;
            }
            catch (Exception ex)
            {
                return new FileUploadModel();
            }
        }
        public Task RemoveFileFormServer(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path)) return Task.CompletedTask;
                string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot" + path);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("File Remove Error : " + ex.Message);
            }
            return Task.CompletedTask;
        }
        public async Task<int> GetCurrentFiscalYearId()
        {

            var id = await _context.FiscalYear.Where(x => x.IsActive == true).Select(x => x.Id).FirstOrDefaultAsync();
            return id;
        }
        public async Task<SelectList> GetGenderSelectListItems()
        {
            return new SelectList(await _context.Gender.ToListAsync(), "Id", "Name");
        }

        public async Task<SelectList> GetEducationSelectListItems()
        {
            return new SelectList(await _context.Education.ToListAsync(), "Id", "Name");
        }

        public async Task<SelectList> GetEducationLevelSelectListItems()
        {
            return new SelectList(await _context.EducationLevel.ToListAsync(), "Id", "Name");
        }

        public async Task<SelectList> GetFarmerGroupSelectListItems()
        {
            return new SelectList(await _context.FarmerGroup.ToListAsync(), "Id", "Name");
        }

        public async Task<SelectList> GetFarmerCategorySelectListItems()
        {
            return new SelectList(await _context.FarmerCategory.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetOnlyDistrictSelectListItems()
        {
            return new SelectList(await _context.District.ToListAsync(), "DistrictId", "DistrictNameNep");
        }
        public async Task<SelectList> GetAvgmonthSelectListItems()
        {
            return new SelectList(await _context.AvgMonth.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAgriSectorSelectListItems()
        {
            return new SelectList(await _context.AgriSector.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAgriServiceSelectListItems(int id)
        {
            return new SelectList(await _context.AgriService.Where(x => x.AgriSectorId == id).ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetRelationSelectListItems()
        {
            return new SelectList(await _context.Relation.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetWorkingAreaSelectListItems()
        {
            return new SelectList(await _context.WorkingArea.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetOwnershipSelectListItems()
        {
            return new SelectList(await _context.OwnershipType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetLandTypeSelectListItems()
        {
            return new SelectList(await _context.LandType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetIrrigationSourceSelectListItems()
        {
            return new SelectList(await _context.IrrigationSource.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetCropsTypeSelectListItems()
        {
            return new SelectList(await _context.CropsType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetFruitsTypeSelectListItems()
        {
            return new SelectList(await _context.FruitsType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetSeedsTypeSelectListItems()
        {
            return new SelectList(await _context.SeedsType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetMushroomTypeSelectListItems()
        {
            return new SelectList(await _context.MushroomType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetSilkTypeSelectListItems()
        {
            return new SelectList(await _context.SilkType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetBeeTypeSelectListItems()
        {
            return new SelectList(await _context.BeeType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetProcustionMeasurementSelectListItems()
        {
            return new SelectList(await _context.ProcustionMeasurement.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetProcustionUseSelectListItems()
        {
            return new SelectList(await _context.ProcustionUse.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetKrishiFarmTypeSelectListItems()
        {
            return new SelectList(await _context.KrishiFarmType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetPostSelectListItems()
        {
            return new SelectList(await _context.Post.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAgriGroupTypeSelectListItems()
        {
            return new SelectList(await _context.AgriGroupType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetProgramSelectListItems()
        {
            return new SelectList(await _context.AgricultureProgram.ToListAsync(), "Id", "Title");
        }
        public async Task<SelectList> GetMeasuringUnitSelectListItems()
        {
            return new SelectList(await _context.MeasuringUnit.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetCategorySelectListItems()
        {
            return new SelectList(await _context.Category.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetSubCategorySelectListItems(int id)
        {
            return new SelectList(await _context.SubCategory.Where(x => x.CategoryId == id).ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetProjectSelectListItems(int id)
        {
            return new SelectList(await _context.AgricultureProject.Where(x => (x.ProgramId == id || id == null)).ToListAsync(), "Id", "ProjectName");
        }
        public async Task<SelectList> GetServiceByProjectId(int id)
        {
            return new SelectList(await _context.AgricultureService.Where(x => (x.ProjectId == id || id == null)).ToListAsync(), "Id", "ServiceName");
        }

        public async Task<SelectList> GetAgriCalendarTypeSelectListItems()
        {
            return new SelectList(await _context.AgriCalendarType.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAgriCalendarCategorySelectListItems(int id)
        {
            return new SelectList(await _context.AgriCalendarCategory.Where(x => x.AgriCalendarTypeId == id).ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAgriCalendarProductSelectListItems(int id)
        {
            return new SelectList(await _context.AgriCalendarProduct.Where(x => x.AgriCalendarCategoryId == id).ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetMonthSelectListItems()
        {
            return new SelectList(await _context.Month.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAgriCalendarWeekSelectListItems()
        {
            return new SelectList(await _context.Week.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetEcologicalAreaSelectListItems()
        {
            return new SelectList(await _context.EcologicalArea.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetMarketSelectListItems()
        {
            return new SelectList(await _context.Market.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetAlbumSelectListItems()
        {
            return new SelectList(await _context.Album.Where(x => x.IsPublised == true).ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetPlaylistSelectListItems()
        {
            return new SelectList(await _context.Playlist.Where(x => x.IsPublised == true).ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetSelectListRoles()
        {
            var aa = await _context.Roles.Where(x => x.Name != UserRoles.Administrator && x.Name != UserRoles.SuperAdmin).ToListAsync();
            return new SelectList(await _context.Roles.Where(x => x.Name != UserRoles.Administrator && x.Name != UserRoles.SuperAdmin).ToListAsync(), "Name", "Name");
        }
        public async Task<OfficeViewModel> GetOfficeDetails()
        {
            var data=await _context.Office.Select(x=>new OfficeViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Name_En = x.Name_En,
                Code = x.Code,
                Address = x.Address,
                PhoneNo = x.PhoneNo,
                FaxNo = x.FaxNo,
                Email = x.Email,
                PalikaId = x.PalikaId,
                PalikaName = x.Palika.PalikaNameNep,
                StateName = x.State.StateNameNep,
                DistrictName = x.District.DistrictNameNep,
                StateName_En = x.State.StateName,
                DistrictName_En = x.District.DistrictName,
                PalikaName_En = x.Palika.PalikaName,
                Url = x.Url,
                StateId = x.StateId,
                DistrictId = x.DistrictId,
            }).FirstOrDefaultAsync();
            return data??new OfficeViewModel();
        }
    }
}