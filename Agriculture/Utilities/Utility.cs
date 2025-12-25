using Agriculture.Areas.Admin.Models;
using Agriculture.Constants;
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
        public async Task<bool> Delete(string tableName, int id)
        {
            if (!AllowedTables.Contains(tableName))
                throw new UnauthorizedAccessException("Invalid table name");
            if (string.IsNullOrWhiteSpace(tableName))
                return false;
            var sql = $"UPDATE [{tableName}] SET IsDeleted = 1 WHERE Id = @p0";

            var affectedRows = await _context.Database.ExecuteSqlRawAsync(sql, id);
            return affectedRows > 0;

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
            var data = await _context.Office.Select(x => new OfficeViewModel()
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
            return data ?? new OfficeViewModel();
        }
        #region by id utility (nullable)

        public async Task<string> GetGenderNameById(int? id) =>
            id == null ? "-" :
            (await _context.Gender.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetEducationNameById(int? id) =>
            id == null ? "-" :
            (await _context.Education.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetEducationLevelNameById(int? id) =>
            id == null ? "-" :
            (await _context.EducationLevel.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetFarmerGroupNameById(int? id) =>
            id == null ? "-" :
            (await _context.FarmerGroup.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetFarmerCategoryNameById(int? id) =>
            id == null ? "-" :
            (await _context.FarmerCategory.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetDistrictNameById(int? id) =>
            id == null ? "-" :
            (await _context.District.FirstOrDefaultAsync(x => x.DistrictId == id))?.DistrictNameNep ?? "-";

        public async Task<string> GetPalikaNameById(int? id) =>
            id == null ? "-" :
            (await _context.Palika.FirstOrDefaultAsync(x => x.PalikaId == id))?.PalikaNameNep ?? "-";

        public async Task<string> GetAvgMonthNameById(int? id) =>
            id == null ? "-" :
            (await _context.AvgMonth.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetAgriSectorNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgriSector.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetAgriServiceNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgriService.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetRelationNameById(int? id) =>
            id == null ? "-" :
            (await _context.Relation.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetWorkingAreaNameById(int? id) =>
            id == null ? "-" :
            (await _context.WorkingArea.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetOwnershipNameById(int? id) =>
            id == null ? "-" :
            (await _context.OwnershipType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetLandTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.LandType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetIrrigationSourceNameById(int? id) =>
            id == null ? "-" :
            (await _context.IrrigationSource.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetCropsTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.CropsType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetFruitsTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.FruitsType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetSeedsTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.SeedsType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetMushroomTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.MushroomType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetSilkTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.SilkType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetBeeTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.BeeType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetProcustionMeasurementNameById(int? id) =>
            id == null ? "-" :
            (await _context.ProcustionMeasurement.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetProcustionUseNameById(int? id) =>
            id == null ? "-" :
            (await _context.ProcustionUse.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetKrishiFarmTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.KrishiFarmType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetPostNameById(int? id) =>
            id == null ? "-" :
            (await _context.Post.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetAgriGroupTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgriGroupType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetProgramNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgricultureProgram.FirstOrDefaultAsync(x => x.Id == id))?.Title ?? "-";

        public async Task<string> GetMeasuringUnitNameById(int? id) =>
            id == null ? "-" :
            (await _context.MeasuringUnit.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetCategoryNameById(int? id) =>
            id == null ? "-" :
            (await _context.Category.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetSubCategoryNameById(int? id) =>
            id == null ? "-" :
            (await _context.SubCategory.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetProjectNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgricultureProject.FirstOrDefaultAsync(x => x.Id == id))?.ProjectName ?? "-";

        public async Task<string> GetServiceNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgricultureService.FirstOrDefaultAsync(x => x.Id == id))?.ServiceName ?? "-";

        public async Task<string> GetAgriCalendarTypeNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgriCalendarType.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetAgriCalendarCategoryNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgriCalendarCategory.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetAgriCalendarProductNameById(int? id) =>
            id == null ? "-" :
            (await _context.AgriCalendarProduct.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetMonthNameById(int? id) =>
            id == null ? "-" :
            (await _context.Month.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetWeekNameById(int? id) =>
            id == null ? "-" :
            (await _context.Week.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetEcologicalAreaNameById(int? id) =>
            id == null ? "-" :
            (await _context.EcologicalArea.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetMarketNameById(int? id) =>
            id == null ? "-" :
            (await _context.Market.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        public async Task<string> GetAlbumNameById(int? id) =>
            id == null ? "-" :
            (await _context.Album.FirstOrDefaultAsync(x => x.Id == id && x.IsPublised))?.Name ?? "-";

        public async Task<string> GetPlaylistNameById(int? id) =>
            id == null ? "-" :
            (await _context.Playlist.FirstOrDefaultAsync(x => x.Id == id && x.IsPublised))?.Name ?? "-";

        public async Task<string> GetStateNameById(int? id) =>
            id == null ? "-" :
            (await _context.State.FirstOrDefaultAsync(x => x.StateId == id))?.StateNameNep ?? "-";

        public async Task<string> GetFiscalYearNameById(int? id) =>
            id == null ? "-" :
            (await _context.FiscalYear.FirstOrDefaultAsync(x => x.Id == id))?.Name ?? "-";

        #endregion

        private static readonly HashSet<string> AllowedTables = new(StringComparer.OrdinalIgnoreCase)
    {
        TableNameConstants.FarmerCategory,
        TableNameConstants.Farmer,
        TableNameConstants.FarmerFile,
        TableNameConstants.KrishiDetails,
        TableNameConstants.AgricultureDetail,
        TableNameConstants.AvgMonth,
        TableNameConstants.AgriSector,
        TableNameConstants.AgriService,
        TableNameConstants.Relation,
        TableNameConstants.WorkingArea,
        TableNameConstants.FamilyDetails,
        TableNameConstants.FamilyDetailsInvolvedInAgri,
        TableNameConstants.FieldDetails,
        TableNameConstants.LandOwnership,
        TableNameConstants.AgriFarmMoreThanOneLocalLevel,
        TableNameConstants.LeasedLandDetail,
        TableNameConstants.OwnershipType,
        TableNameConstants.LandType,
        TableNameConstants.IrrigationSource,

        TableNameConstants.CropsInformation,
        TableNameConstants.EatableCrops,
        TableNameConstants.FruitCrops,
        TableNameConstants.SeedCrops,
        TableNameConstants.MushroomCrpos,
        TableNameConstants.SilkCrops,
        TableNameConstants.BeeCrops,
        TableNameConstants.CropsType,
        TableNameConstants.FruitsType,
        TableNameConstants.SeedsType,
        TableNameConstants.MushroomType,
        TableNameConstants.SilkType,
        TableNameConstants.BeeType,

        TableNameConstants.AnimalSetup,
        TableNameConstants.AnimalHusbandry,
        TableNameConstants.CowInfromation,
        TableNameConstants.BuffaloInfromation,
        TableNameConstants.CharuiYakInfromation,
        TableNameConstants.GoruInfromation,
        TableNameConstants.BhedaBakhraInfromation,
        TableNameConstants.BungurSungurInfromation,
        TableNameConstants.HenInfromation,
        TableNameConstants.OtherBirdInfromation,
        TableNameConstants.FishInfromation,
        TableNameConstants.OtherAnimalInfromation,
        TableNameConstants.GhaseBaliInfromation,
        TableNameConstants.KrishiFarmInfromation,
        TableNameConstants.KrishiMechinaryInfromation,
        TableNameConstants.KrishiSanrachanaInfromation,
        TableNameConstants.KrishiFarmType,
        TableNameConstants.ProcustionUse,
        TableNameConstants.ProcustionMeasurement,

        TableNameConstants.AgricultureFarmerGroup,
        TableNameConstants.OfficialsDetail,
        TableNameConstants.AgriGroupType,
        TableNameConstants.Post,

        TableNameConstants.AgricultureProgram,
        TableNameConstants.AgricultureProject,
        TableNameConstants.AgricultureService,
        TableNameConstants.AgricultureServiceAdditional,
        TableNameConstants.AgricultureApplicatoionForm,

        TableNameConstants.Category,
        TableNameConstants.SubCategory,
        TableNameConstants.MeasuringUnit,
        TableNameConstants.Subsidy,
        TableNameConstants.SubsidyDetail,
        TableNameConstants.SaveRequestedSubsidy,
        TableNameConstants.OtherSubsidy,
        TableNameConstants.OtherSubsidyQns,

        TableNameConstants.Library,
        TableNameConstants.Training,

        TableNameConstants.AgriCalendar,
        TableNameConstants.AgriCalendarDetail,
        TableNameConstants.AgriCalendarType,
        TableNameConstants.AgriCalendarCategory,
        TableNameConstants.AgriCalendarProduct,
        TableNameConstants.EcologicalArea,
        TableNameConstants.Month,
        TableNameConstants.Week,

        TableNameConstants.FertilizerStore,
        TableNameConstants.FertilizerStoreProduction,
        TableNameConstants.FertilizerStoreContactPerson,

        TableNameConstants.SeedStore,
        TableNameConstants.SeedStoreProduction,
        TableNameConstants.SeedStoreContactPerson,

        TableNameConstants.InsuranceCenter,
        TableNameConstants.AgricultureEquipment,

        TableNameConstants.Market,
        TableNameConstants.MarketPrice,
        TableNameConstants.MarketPriceDetails,

        TableNameConstants.Album,
        TableNameConstants.ImageGallery,

        TableNameConstants.Playlist,
        TableNameConstants.VideoGallery,

        TableNameConstants.FarmerServiceCard,
        TableNameConstants.FarmerServiceCardDetail,

        TableNameConstants.Ward,
        TableNameConstants.Gunaso,
        TableNameConstants.Suchana,
        TableNameConstants.Nabikaran,
        TableNameConstants.ApplicationForm
    };

    }

}