using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agriculture.Areas.Admin.Repositories
{
    public class FarmerRepository : IFarmer
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<FarmerRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public FarmerRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<FarmerRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }
        public async Task<List<FarmerViewModel>> GetAllFarmer()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Farmer.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new FarmerViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    FullNameEng = x.FullNameEng,
                    StateId = x.StateId,
                    DistrictId = x.DistrictId,
                    PalikaId = x.PalikaId,
                    WardNo = x.WardNo,
                    PhoneNo = x.PhoneNo,
                    Email = x.Email,
                    GenderId = x.GenderId,
                    DOBNep = x.DOBNep,
                    DOBEng = x.DOBEng,
                    EducationId = x.EducationId,
                    EducationLevelId = x.EducationLevelId,
                    TolName = x.TolName,
                    CitizenNo = x.CitizenNo,
                    CitizenDistricrId = x.CitizenDistricrId,
                    CitizenIssueDate = x.CitizenIssueDate,
                    FarmerGroupId = x.FarmerGroupId,
                    FarmerCategoryId = x.FarmerCategoryId,
                    HouseNo = x.HouseNo,
                    Gender = x.Gender.Name,
                }).ToListAsync();
        }
        public async Task<FarmerViewModel> GetFarmerById(int id)
        {
            return await _context.Farmer.Where(x => x.Id == id)
                .Select(x => new FarmerViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    FullNameEng = x.FullNameEng,
                    StateId = x.StateId,
                    DistrictId = x.DistrictId,
                    PalikaId = x.PalikaId,
                    WardNo = x.WardNo,
                    PhoneNo = x.PhoneNo,
                    Email = x.Email,
                    GenderId = x.GenderId,
                    DOBNep = x.DOBNep,
                    DOBEng = x.DOBEng,
                    EducationId = x.EducationId,
                    EducationLevelId = x.EducationLevelId,
                    TolName = x.TolName,
                    CitizenNo = x.CitizenNo,
                    CitizenDistricrId = x.CitizenDistricrId,
                    CitizenIssueDate = x.CitizenIssueDate,
                    FarmerGroupId = x.FarmerGroupId,
                    FarmerCategoryId = x.FarmerCategoryId,
                    HouseNo = x.HouseNo,
                }).FirstOrDefaultAsync() ?? new FarmerViewModel();
        }

        public async Task<(bool, int newId)> InsertUpdateFarmer(FarmerViewModel model)
        {
            try
            {
                int newId = 0;
                var Farmer = await _context.Farmer.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (Farmer != null)
                {
                    Farmer.FullName = model.FullName;
                    Farmer.FullNameEng = model.FullNameEng;
                    Farmer.StateId = model.StateId;
                    Farmer.DistrictId = model.DistrictId;
                    Farmer.PalikaId = model.PalikaId;
                    Farmer.WardNo = model.WardNo;
                    Farmer.PhoneNo = model.PhoneNo;
                    Farmer.Email = model.Email;
                    Farmer.GenderId = model.GenderId;
                    Farmer.DOBNep = model.DOBNep;
                    Farmer.DOBEng = model.DOBEng;
                    Farmer.EducationId = model.EducationId;
                    Farmer.EducationLevelId = model.EducationLevelId;
                    Farmer.TolName = model.TolName;
                    Farmer.CitizenNo = model.CitizenNo;
                    Farmer.CitizenDistricrId = model.CitizenDistricrId;
                    Farmer.CitizenIssueDate = model.CitizenIssueDate;
                    Farmer.FarmerGroupId = model.FarmerGroupId;
                    Farmer.FarmerCategoryId = model.FarmerCategoryId;
                    Farmer.HouseNo = model.HouseNo;
                    Farmer.UpdatedBy = _userId;
                    Farmer.UpdatedDate = DateTime.Now;

                    _context.Entry(Farmer).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    newId = Farmer.Id;
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();
                    var fiscal = new Farmer()
                    {
                        FullName = model.FullName,
                        FullNameEng = model.FullNameEng,
                        StateId = model.StateId,
                        DistrictId = model.DistrictId,
                        PalikaId = model.PalikaId,
                        WardNo = model.WardNo,
                        PhoneNo = model.PhoneNo,
                        Email = model.Email,
                        GenderId = model.GenderId,
                        DOBNep = model.DOBNep,
                        DOBEng = model.DOBEng,
                        EducationId = model.EducationId,
                        EducationLevelId = model.EducationLevelId,
                        TolName = model.TolName,
                        CitizenNo = model.CitizenNo,
                        CitizenDistricrId = model.CitizenDistricrId,
                        CitizenIssueDate = model.CitizenIssueDate,
                        FarmerGroupId = model.FarmerGroupId,
                        FarmerCategoryId = model.FarmerCategoryId,
                        HouseNo = model.HouseNo,
                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                        CreatedWardId = wardId,
                    };
                    await _context.Farmer.AddAsync(fiscal);
                    await _context.SaveChangesAsync();
                    newId = fiscal.Id;
                }
                return (true, newId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Farmer Repo create/update  Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                return (false, 0);
            }
        }


        public async Task<KrishiDetailsViewModel> GetKrishiDetail(int id)
        {
            var data = await _context.KrishiDetails.Where(x => x.FarmerId == id)
                .Select(x => new KrishiDetailsViewModel()
                {
                    Id = x.Id,
                    FarmerId = x.FarmerId,
                    FiscalYearId = x.FiscalYearId,
                    IsSelfJagga = x.IsSelfJagga,
                    ChooseLand = x.ChooseLand,
                    TotalBigaha = x.TotalBigaha,
                    TotalKattha = x.TotalKattha,
                    TotalDhur = x.TotalDhur,
                    TotalBigaSquareMiter = x.TotalBigaSquareMiter,
                    TotalRopani = x.TotalRopani,
                    TotalAana = x.TotalAana,
                    TotalPaisa = x.TotalPaisa,
                    TotalDam = x.TotalDam,
                    TotalRopaniSquareMiter = x.TotalRopaniSquareMiter,
                    IncomeFromAgri = x.IncomeFromAgri,
                    IncomeFromNonAgri = x.IncomeFromNonAgri,
                    TotalIncome = x.TotalIncome,
                    AvgMonthForAgriId = x.AvgMonthForAgriId,
                    AgricultureDetailViewModelList = _context.AgricultureDetail.Where(z => z.KrishiDetailsId == x.Id)
                    .Select(z => new AgricultureDetailViewModel()
                    {
                        Id = z.Id,
                        KrishiDetailsId = z.KrishiDetailsId,
                        AgriWardNo = z.AgriWardNo,
                        AgriAddress = z.AgriAddress,
                        AgriSectorId = z.AgriSectorId,
                        AgriSubSector = z.AgriSubSector,
                    }).ToList() ?? new List<AgricultureDetailViewModel>(),
                }).FirstOrDefaultAsync() ?? new KrishiDetailsViewModel();
            return data;
        }

        public async Task<bool> InsertUpdateKrishiDetail(KrishiDetailsViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.KrishiDetails.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.FarmerId = model.FarmerId;
                            data.FiscalYearId = model.FiscalYearId;
                            data.IsSelfJagga = model.IsSelfJagga;
                            data.ChooseLand = model.ChooseLand;
                            data.TotalBigaha = model.TotalBigaha;
                            data.TotalKattha = model.TotalKattha;
                            data.TotalDhur = model.TotalDhur;
                            data.TotalBigaSquareMiter = model.TotalBigaSquareMiter;
                            data.TotalRopani = model.TotalRopani;
                            data.TotalAana = model.TotalAana;
                            data.TotalPaisa = model.TotalPaisa;
                            data.TotalDam = model.TotalDam;
                            data.TotalRopaniSquareMiter = model.TotalRopaniSquareMiter;
                            data.IncomeFromAgri = model.IncomeFromAgri;
                            data.IncomeFromNonAgri = model.IncomeFromNonAgri;
                            data.TotalIncome = model.TotalIncome;
                            data.AvgMonthForAgriId = model.AvgMonthForAgriId;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.AgricultureDetailViewModelList != null)
                            {
                                foreach (var item in await _context.AgricultureDetail.Where(x => x.KrishiDetailsId == model.Id).ToListAsync())
                                {
                                    if (!model.AgricultureDetailViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.AgricultureDetail.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.AgricultureDetailViewModelList)
                                {
                                    var agdata = _context.AgricultureDetail.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.AgriWardNo = item.AgriWardNo;
                                        agdata.AgriAddress = item.AgriAddress;
                                        agdata.AgriSectorId = item.AgriSectorId;
                                        agdata.AgriSubSector = item.AgriSubSector;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new AgricultureDetail()
                                        {
                                            KrishiDetailsId = model.Id,
                                            AgriWardNo = item.AgriWardNo,
                                            AgriAddress = item.AgriAddress,
                                            AgriSectorId = item.AgriSectorId,
                                            AgriSubSector = item.AgriSubSector,
                                        };
                                        await _context.AgricultureDetail.AddAsync(newdata);
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
                        var data = new KrishiDetails()
                        {
                            FarmerId = model.FarmerId,
                            FiscalYearId = model.FiscalYearId,
                            IsSelfJagga = model.IsSelfJagga,
                            ChooseLand = model.ChooseLand,
                            TotalBigaha = model.TotalBigaha,
                            TotalKattha = model.TotalKattha,
                            TotalDhur = model.TotalDhur,
                            TotalBigaSquareMiter = model.TotalBigaSquareMiter,
                            TotalRopani = model.TotalRopani,
                            TotalAana = model.TotalAana,
                            TotalPaisa = model.TotalPaisa,
                            TotalDam = model.TotalDam,
                            TotalRopaniSquareMiter = model.TotalRopaniSquareMiter,
                            IncomeFromAgri = model.IncomeFromAgri,
                            IncomeFromNonAgri = model.IncomeFromNonAgri,
                            TotalIncome = model.TotalIncome,
                            AvgMonthForAgriId = model.AvgMonthForAgriId,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.KrishiDetails.AddAsync(data);
                        await _context.SaveChangesAsync();

                        if (model.AgricultureDetailViewModelList != null)
                        {
                            foreach (var item in model.AgricultureDetailViewModelList)
                            {
                                var newdata = new AgricultureDetail()
                                {
                                    KrishiDetailsId = data.Id,
                                    AgriWardNo = item.AgriWardNo,
                                    AgriAddress = item.AgriAddress,
                                    AgriSectorId = item.AgriSectorId,
                                    AgriSubSector = item.AgriSubSector,
                                };
                                await _context.AgricultureDetail.AddAsync(newdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("KrishiDetail Repo create/update with multiple table (Agridetail) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }



        public async Task<FamilyDetailssViewModel> GetFamilyDetails(int id)
        {
            try
            {
                var data = await _context.FamilyDetails.Where(x => x.FarmerId == id)
                       .Select(x => new FamilyDetailssViewModel()
                       {
                           Id = x.Id,
                           FarmerId = x.FarmerId,
                           FiscalYearId = x.FiscalYearId,
                           TotalMale = x.TotalMale,
                           TotalFemale = x.TotalFemale,
                           TotalMember = x.TotalMember,
                           TotalMaleInAgri = x.TotalMaleInAgri,
                           TotalFemaleInAgri = x.TotalFemaleInAgri,
                           TotalMemberInAgri = x.TotalMemberInAgri,
                           TotalInvolvedinAgi = x.TotalInvolvedinAgi,

                           FamilyDetailInvolveList = _context.FamilyDetailsInvolvedInAgri.Where(z => z.FamilyDetailsId == x.Id)
                           .Select(z => new FamilyDetailsInvolvedInAgriViewModel()
                           {
                               Id = z.Id,
                               FamilyDetailsId = z.FamilyDetailsId,
                               RelationId = z.RelationId,
                               FullName = z.FullName,
                               Age = z.Age,
                               GenderId = z.GenderId,
                               WorkingAreaId = z.WorkingAreaId,
                               CitizenNo = z.CitizenNo,
                               PhoneNumbar = z.PhoneNumbar,
                           }).ToList() ?? new List<FamilyDetailsInvolvedInAgriViewModel>(),
                       }).FirstOrDefaultAsync() ?? new FamilyDetailssViewModel();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> InsertUpdateFamilyDetails(FamilyDetailssViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.FamilyDetails.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.FarmerId = model.FarmerId;
                            data.FiscalYearId = model.FiscalYearId;
                            data.TotalMale = model.TotalMale;
                            data.TotalFemale = model.TotalFemale;
                            data.TotalMember = model.TotalMember;
                            data.TotalMaleInAgri = model.TotalMaleInAgri;
                            data.TotalFemaleInAgri = model.TotalFemaleInAgri;
                            data.TotalMemberInAgri = model.TotalMemberInAgri;
                            data.TotalInvolvedinAgi = model.TotalInvolvedinAgi;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            if (model.FamilyDetailInvolveList != null)
                            {
                                foreach (var item in await _context.FamilyDetailsInvolvedInAgri.Where(x => x.FamilyDetailsId == model.Id).ToListAsync())
                                {
                                    if (!model.FamilyDetailInvolveList.Any(x => x.Id == item.Id))
                                    {
                                        _context.FamilyDetailsInvolvedInAgri.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.FamilyDetailInvolveList)
                                {
                                    var agdata = _context.FamilyDetailsInvolvedInAgri.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.RelationId = item.RelationId;
                                        agdata.FullName = item.FullName;
                                        agdata.Age = item.Age;
                                        agdata.GenderId = item.GenderId;
                                        agdata.WorkingAreaId = item.WorkingAreaId;
                                        agdata.CitizenNo = item.CitizenNo;
                                        agdata.PhoneNumbar = item.PhoneNumbar;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new FamilyDetailsInvolvedInAgri()
                                        {
                                            FamilyDetailsId = model.Id,
                                            RelationId = item.RelationId,
                                            FullName = item.FullName,
                                            Age = item.Age,
                                            GenderId = item.GenderId,
                                            WorkingAreaId = item.WorkingAreaId,
                                            CitizenNo = item.CitizenNo,
                                            PhoneNumbar = item.PhoneNumbar,
                                        };
                                        await _context.FamilyDetailsInvolvedInAgri.AddAsync(newdata);
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
                        var data = new FamilyDetails()
                        {
                            FarmerId = model.FarmerId,
                            FiscalYearId = model.FiscalYearId,
                            TotalMale = model.TotalMale,
                            TotalFemale = model.TotalFemale,
                            TotalMember = model.TotalMember,
                            TotalMaleInAgri = model.TotalMaleInAgri,
                            TotalFemaleInAgri = model.TotalFemaleInAgri,
                            TotalMemberInAgri = model.TotalMemberInAgri,


                            TotalInvolvedinAgi = model.TotalInvolvedinAgi,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.FamilyDetails.AddAsync(data);
                        await _context.SaveChangesAsync();
                        if (model.FamilyDetailInvolveList != null)
                        {
                            foreach (var item in model.FamilyDetailInvolveList)
                            {
                                var newdata = new FamilyDetailsInvolvedInAgri()
                                {
                                    FamilyDetailsId = data.Id,
                                    RelationId = item.RelationId,
                                    FullName = item.FullName,
                                    Age = item.Age,
                                    GenderId = item.GenderId,
                                    WorkingAreaId = item.WorkingAreaId,
                                    CitizenNo = item.CitizenNo,
                                    PhoneNumbar = item.PhoneNumbar,
                                };
                                await _context.FamilyDetailsInvolvedInAgri.AddAsync(newdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Familydetail Repo create/update with multiple table (family involvein Agri) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }



        public async Task<FieldDetailsViewModel> GetFieldDetails(int id)
        {
            try
            {
                var data = await _context.FieldDetails.Where(x => x.FarmerId == id)
                       .Select(x => new FieldDetailsViewModel()
                       {
                           Id = x.Id,
                           FarmerId = x.FarmerId,
                           FiscalYearId = x.FiscalYearId,
                           IsKrishakDarta = x.IsKrishakDarta,
                           DartaNo = x.DartaNo,
                           FullName = x.FullName,
                           PhoneNo = x.PhoneNo,
                           Address = x.Address,
                           SanjhutaMiti = x.SanjhutaMiti,
                           SanjhutaDate = x.SanjhutaDate,
                           SamjhutaEndMiti = x.SamjhutaEndMiti,
                           SamjhutaEndDate = x.SamjhutaEndDate,
                           CitizenNo = x.CitizenNo,
                           CurrentAddress = x.CurrentAddress,

                           LandOwnershipViewModelList = _context.LandOwnership.Where(z => z.FieldDetailsId == x.Id)
                           .Select(z => new LandOwnershipViewModel()
                           {
                               Id = z.Id,
                               FieldDetailsId = z.FieldDetailsId,
                               OwnershipId = z.OwnershipId,
                               LandTypeId = z.LandTypeId,
                               Area = z.Area,
                               IsIrrigartionAvilable = z.IsIrrigartionAvilable,
                               IrrigartionArea = z.IrrigartionArea,
                               IrrigationSourceId = z.IrrigationSourceId,
                           }).ToList() ?? new List<LandOwnershipViewModel>(),

                           AgriFarmMoreThanOneLocalLevelViewModelList = _context.AgriFarmMoreThanOneLocalLevel.Where(z => z.FieldDetailsId == x.Id)
                           .Select(c => new AgriFarmMoreThanOneLocalLevelViewModel()
                           {
                               Id = c.Id,
                               FieldDetailsId = c.FieldDetailsId,
                               Address = c.Address,
                               Area = c.Area,
                               IsIrrigationAvailiable = c.IsIrrigationAvailiable,
                               SectorId = c.SectorId,
                               SubSector = c.SubSector,
                               OwnershipId = c.OwnershipId,
                               DetailOfLandOwner = c.DetailOfLandOwner,
                           }).ToList() ?? new List<AgriFarmMoreThanOneLocalLevelViewModel>(),

                           LeasedLandDetailViewModelList = _context.LeasedLandDetail.Where(z => z.FieldDetailsId == x.Id)
                           .Select(d => new LeasedLandDetailViewModel()
                           {
                               Id = d.Id,
                               FieldDetailsId = d.FieldDetailsId,
                               OwnershipId = d.OwnershipId,
                               LandTypeId = d.LandTypeId,
                               Area = d.Area,
                               IsIrrigartionAvilable = d.IsIrrigartionAvilable,
                               IrrigartionArea = d.IrrigartionArea,
                               IrrigationSourceId = d.IrrigationSourceId,
                           }).ToList() ?? new List<LeasedLandDetailViewModel>(),
                       }).FirstOrDefaultAsync() ?? new FieldDetailsViewModel();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> InsertUpdateFieldDetails(FieldDetailsViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.FieldDetails.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.FarmerId = model.FarmerId;
                            data.FiscalYearId = model.FiscalYearId;
                            data.IsKrishakDarta = model.IsKrishakDarta;
                            data.DartaNo = model.DartaNo;
                            data.FullName = model.FullName;
                            data.PhoneNo = model.PhoneNo;
                            data.Address = model.Address;
                            data.SanjhutaMiti = model.SanjhutaMiti;
                            data.SanjhutaDate = model.SanjhutaDate;
                            data.SamjhutaEndMiti = model.SamjhutaEndMiti;
                            data.SamjhutaEndDate = model.SamjhutaEndDate;
                            data.CitizenNo = model.CitizenNo;
                            data.CurrentAddress = model.CurrentAddress;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            if (model.LandOwnershipViewModelList != null)
                            {
                                foreach (var item in await _context.LandOwnership.Where(x => x.FieldDetailsId == model.Id).ToListAsync())
                                {
                                    if (!model.LandOwnershipViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.LandOwnership.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.LandOwnershipViewModelList)
                                {
                                    var agdata = _context.LandOwnership.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.OwnershipId = item.OwnershipId;
                                        agdata.LandTypeId = item.LandTypeId;
                                        agdata.Area = item.Area;
                                        agdata.IsIrrigartionAvilable = item.IsIrrigartionAvilable;
                                        agdata.IrrigartionArea = item.IrrigartionArea;
                                        agdata.IrrigationSourceId = item.IrrigationSourceId;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new LandOwnership()
                                        {
                                            FieldDetailsId = model.Id,
                                            OwnershipId = item.OwnershipId,
                                            LandTypeId = item.LandTypeId,
                                            Area = item.Area,
                                            IsIrrigartionAvilable = item.IsIrrigartionAvilable,
                                            IrrigartionArea = item.IrrigartionArea,
                                            IrrigationSourceId = item.IrrigationSourceId,
                                        };
                                        await _context.LandOwnership.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.AgriFarmMoreThanOneLocalLevelViewModelList != null)
                            {
                                foreach (var item in await _context.AgriFarmMoreThanOneLocalLevel.Where(x => x.FieldDetailsId == model.Id).ToListAsync())
                                {
                                    if (!model.AgriFarmMoreThanOneLocalLevelViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.AgriFarmMoreThanOneLocalLevel.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.AgriFarmMoreThanOneLocalLevelViewModelList)
                                {
                                    var agrdata = _context.AgriFarmMoreThanOneLocalLevel.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agrdata != null)
                                    {
                                        agrdata.Address = item.Address;
                                        agrdata.Area = item.Area;
                                        agrdata.IsIrrigationAvailiable = item.IsIrrigationAvailiable;
                                        agrdata.SectorId = item.SectorId;
                                        agrdata.SubSector = item.SubSector;
                                        agrdata.OwnershipId = item.OwnershipId;
                                        agrdata.DetailOfLandOwner = item.DetailOfLandOwner;

                                        _context.Entry(agrdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new AgriFarmMoreThanOneLocalLevel()
                                        {
                                            FieldDetailsId = model.Id,
                                            Address = item.Address,
                                            Area = item.Area,
                                            IsIrrigationAvailiable = item.IsIrrigationAvailiable,
                                            SectorId = item.SectorId,
                                            SubSector = item.SubSector,
                                            OwnershipId = item.OwnershipId,
                                            DetailOfLandOwner = item.DetailOfLandOwner,
                                        };
                                        await _context.AgriFarmMoreThanOneLocalLevel.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.LeasedLandDetailViewModelList != null)
                            {
                                foreach (var item in await _context.LeasedLandDetail.Where(x => x.FieldDetailsId == model.Id).ToListAsync())
                                {
                                    if (!model.LeasedLandDetailViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.LeasedLandDetail.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.LeasedLandDetailViewModelList)
                                {
                                    var agdata = _context.LeasedLandDetail.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.OwnershipId = item.OwnershipId;
                                        agdata.LandTypeId = item.LandTypeId;
                                        agdata.Area = item.Area;
                                        agdata.IsIrrigartionAvilable = item.IsIrrigartionAvilable;
                                        agdata.IrrigartionArea = item.IrrigartionArea;
                                        agdata.IrrigationSourceId = item.IrrigationSourceId;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new LeasedLandDetail()
                                        {
                                            FieldDetailsId = model.Id,
                                            OwnershipId = item.OwnershipId,
                                            LandTypeId = item.LandTypeId,
                                            Area = item.Area,
                                            IsIrrigartionAvilable = item.IsIrrigartionAvilable,
                                            IrrigartionArea = item.IrrigartionArea,
                                            IrrigationSourceId = item.IrrigationSourceId,
                                        };
                                        await _context.LeasedLandDetail.AddAsync(newdata);
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
                        var data = new FieldDetails()
                        {
                            FarmerId = model.FarmerId,
                            FiscalYearId = model.FiscalYearId,
                            IsKrishakDarta = model.IsKrishakDarta,
                            DartaNo = model.DartaNo,
                            FullName = model.FullName,
                            PhoneNo = model.PhoneNo,
                            Address = model.Address,
                            SanjhutaMiti = model.SanjhutaMiti,
                            SanjhutaDate = model.SanjhutaDate,
                            SamjhutaEndMiti = model.SamjhutaEndMiti,
                            SamjhutaEndDate = model.SamjhutaEndDate,
                            CitizenNo = model.CitizenNo,
                            CurrentAddress = model.CurrentAddress,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.FieldDetails.AddAsync(data);
                        await _context.SaveChangesAsync();
                        if (model.LandOwnershipViewModelList != null)
                        {
                            foreach (var item in model.LandOwnershipViewModelList)
                            {
                                var newdata = new LandOwnership()
                                {
                                    FieldDetailsId = data.Id,
                                    OwnershipId = item.OwnershipId,
                                    LandTypeId = item.LandTypeId,
                                    Area = item.Area,
                                    IsIrrigartionAvilable = item.IsIrrigartionAvilable,
                                    IrrigartionArea = item.IrrigartionArea,
                                    IrrigationSourceId = item.IrrigationSourceId,
                                };
                                await _context.LandOwnership.AddAsync(newdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.AgriFarmMoreThanOneLocalLevelViewModelList != null)
                        {
                            foreach (var item in model.AgriFarmMoreThanOneLocalLevelViewModelList)
                            {
                                var Agdata = new AgriFarmMoreThanOneLocalLevel()
                                {
                                    FieldDetailsId = data.Id,
                                    Address = item.Address,
                                    Area = item.Area,
                                    IsIrrigationAvailiable = item.IsIrrigationAvailiable,
                                    SectorId = item.SectorId,
                                    SubSector = item.SubSector,
                                    OwnershipId = item.OwnershipId,
                                    DetailOfLandOwner = item.DetailOfLandOwner,
                                };
                                await _context.AgriFarmMoreThanOneLocalLevel.AddAsync(Agdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.LeasedLandDetailViewModelList != null)
                        {
                            foreach (var item in model.LeasedLandDetailViewModelList)
                            {
                                var ledata = new LeasedLandDetail()
                                {
                                    FieldDetailsId = data.Id,
                                    OwnershipId = item.OwnershipId,
                                    LandTypeId = item.LandTypeId,
                                    Area = item.Area,
                                    IsIrrigartionAvilable = item.IsIrrigartionAvilable,
                                    IrrigartionArea = item.IrrigartionArea,
                                    IrrigationSourceId = item.IrrigationSourceId,
                                };
                                await _context.LeasedLandDetail.AddAsync(ledata);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("FieldDetails Repo create/update with multiple table (landownership, agrifarm, leasedland) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }




        public async Task<CropsInformationViewModel> GetCropsInformation(int id)
        {
            try
            {
                var data = await _context.CropsInformation.Where(x => x.FarmerId == id)
                       .Select(x => new CropsInformationViewModel()
                       {
                           Id = x.Id,
                           FarmerId = x.FarmerId,
                           FiscalYearId = x.FiscalYearId,

                           EatableCropsViewModelList = _context.EatableCrops.Where(z => z.CropsInformationId == x.Id)
                           .Select(z => new EatableCropsViewModel()
                           {
                               Id = z.Id,
                               CropsInformationId = z.CropsInformationId,
                               CropsTypeId = z.CropsTypeId,
                               Area = z.Area,
                               Quantity = z.Quantity,
                           }).ToList() ?? new List<EatableCropsViewModel>(),

                           FruitCropsViewModelList = _context.FruitCrops.Where(z => z.CropsInformationId == x.Id)
                           .Select(c => new FruitCropsViewModel()
                           {
                               Id = c.Id,
                               CropsInformationId = c.CropsInformationId,
                               FruitsTypeId = c.FruitsTypeId,
                               Area = c.Area,
                               TotalPlant = c.TotalPlant,
                               Quantity = c.Quantity,
                           }).ToList() ?? new List<FruitCropsViewModel>(),

                           SeedCropsViewModelList = _context.SeedCrops.Where(z => z.CropsInformationId == x.Id)
                           .Select(d => new SeedCropsViewModel()
                           {
                               Id = d.Id,
                               CropsInformationId = d.CropsInformationId,
                               SeedsTypeId = d.SeedsTypeId,
                               Jaat = d.Jaat,
                               Area = d.Area,
                               Quantity = d.Quantity,
                           }).ToList() ?? new List<SeedCropsViewModel>(),
                           MushroomCrposViewModelList = _context.MushroomCrpos.Where(z => z.CropsInformationId == x.Id)
                           .Select(m => new MushroomCrposViewModel()
                           {
                               Id = m.Id,
                               CropsInformationId = m.CropsInformationId,
                               MushroomTypeId = m.MushroomTypeId,
                               TotalCount = m.TotalCount,
                               Area = m.Area,
                               Quantity = m.Quantity,
                           }).ToList() ?? new List<MushroomCrposViewModel>(),
                           SilkCropsViewModelList = _context.SilkCrops.Where(z => z.CropsInformationId == x.Id)
                           .Select(s => new SilkCropsViewModel()
                           {
                               Id = s.Id,
                               CropsInformationId = s.CropsInformationId,
                               Area = s.Area,
                               SilkTypeId = s.SilkTypeId,
                               TotalCount = s.TotalCount,
                           }).ToList() ?? new List<SilkCropsViewModel>(),
                           BeeCropsViewModelList = _context.BeeCrops.Where(z => z.CropsInformationId == x.Id)
                           .Select(b => new BeeCropsViewModel()
                           {
                               Id = b.Id,
                               CropsInformationId = b.CropsInformationId,
                               BeeTypeId = b.BeeTypeId,
                               TotalCount = b.TotalCount,
                               Quantity = b.Quantity,
                           }).ToList() ?? new List<BeeCropsViewModel>(),
                       }).FirstOrDefaultAsync() ?? new CropsInformationViewModel();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> InsertUpdateCropsInformation(CropsInformationViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.CropsInformation.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.FarmerId = model.FarmerId;
                            data.FiscalYearId = model.FiscalYearId;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            if (model.EatableCropsViewModelList != null)
                            {
                                foreach (var item in await _context.EatableCrops.Where(x => x.CropsInformationId == model.Id).ToListAsync())
                                {
                                    if (!model.EatableCropsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.EatableCrops.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.EatableCropsViewModelList)
                                {
                                    var agdata = _context.EatableCrops.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.Quantity = item.Quantity;
                                        agdata.CropsTypeId = item.CropsTypeId;
                                        agdata.Area = item.Area;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new EatableCrops()
                                        {
                                            CropsInformationId = model.Id,
                                            CropsTypeId = item.CropsTypeId,
                                            Area = item.Area,
                                            Quantity = item.Quantity,
                                        };
                                        await _context.EatableCrops.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.FruitCropsViewModelList != null)
                            {
                                foreach (var item in await _context.FruitCrops.Where(x => x.CropsInformationId == model.Id).ToListAsync())
                                {
                                    if (!model.FruitCropsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.FruitCrops.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.FruitCropsViewModelList)
                                {
                                    var agrdata = _context.FruitCrops.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agrdata != null)
                                    {
                                        agrdata.FruitsTypeId = item.FruitsTypeId;
                                        agrdata.TotalPlant = item.TotalPlant;
                                        agrdata.Area = item.Area;
                                        agrdata.Quantity = item.Quantity;

                                        _context.Entry(agrdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new FruitCrops()
                                        {
                                            CropsInformationId = model.Id,
                                            FruitsTypeId = item.FruitsTypeId,
                                            Area = item.Area,
                                            TotalPlant = item.TotalPlant,
                                            Quantity = item.Quantity,
                                        };
                                        await _context.FruitCrops.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.SeedCropsViewModelList != null)
                            {
                                foreach (var item in await _context.SeedCrops.Where(x => x.CropsInformationId == model.Id).ToListAsync())
                                {
                                    if (!model.SeedCropsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.SeedCrops.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.SeedCropsViewModelList)
                                {
                                    var agdata = _context.SeedCrops.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.SeedsTypeId = item.SeedsTypeId;
                                        agdata.Jaat = item.Jaat;
                                        agdata.Area = item.Area;
                                        agdata.Quantity = item.Quantity;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new SeedCrops()
                                        {
                                            CropsInformationId = model.Id,
                                            SeedsTypeId = item.SeedsTypeId,
                                            Jaat = item.Jaat,
                                            Area = item.Area,
                                            Quantity = item.Quantity,
                                        };
                                        await _context.SeedCrops.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.MushroomCrposViewModelList != null)
                            {
                                foreach (var item in await _context.MushroomCrpos.Where(x => x.CropsInformationId == model.Id).ToListAsync())
                                {
                                    if (!model.MushroomCrposViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.MushroomCrpos.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.MushroomCrposViewModelList)
                                {
                                    var agdata = _context.MushroomCrpos.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.MushroomTypeId = item.MushroomTypeId;
                                        agdata.TotalCount = item.TotalCount;
                                        agdata.Area = item.Area;
                                        agdata.Quantity = item.Quantity;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new MushroomCrpos()
                                        {
                                            CropsInformationId = model.Id,
                                            MushroomTypeId = item.MushroomTypeId,
                                            TotalCount = item.TotalCount,
                                            Area = item.Area,
                                            Quantity = item.Quantity,
                                        };
                                        await _context.MushroomCrpos.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.SilkCropsViewModelList != null)
                            {
                                foreach (var item in await _context.SilkCrops.Where(x => x.CropsInformationId == model.Id).ToListAsync())
                                {
                                    if (!model.SilkCropsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.SilkCrops.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.SilkCropsViewModelList)
                                {
                                    var agdata = _context.SilkCrops.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.Area = item.Area;
                                        agdata.SilkTypeId = item.SilkTypeId;
                                        agdata.TotalCount = item.TotalCount;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new SilkCrops()
                                        {
                                            CropsInformationId = model.Id,
                                            Area = item.Area,
                                            SilkTypeId = item.SilkTypeId,
                                            TotalCount = item.TotalCount,
                                        };
                                        await _context.SilkCrops.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.BeeCropsViewModelList != null)
                            {
                                foreach (var item in await _context.BeeCrops.Where(x => x.CropsInformationId == model.Id).ToListAsync())
                                {
                                    if (!model.BeeCropsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.BeeCrops.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.BeeCropsViewModelList)
                                {
                                    var agdata = _context.BeeCrops.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.BeeTypeId = item.BeeTypeId;
                                        agdata.TotalCount = item.TotalCount;
                                        agdata.Quantity = item.Quantity;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new BeeCrops()
                                        {
                                            CropsInformationId = model.Id,
                                            BeeTypeId = item.BeeTypeId,
                                            TotalCount = item.TotalCount,
                                            Quantity = item.Quantity,
                                        };
                                        await _context.BeeCrops.AddAsync(newdata);
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
                        var data = new CropsInformation()
                        {
                            FarmerId = model.FarmerId,
                            FiscalYearId = model.FiscalYearId,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.CropsInformation.AddAsync(data);
                        await _context.SaveChangesAsync();
                        if (model.EatableCropsViewModelList != null)
                        {
                            foreach (var item in model.EatableCropsViewModelList)
                            {
                                var newdata = new EatableCrops()
                                {
                                    CropsInformationId = data.Id,
                                    CropsTypeId = item.CropsTypeId,
                                    Area = item.Area,
                                    Quantity = item.Quantity,
                                };
                                await _context.EatableCrops.AddAsync(newdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.FruitCropsViewModelList != null)
                        {
                            foreach (var item in model.FruitCropsViewModelList)
                            {
                                var Agdata = new FruitCrops()
                                {
                                    CropsInformationId = data.Id,
                                    FruitsTypeId = item.FruitsTypeId,
                                    Area = item.Area,
                                    TotalPlant = item.TotalPlant,
                                    Quantity = item.Quantity,
                                };
                                await _context.FruitCrops.AddAsync(Agdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.SeedCropsViewModelList != null)
                        {
                            foreach (var item in model.SeedCropsViewModelList)
                            {
                                var ledata = new SeedCrops()
                                {
                                    CropsInformationId = data.Id,
                                    SeedsTypeId = item.SeedsTypeId,
                                    Jaat = item.Jaat,
                                    Area = item.Area,
                                    Quantity = item.Quantity,
                                };
                                await _context.SeedCrops.AddAsync(ledata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.MushroomCrposViewModelList != null)
                        {
                            foreach (var item in model.MushroomCrposViewModelList)
                            {
                                var mdata = new MushroomCrpos()
                                {
                                    CropsInformationId = data.Id,
                                    MushroomTypeId = item.MushroomTypeId,
                                    TotalCount = item.TotalCount,
                                    Area = item.Area,
                                    Quantity = item.Quantity,
                                };
                                await _context.MushroomCrpos.AddAsync(mdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.SilkCropsViewModelList != null)
                        {
                            foreach (var item in model.SilkCropsViewModelList)
                            {
                                var sdata = new SilkCrops()
                                {
                                    CropsInformationId = data.Id,
                                    Area = item.Area,
                                    SilkTypeId = item.SilkTypeId,
                                    TotalCount = item.TotalCount,
                                };
                                await _context.SilkCrops.AddAsync(sdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.BeeCropsViewModelList != null)
                        {
                            foreach (var item in model.BeeCropsViewModelList)
                            {
                                var beedata = new BeeCrops()
                                {
                                    CropsInformationId = data.Id,
                                    BeeTypeId = item.BeeTypeId,
                                    TotalCount = item.TotalCount,
                                    Quantity = item.Quantity,
                                };
                                await _context.BeeCrops.AddAsync(beedata);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("CropsInformation Repo create/update with multiple table (landownership, agrifarm, leasedland) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }



        public async Task<AnimalHusbandryViewModel> GetAnimalHusbandry(int id)
        {
            try
            {
                var data = await _context.AnimalHusbandry.Where(x => x.FarmerId == id)
                       .Select(x => new AnimalHusbandryViewModel()
                       {
                           Id = x.Id,
                           FarmerId = x.FarmerId,
                           FiscalYearId = x.FiscalYearId,

                           CowInfromationViewModelList = _context.CowInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new CowInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               CowLocCount = z.CowLocCount,
                               CowLocMilkDaily = z.CowLocMilkDaily,
                               CowLocMilkMonth = z.CowLocMilkMonth,
                               CowUnnatCount = z.CowUnnatCount,
                               CowUnnatMilkDaily = z.CowUnnatMilkDaily,
                               CowUnnatMilkMonth = z.CowUnnatMilkMonth
                           }).FirstOrDefault() ?? new CowInfromationViewModel(),

                           BuffaloInfromationViewModelList = _context.BuffaloInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new BuffaloInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               BuffLocCount = z.BuffLocCount,
                               BuffLocMilkMonth = z.BuffLocMilkMonth,
                               BuffLocMilkDaily = z.BuffLocMilkDaily,
                               BuffUnnatCount = z.BuffUnnatCount,
                               BuffUnnatMilkMonth = z.BuffUnnatMilkMonth,
                               BuffUnnatMilkDaily = z.BuffUnnatMilkDaily,
                           }).FirstOrDefault() ?? new BuffaloInfromationViewModel(),

                           CharuiYakInfromationViewModelList = _context.CharuiYakInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new CharuiYakInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               ChauriCount = z.ChauriCount,
                               ChauriMilkMonth = z.ChauriMilkMonth,
                               ChauriMilkDaily = z.ChauriMilkDaily,
                               YakCount = z.YakCount,
                               YakMilkMonth = z.YakMilkMonth,
                               YakMilkDaily = z.YakMilkDaily,
                           }).FirstOrDefault() ?? new CharuiYakInfromationViewModel(),

                           GoruInfromationViewModelList = _context.GoruInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new GoruInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               GoruCount = z.GoruCount,
                               RagaCount = z.RagaCount,
                           }).FirstOrDefault() ?? new GoruInfromationViewModel(),

                           BhedaBakhraInfromationViewModelList = _context.BhedaBakhraInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new BhedaBakhraInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               BhedaCount = z.BhedaCount,
                               BhedaKasiCount = z.BhedaKasiCount,
                               BhedaBokaCount = z.BhedaBokaCount,
                               BhedaPathaCount = z.BhedaPathaCount,
                               BakhraCount = z.BakhraCount,
                               BakhraKasiCount = z.BakhraKasiCount,
                               BakhraBokaCount = z.BakhraBokaCount,
                               BakhraPathaCount = z.BakhraPathaCount,
                               ChangraCount = z.ChangraCount,
                               ChangraKasiCount = z.ChangraKasiCount,
                               ChangraBokaCount = z.ChangraBokaCount,
                               ChangraPathaCount = z.ChangraPathaCount,
                           }).FirstOrDefault() ?? new BhedaBakhraInfromationViewModel(),

                           BungurSungurInfromationViewModelList = _context.BungurSungurInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new BungurSungurInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               BungurCount = z.BungurCount,
                               BungurMaleCount = z.BungurMaleCount,
                               BungurPathaCount = z.BungurPathaCount,
                               SungurCount = z.SungurCount,
                               SungurMaleCount = z.SungurMaleCount,
                               SungurPathaCount = z.SungurPathaCount,
                               BadelCount = z.BadelCount,
                               BadelMaleCount = z.BadelMaleCount,
                               BadelPathaCount = z.BadelPathaCount,
                           }).FirstOrDefault() ?? new BungurSungurInfromationViewModel(),

                           HenInfromationViewModelList = _context.HenInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new HenInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               IsLayers = z.IsLayers,
                               LayersCount = z.LayersCount,
                               LayersEggCount = z.LayersEggCount,
                               LayersChickenProductionCount = z.LayersChickenProductionCount,
                               IsBoiler = z.IsBoiler,
                               BoilerCount = z.BoilerCount,
                               BoilerEggCount = z.BoilerEggCount,
                               BoilerChickenProductionCount = z.BoilerChickenProductionCount,
                           }).FirstOrDefault() ?? new HenInfromationViewModel(),

                           OtherBirdInfromationViewModelList = _context.OtherBirdInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new OtherBirdInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               DuckCount = z.DuckCount,
                               DuckEggCount = z.DuckEggCount,
                               DuckProductionCount = z.DuckProductionCount,
                               OtherCount = z.OtherCount,
                               OtherEggCount = z.OtherEggCount,
                               OtherProductionCount = z.OtherProductionCount,
                               PegionCount = z.PegionCount,
                               PegionEggCount = z.PegionEggCount,
                               PegionProductionCount = z.PegionProductionCount,
                               LaukatCount = z.LaukatCount,
                               LaukatEggCount = z.LaukatEggCount,
                               LaukatProductionCount = z.LaukatProductionCount,
                               TurkeyCount = z.TurkeyCount,
                               TurkeyEggCount = z.TurkeyEggCount,
                               TurkeyProductionCount = z.TurkeyProductionCount,
                               KalijCount = z.KalijCount,
                               KalijEggCount = z.KalijEggCount,
                               KalijProductionCount = z.KalijProductionCount,
                               AustrichCount = z.AustrichCount,
                               AustrichEggCount = z.AustrichEggCount,
                               AustrichProductionCount = z.AustrichProductionCount,
                               BattaiCount = z.BattaiCount,
                               BattaiEggCount = z.BattaiEggCount,
                               BattaiProductionCount = z.BattaiProductionCount,
                           }).FirstOrDefault() ?? new OtherBirdInfromationViewModel(),

                           FishInfromationViewModelList = _context.FishInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new FishInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               IsRahu = z.IsRahu,
                               IsNaini = z.IsNaini,
                               IsSilvercarp = z.IsSilvercarp,
                               IsNaibigheadkarpni = z.IsNaibigheadkarpni,
                               IsGrasscarp = z.IsGrasscarp,
                               IsComoncarp = z.IsComoncarp,
                               IsTrout = z.IsTrout,
                               Ischadi = z.Ischadi,
                               IsTilapiya = z.IsTilapiya,
                               IsPangas = z.IsPangas,
                               IsLocal = z.IsLocal,
                               IsOther = z.IsOther,
                               PondArea = z.PondArea,
                               TotalCount = z.TotalCount,
                               ProcustionUseId = z.ProcustionUseId,
                               ProcustionMeasurementId = z.ProcustionMeasurementId,
                               ProcustionQuantity = z.ProcustionQuantity,
                           }).FirstOrDefault() ?? new FishInfromationViewModel(),

                           OtherAnimalInfromationViewModelList = _context.OtherAnimalInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new OtherAnimalInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               GhodaCount = z.GhodaCount,
                               KhaccedCount = z.KhaccedCount,
                               GadhaCount = z.GadhaCount,
                               RabbitCount = z.RabbitCount,
                               DogCount = z.DogCount,
                               CatCount = z.CatCount,
                               OtherCount = z.OtherCount,
                           }).FirstOrDefault() ?? new OtherAnimalInfromationViewModel(),

                           GhaseBaliInfromationViewModelList = _context.GhaseBaliInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new GhaseBaliInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               HudeJaat = z.HudeJaat,
                               HudeArea = z.HudeArea,
                               HudeGrassProd = z.HudeGrassProd,
                               HudeSeedProd = z.HudeSeedProd,
                               NurseryJaat = z.NurseryJaat,
                               NurseryArea = z.NurseryArea,
                               NurseryGrassProd = z.NurseryGrassProd,
                               NurserySeedProd = z.NurserySeedProd,
                               DaleJaat = z.DaleJaat,
                               DaleArea = z.DaleArea,
                               DaleGrassProd = z.DaleGrassProd,
                               DaleSeedProd = z.DaleSeedProd,
                               BahuBarshaJaat = z.BahuBarshaJaat,
                               BahuBarshaArea = z.BahuBarshaArea,
                               BahuBarshaGrassProd = z.BahuBarshaGrassProd,
                               BahuBarshaSeedProd = z.BahuBarshaSeedProd,
                               BarshaJaat = z.BarshaJaat,
                               BarshaArea = z.BarshaArea,
                               BarshaGrassProd = z.BarshaGrassProd,
                               BarshaSeedProd = z.BarshaSeedProd,

                           }).FirstOrDefault() ?? new GhaseBaliInfromationViewModel(),

                           KrishiFarmInfromationViewModelList = _context.KrishiFarmInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new KrishiFarmInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               DartaNo = z.DartaNo,
                               DartaMiti = z.DartaMiti,
                               Name = z.Name,
                               KaryalayeName = z.KaryalayeName,
                               PanNo = z.PanNo,
                               ChairpersonName = z.ChairpersonName,
                               KrishiFarmTypeId = z.KrishiFarmTypeId,
                               MemberCount = z.MemberCount,
                               EmploymentCount = z.EmploymentCount,

                           }).FirstOrDefault() ?? new KrishiFarmInfromationViewModel(),

                           KrishiMechinaryInfromationViewModelList = _context.KrishiMechinaryInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new KrishiMechinaryInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               MechinaryName = z.MechinaryName,
                               Swamitya = z.Swamitya,
                               Potential = z.Potential,
                               TotalCount = z.TotalCount,
                           }).ToList() ?? new List<KrishiMechinaryInfromationViewModel>(),

                           KrishiSanrachanaInfromationViewModelList = _context.KrishiSanrachanaInfromation.Where(z => z.AnimalHusbandryId == x.Id)
                           .Select(z => new KrishiSanrachanaInfromationViewModel()
                           {
                               Id = z.Id,
                               AnimalHusbandryId = z.AnimalHusbandryId,
                               SanrachanaType = z.SanrachanaType,
                               ToalCount = z.ToalCount,
                               Area = z.Area,
                           }).ToList() ?? new List<KrishiSanrachanaInfromationViewModel>(),

                       }).FirstOrDefaultAsync() ?? new AnimalHusbandryViewModel();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> InsertUpdateAnimalHusbandry(AnimalHusbandryViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.AnimalHusbandry.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.FarmerId = model.FarmerId;
                            data.FiscalYearId = model.FiscalYearId;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            if (model.CowInfromationViewModelList != null)
                            {
                                var agdata = _context.CowInfromation.Where(x => x.Id == model.CowInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.CowLocCount = model.CowInfromationViewModelList.CowLocCount;
                                    agdata.CowLocMilkDaily = model.CowInfromationViewModelList.CowLocMilkDaily;
                                    agdata.CowLocMilkMonth = model.CowInfromationViewModelList.CowLocMilkMonth;
                                    agdata.CowUnnatCount = model.CowInfromationViewModelList.CowUnnatCount;
                                    agdata.CowUnnatMilkDaily = model.CowInfromationViewModelList.CowUnnatMilkDaily;
                                    agdata.CowUnnatMilkMonth = model.CowInfromationViewModelList.CowUnnatMilkMonth;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new CowInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        CowLocCount = model.CowInfromationViewModelList.CowLocCount,
                                        CowLocMilkDaily = model.CowInfromationViewModelList.CowLocMilkDaily,
                                        CowLocMilkMonth = model.CowInfromationViewModelList.CowLocMilkMonth,
                                        CowUnnatCount = model.CowInfromationViewModelList.CowUnnatCount,
                                        CowUnnatMilkDaily = model.CowInfromationViewModelList.CowUnnatMilkDaily,
                                        CowUnnatMilkMonth = model.CowInfromationViewModelList.CowUnnatMilkMonth
                                    };
                                    await _context.CowInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.BuffaloInfromationViewModelList != null)
                            {
                                var agdata = _context.BuffaloInfromation.Where(x => x.Id == model.BuffaloInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.BuffLocCount = model.BuffaloInfromationViewModelList.BuffLocCount;
                                    agdata.BuffLocMilkMonth = model.BuffaloInfromationViewModelList.BuffLocMilkMonth;
                                    agdata.BuffLocMilkDaily = model.BuffaloInfromationViewModelList.BuffLocMilkDaily;
                                    agdata.BuffUnnatCount = model.BuffaloInfromationViewModelList.BuffUnnatCount;
                                    agdata.BuffUnnatMilkMonth = model.BuffaloInfromationViewModelList.BuffUnnatMilkMonth;
                                    agdata.BuffUnnatMilkDaily = model.BuffaloInfromationViewModelList.BuffUnnatMilkDaily;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new BuffaloInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        BuffLocCount = model.BuffaloInfromationViewModelList.BuffLocCount,
                                        BuffLocMilkMonth = model.BuffaloInfromationViewModelList.BuffLocMilkMonth,
                                        BuffLocMilkDaily = model.BuffaloInfromationViewModelList.BuffLocMilkDaily,
                                        BuffUnnatCount = model.BuffaloInfromationViewModelList.BuffUnnatCount,
                                        BuffUnnatMilkMonth = model.BuffaloInfromationViewModelList.BuffUnnatMilkMonth,
                                        BuffUnnatMilkDaily = model.BuffaloInfromationViewModelList.BuffUnnatMilkDaily,
                                    };
                                    await _context.BuffaloInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.CharuiYakInfromationViewModelList != null)
                            {
                                var agdata = _context.CharuiYakInfromation.Where(x => x.Id == model.CharuiYakInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.ChauriCount = model.CharuiYakInfromationViewModelList.ChauriCount;
                                    agdata.ChauriMilkMonth = model.CharuiYakInfromationViewModelList.ChauriMilkMonth;
                                    agdata.ChauriMilkDaily = model.CharuiYakInfromationViewModelList.ChauriMilkDaily;
                                    agdata.YakCount = model.CharuiYakInfromationViewModelList.YakCount;
                                    agdata.YakMilkMonth = model.CharuiYakInfromationViewModelList.YakMilkMonth;
                                    agdata.YakMilkDaily = model.CharuiYakInfromationViewModelList.YakMilkDaily;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new CharuiYakInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        ChauriCount = model.CharuiYakInfromationViewModelList.ChauriCount,
                                        ChauriMilkMonth = model.CharuiYakInfromationViewModelList.ChauriMilkMonth,
                                        ChauriMilkDaily = model.CharuiYakInfromationViewModelList.ChauriMilkDaily,
                                        YakCount = model.CharuiYakInfromationViewModelList.YakCount,
                                        YakMilkMonth = model.CharuiYakInfromationViewModelList.YakMilkMonth,
                                        YakMilkDaily = model.CharuiYakInfromationViewModelList.YakMilkDaily,
                                    };
                                    await _context.CharuiYakInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.GoruInfromationViewModelList != null)
                            {
                                var agdata = _context.GoruInfromation.Where(x => x.Id == model.GoruInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.GoruCount = model.GoruInfromationViewModelList.GoruCount;
                                    agdata.RagaCount = model.GoruInfromationViewModelList.RagaCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new GoruInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        GoruCount = model.GoruInfromationViewModelList.GoruCount,
                                        RagaCount = model.GoruInfromationViewModelList.RagaCount,
                                    };
                                    await _context.GoruInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.BhedaBakhraInfromationViewModelList != null)
                            {
                                var agdata = _context.BhedaBakhraInfromation.Where(x => x.Id == model.BhedaBakhraInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.BhedaCount = model.BhedaBakhraInfromationViewModelList.BhedaCount;
                                    agdata.BhedaKasiCount = model.BhedaBakhraInfromationViewModelList.BhedaKasiCount;
                                    agdata.BhedaBokaCount = model.BhedaBakhraInfromationViewModelList.BhedaBokaCount;
                                    agdata.BhedaPathaCount = model.BhedaBakhraInfromationViewModelList.BhedaPathaCount;
                                    agdata.BakhraCount = model.BhedaBakhraInfromationViewModelList.BakhraCount;
                                    agdata.BakhraKasiCount = model.BhedaBakhraInfromationViewModelList.BakhraKasiCount;
                                    agdata.BakhraBokaCount = model.BhedaBakhraInfromationViewModelList.BakhraBokaCount;
                                    agdata.BakhraPathaCount = model.BhedaBakhraInfromationViewModelList.BakhraPathaCount;
                                    agdata.ChangraCount = model.BhedaBakhraInfromationViewModelList.ChangraCount;
                                    agdata.ChangraKasiCount = model.BhedaBakhraInfromationViewModelList.ChangraKasiCount;
                                    agdata.ChangraBokaCount = model.BhedaBakhraInfromationViewModelList.ChangraBokaCount;
                                    agdata.ChangraPathaCount = model.BhedaBakhraInfromationViewModelList.ChangraPathaCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new BhedaBakhraInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        BhedaCount = model.BhedaBakhraInfromationViewModelList.BhedaCount,
                                        BhedaKasiCount = model.BhedaBakhraInfromationViewModelList.BhedaKasiCount,
                                        BhedaBokaCount = model.BhedaBakhraInfromationViewModelList.BhedaBokaCount,
                                        BhedaPathaCount = model.BhedaBakhraInfromationViewModelList.BhedaPathaCount,
                                        BakhraCount = model.BhedaBakhraInfromationViewModelList.BakhraCount,
                                        BakhraKasiCount = model.BhedaBakhraInfromationViewModelList.BakhraKasiCount,
                                        BakhraBokaCount = model.BhedaBakhraInfromationViewModelList.BakhraBokaCount,
                                        BakhraPathaCount = model.BhedaBakhraInfromationViewModelList.BakhraPathaCount,
                                        ChangraCount = model.BhedaBakhraInfromationViewModelList.ChangraCount,
                                        ChangraKasiCount = model.BhedaBakhraInfromationViewModelList.ChangraKasiCount,
                                        ChangraBokaCount = model.BhedaBakhraInfromationViewModelList.ChangraBokaCount,
                                        ChangraPathaCount = model.BhedaBakhraInfromationViewModelList.ChangraPathaCount,
                                    };
                                    await _context.BhedaBakhraInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.BungurSungurInfromationViewModelList != null)
                            {
                                var agdata = _context.BungurSungurInfromation.Where(x => x.Id == model.BungurSungurInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.BungurCount = model.BungurSungurInfromationViewModelList.BungurCount;
                                    agdata.BungurMaleCount = model.BungurSungurInfromationViewModelList.BungurMaleCount;
                                    agdata.BungurPathaCount = model.BungurSungurInfromationViewModelList.BungurPathaCount;
                                    agdata.SungurCount = model.BungurSungurInfromationViewModelList.SungurCount;
                                    agdata.SungurMaleCount = model.BungurSungurInfromationViewModelList.SungurMaleCount;
                                    agdata.SungurPathaCount = model.BungurSungurInfromationViewModelList.SungurPathaCount;
                                    agdata.BadelCount = model.BungurSungurInfromationViewModelList.BadelCount;
                                    agdata.BadelMaleCount = model.BungurSungurInfromationViewModelList.BadelMaleCount;
                                    agdata.BadelPathaCount = model.BungurSungurInfromationViewModelList.BadelPathaCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new BungurSungurInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        BungurCount = model.BungurSungurInfromationViewModelList.BungurCount,
                                        BungurMaleCount = model.BungurSungurInfromationViewModelList.BungurMaleCount,
                                        BungurPathaCount = model.BungurSungurInfromationViewModelList.BungurPathaCount,
                                        SungurCount = model.BungurSungurInfromationViewModelList.SungurCount,
                                        SungurMaleCount = model.BungurSungurInfromationViewModelList.SungurMaleCount,
                                        SungurPathaCount = model.BungurSungurInfromationViewModelList.SungurPathaCount,
                                        BadelCount = model.BungurSungurInfromationViewModelList.BadelCount,
                                        BadelMaleCount = model.BungurSungurInfromationViewModelList.BadelMaleCount,
                                        BadelPathaCount = model.BungurSungurInfromationViewModelList.BadelPathaCount,
                                    };
                                    await _context.BungurSungurInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.HenInfromationViewModelList != null)
                            {
                                var agdata = _context.HenInfromation.Where(x => x.Id == model.HenInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.IsLayers = model.HenInfromationViewModelList.IsLayers;
                                    agdata.LayersCount = model.HenInfromationViewModelList.LayersCount;
                                    agdata.LayersEggCount = model.HenInfromationViewModelList.LayersEggCount;
                                    agdata.LayersChickenProductionCount = model.HenInfromationViewModelList.LayersChickenProductionCount;
                                    agdata.IsBoiler = model.HenInfromationViewModelList.IsBoiler;
                                    agdata.BoilerCount = model.HenInfromationViewModelList.BoilerCount;
                                    agdata.BoilerEggCount = model.HenInfromationViewModelList.BoilerEggCount;
                                    agdata.BoilerChickenProductionCount = model.HenInfromationViewModelList.BoilerChickenProductionCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new HenInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        IsLayers = model.HenInfromationViewModelList.IsLayers,
                                        LayersCount = model.HenInfromationViewModelList.LayersCount,
                                        LayersEggCount = model.HenInfromationViewModelList.LayersEggCount,
                                        LayersChickenProductionCount = model.HenInfromationViewModelList.LayersChickenProductionCount,
                                        IsBoiler = model.HenInfromationViewModelList.IsBoiler,
                                        BoilerCount = model.HenInfromationViewModelList.BoilerCount,
                                        BoilerEggCount = model.HenInfromationViewModelList.BoilerEggCount,
                                        BoilerChickenProductionCount = model.HenInfromationViewModelList.BoilerChickenProductionCount,
                                    };
                                    await _context.HenInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.OtherBirdInfromationViewModelList != null)
                            {
                                var agdata = _context.OtherBirdInfromation.Where(x => x.Id == model.OtherBirdInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.DuckCount = model.OtherBirdInfromationViewModelList.DuckCount;
                                    agdata.DuckEggCount = model.OtherBirdInfromationViewModelList.DuckEggCount;
                                    agdata.DuckProductionCount = model.OtherBirdInfromationViewModelList.DuckProductionCount;
                                    agdata.OtherCount = model.OtherBirdInfromationViewModelList.OtherCount;
                                    agdata.OtherEggCount = model.OtherBirdInfromationViewModelList.OtherEggCount;
                                    agdata.OtherProductionCount = model.OtherBirdInfromationViewModelList.OtherProductionCount;
                                    agdata.PegionCount = model.OtherBirdInfromationViewModelList.PegionCount;
                                    agdata.PegionEggCount = model.OtherBirdInfromationViewModelList.PegionEggCount;
                                    agdata.PegionProductionCount = model.OtherBirdInfromationViewModelList.PegionProductionCount;
                                    agdata.LaukatCount = model.OtherBirdInfromationViewModelList.LaukatCount;
                                    agdata.LaukatEggCount = model.OtherBirdInfromationViewModelList.LaukatEggCount;
                                    agdata.LaukatProductionCount = model.OtherBirdInfromationViewModelList.LaukatProductionCount;
                                    agdata.TurkeyCount = model.OtherBirdInfromationViewModelList.TurkeyCount;
                                    agdata.TurkeyEggCount = model.OtherBirdInfromationViewModelList.TurkeyEggCount;
                                    agdata.TurkeyProductionCount = model.OtherBirdInfromationViewModelList.TurkeyProductionCount;
                                    agdata.KalijCount = model.OtherBirdInfromationViewModelList.KalijCount;
                                    agdata.KalijEggCount = model.OtherBirdInfromationViewModelList.KalijEggCount;
                                    agdata.KalijProductionCount = model.OtherBirdInfromationViewModelList.KalijProductionCount;
                                    agdata.AustrichCount = model.OtherBirdInfromationViewModelList.AustrichCount;
                                    agdata.AustrichEggCount = model.OtherBirdInfromationViewModelList.AustrichEggCount;
                                    agdata.AustrichProductionCount = model.OtherBirdInfromationViewModelList.AustrichProductionCount;
                                    agdata.BattaiCount = model.OtherBirdInfromationViewModelList.BattaiCount;
                                    agdata.BattaiEggCount = model.OtherBirdInfromationViewModelList.BattaiEggCount;
                                    agdata.BattaiProductionCount = model.OtherBirdInfromationViewModelList.BattaiProductionCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new OtherBirdInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        DuckCount = model.OtherBirdInfromationViewModelList.DuckCount,
                                        DuckEggCount = model.OtherBirdInfromationViewModelList.DuckEggCount,
                                        DuckProductionCount = model.OtherBirdInfromationViewModelList.DuckProductionCount,
                                        OtherCount = model.OtherBirdInfromationViewModelList.OtherCount,
                                        OtherEggCount = model.OtherBirdInfromationViewModelList.OtherEggCount,
                                        OtherProductionCount = model.OtherBirdInfromationViewModelList.OtherProductionCount,
                                        PegionCount = model.OtherBirdInfromationViewModelList.PegionCount,
                                        PegionEggCount = model.OtherBirdInfromationViewModelList.PegionEggCount,
                                        PegionProductionCount = model.OtherBirdInfromationViewModelList.PegionProductionCount,
                                        LaukatCount = model.OtherBirdInfromationViewModelList.LaukatCount,
                                        LaukatEggCount = model.OtherBirdInfromationViewModelList.LaukatEggCount,
                                        LaukatProductionCount = model.OtherBirdInfromationViewModelList.LaukatProductionCount,
                                        TurkeyCount = model.OtherBirdInfromationViewModelList.TurkeyCount,
                                        TurkeyEggCount = model.OtherBirdInfromationViewModelList.TurkeyEggCount,
                                        TurkeyProductionCount = model.OtherBirdInfromationViewModelList.TurkeyProductionCount,
                                        KalijCount = model.OtherBirdInfromationViewModelList.KalijCount,
                                        KalijEggCount = model.OtherBirdInfromationViewModelList.KalijEggCount,
                                        KalijProductionCount = model.OtherBirdInfromationViewModelList.KalijProductionCount,
                                        AustrichCount = model.OtherBirdInfromationViewModelList.AustrichCount,
                                        AustrichEggCount = model.OtherBirdInfromationViewModelList.AustrichEggCount,
                                        AustrichProductionCount = model.OtherBirdInfromationViewModelList.AustrichProductionCount,
                                        BattaiCount = model.OtherBirdInfromationViewModelList.BattaiCount,
                                        BattaiEggCount = model.OtherBirdInfromationViewModelList.BattaiEggCount,
                                        BattaiProductionCount = model.OtherBirdInfromationViewModelList.BattaiProductionCount,
                                    };
                                    await _context.OtherBirdInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.FishInfromationViewModelList != null)
                            {
                                var agdata = _context.FishInfromation.Where(x => x.Id == model.FishInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.IsRahu = model.FishInfromationViewModelList.IsRahu;
                                    agdata.IsNaini = model.FishInfromationViewModelList.IsNaini;
                                    agdata.IsSilvercarp = model.FishInfromationViewModelList.IsSilvercarp;
                                    agdata.IsNaibigheadkarpni = model.FishInfromationViewModelList.IsNaibigheadkarpni;
                                    agdata.IsGrasscarp = model.FishInfromationViewModelList.IsGrasscarp;
                                    agdata.IsComoncarp = model.FishInfromationViewModelList.IsComoncarp;
                                    agdata.IsTrout = model.FishInfromationViewModelList.IsTrout;
                                    agdata.Ischadi = model.FishInfromationViewModelList.Ischadi;
                                    agdata.IsTilapiya = model.FishInfromationViewModelList.IsTilapiya;
                                    agdata.IsPangas = model.FishInfromationViewModelList.IsPangas;
                                    agdata.IsLocal = model.FishInfromationViewModelList.IsLocal;
                                    agdata.IsOther = model.FishInfromationViewModelList.IsOther;
                                    agdata.PondArea = model.FishInfromationViewModelList.PondArea;
                                    agdata.TotalCount = model.FishInfromationViewModelList.TotalCount;
                                    agdata.ProcustionUseId = model.FishInfromationViewModelList.ProcustionUseId;
                                    agdata.ProcustionMeasurementId = model.FishInfromationViewModelList.ProcustionMeasurementId;
                                    agdata.ProcustionQuantity = model.FishInfromationViewModelList.ProcustionQuantity;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new FishInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        IsRahu = model.FishInfromationViewModelList.IsRahu,
                                        IsNaini = model.FishInfromationViewModelList.IsNaini,
                                        IsSilvercarp = model.FishInfromationViewModelList.IsSilvercarp,
                                        IsNaibigheadkarpni = model.FishInfromationViewModelList.IsNaibigheadkarpni,
                                        IsGrasscarp = model.FishInfromationViewModelList.IsGrasscarp,
                                        IsComoncarp = model.FishInfromationViewModelList.IsComoncarp,
                                        IsTrout = model.FishInfromationViewModelList.IsTrout,
                                        Ischadi = model.FishInfromationViewModelList.Ischadi,
                                        IsTilapiya = model.FishInfromationViewModelList.IsTilapiya,
                                        IsPangas = model.FishInfromationViewModelList.IsPangas,
                                        IsLocal = model.FishInfromationViewModelList.IsLocal,
                                        IsOther = model.FishInfromationViewModelList.IsOther,
                                        PondArea = model.FishInfromationViewModelList.PondArea,
                                        TotalCount = model.FishInfromationViewModelList.TotalCount,
                                        ProcustionUseId = model.FishInfromationViewModelList.ProcustionUseId,
                                        ProcustionMeasurementId = model.FishInfromationViewModelList.ProcustionMeasurementId,
                                        ProcustionQuantity = model.FishInfromationViewModelList.ProcustionQuantity,
                                    };
                                    await _context.FishInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.OtherAnimalInfromationViewModelList != null)
                            {
                                var agdata = _context.OtherAnimalInfromation.Where(x => x.Id == model.OtherAnimalInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.GhodaCount = model.OtherAnimalInfromationViewModelList.GhodaCount;
                                    agdata.KhaccedCount = model.OtherAnimalInfromationViewModelList.KhaccedCount;
                                    agdata.GadhaCount = model.OtherAnimalInfromationViewModelList.GadhaCount;
                                    agdata.RabbitCount = model.OtherAnimalInfromationViewModelList.RabbitCount;
                                    agdata.DogCount = model.OtherAnimalInfromationViewModelList.DogCount;
                                    agdata.CatCount = model.OtherAnimalInfromationViewModelList.CatCount;
                                    agdata.OtherCount = model.OtherAnimalInfromationViewModelList.OtherCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new OtherAnimalInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        GhodaCount = model.OtherAnimalInfromationViewModelList.GhodaCount,
                                        KhaccedCount = model.OtherAnimalInfromationViewModelList.KhaccedCount,
                                        GadhaCount = model.OtherAnimalInfromationViewModelList.GadhaCount,
                                        RabbitCount = model.OtherAnimalInfromationViewModelList.RabbitCount,
                                        DogCount = model.OtherAnimalInfromationViewModelList.DogCount,
                                        CatCount = model.OtherAnimalInfromationViewModelList.CatCount,
                                        OtherCount = model.OtherAnimalInfromationViewModelList.OtherCount,
                                    };
                                    await _context.OtherAnimalInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.GhaseBaliInfromationViewModelList != null)
                            {
                                var agdata = _context.GhaseBaliInfromation.Where(x => x.Id == model.GhaseBaliInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.HudeJaat = model.GhaseBaliInfromationViewModelList.HudeJaat;
                                    agdata.HudeArea = model.GhaseBaliInfromationViewModelList.HudeArea;
                                    agdata.HudeGrassProd = model.GhaseBaliInfromationViewModelList.HudeGrassProd;
                                    agdata.HudeSeedProd = model.GhaseBaliInfromationViewModelList.HudeSeedProd;
                                    agdata.NurseryJaat = model.GhaseBaliInfromationViewModelList.NurseryJaat;
                                    agdata.NurseryArea = model.GhaseBaliInfromationViewModelList.NurseryArea;
                                    agdata.NurseryGrassProd = model.GhaseBaliInfromationViewModelList.NurseryGrassProd;
                                    agdata.NurserySeedProd = model.GhaseBaliInfromationViewModelList.NurserySeedProd;
                                    agdata.DaleJaat = model.GhaseBaliInfromationViewModelList.DaleJaat;
                                    agdata.DaleArea = model.GhaseBaliInfromationViewModelList.DaleArea;
                                    agdata.DaleGrassProd = model.GhaseBaliInfromationViewModelList.DaleGrassProd;
                                    agdata.DaleSeedProd = model.GhaseBaliInfromationViewModelList.DaleSeedProd;
                                    agdata.BahuBarshaJaat = model.GhaseBaliInfromationViewModelList.BahuBarshaJaat;
                                    agdata.BahuBarshaArea = model.GhaseBaliInfromationViewModelList.BahuBarshaArea;
                                    agdata.BahuBarshaGrassProd = model.GhaseBaliInfromationViewModelList.BahuBarshaGrassProd;
                                    agdata.BahuBarshaSeedProd = model.GhaseBaliInfromationViewModelList.BahuBarshaSeedProd;
                                    agdata.BarshaJaat = model.GhaseBaliInfromationViewModelList.BarshaJaat;
                                    agdata.BarshaArea = model.GhaseBaliInfromationViewModelList.BarshaArea;
                                    agdata.BarshaGrassProd = model.GhaseBaliInfromationViewModelList.BarshaGrassProd;
                                    agdata.BarshaSeedProd = model.GhaseBaliInfromationViewModelList.BarshaSeedProd;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new GhaseBaliInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        HudeJaat = model.GhaseBaliInfromationViewModelList.HudeJaat,
                                        HudeArea = model.GhaseBaliInfromationViewModelList.HudeArea,
                                        HudeGrassProd = model.GhaseBaliInfromationViewModelList.HudeGrassProd,
                                        HudeSeedProd = model.GhaseBaliInfromationViewModelList.HudeSeedProd,
                                        NurseryJaat = model.GhaseBaliInfromationViewModelList.NurseryJaat,
                                        NurseryArea = model.GhaseBaliInfromationViewModelList.NurseryArea,
                                        NurseryGrassProd = model.GhaseBaliInfromationViewModelList.NurseryGrassProd,
                                        NurserySeedProd = model.GhaseBaliInfromationViewModelList.NurserySeedProd,
                                        DaleJaat = model.GhaseBaliInfromationViewModelList.DaleJaat,
                                        DaleArea = model.GhaseBaliInfromationViewModelList.DaleArea,
                                        DaleGrassProd = model.GhaseBaliInfromationViewModelList.DaleGrassProd,
                                        DaleSeedProd = model.GhaseBaliInfromationViewModelList.DaleSeedProd,
                                        BahuBarshaJaat = model.GhaseBaliInfromationViewModelList.BahuBarshaJaat,
                                        BahuBarshaArea = model.GhaseBaliInfromationViewModelList.BahuBarshaArea,
                                        BahuBarshaGrassProd = model.GhaseBaliInfromationViewModelList.BahuBarshaGrassProd,
                                        BahuBarshaSeedProd = model.GhaseBaliInfromationViewModelList.BahuBarshaSeedProd,
                                        BarshaJaat = model.GhaseBaliInfromationViewModelList.BarshaJaat,
                                        BarshaArea = model.GhaseBaliInfromationViewModelList.BarshaArea,
                                        BarshaGrassProd = model.GhaseBaliInfromationViewModelList.BarshaGrassProd,
                                        BarshaSeedProd = model.GhaseBaliInfromationViewModelList.BarshaSeedProd,
                                    };
                                    await _context.GhaseBaliInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.KrishiFarmInfromationViewModelList != null)
                            {
                                var agdata = _context.KrishiFarmInfromation.Where(x => x.Id == model.KrishiFarmInfromationViewModelList.Id).FirstOrDefault();
                                if (agdata != null)
                                {
                                    agdata.DartaNo = model.KrishiFarmInfromationViewModelList.DartaNo;
                                    agdata.DartaMiti = model.KrishiFarmInfromationViewModelList.DartaMiti;
                                    agdata.Name = model.KrishiFarmInfromationViewModelList.Name;
                                    agdata.KaryalayeName = model.KrishiFarmInfromationViewModelList.KaryalayeName;
                                    agdata.PanNo = model.KrishiFarmInfromationViewModelList.PanNo;
                                    agdata.ChairpersonName = model.KrishiFarmInfromationViewModelList.ChairpersonName;
                                    agdata.KrishiFarmTypeId = model.KrishiFarmInfromationViewModelList.KrishiFarmTypeId;
                                    agdata.MemberCount = model.KrishiFarmInfromationViewModelList.MemberCount;
                                    agdata.EmploymentCount = model.KrishiFarmInfromationViewModelList.EmploymentCount;

                                    _context.Entry(agdata).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var kdata = new KrishiFarmInfromation()
                                    {
                                        AnimalHusbandryId = model.Id,
                                        DartaNo = model.KrishiFarmInfromationViewModelList.DartaNo,
                                        DartaMiti = model.KrishiFarmInfromationViewModelList.DartaMiti,
                                        Name = model.KrishiFarmInfromationViewModelList.Name,
                                        KaryalayeName = model.KrishiFarmInfromationViewModelList.KaryalayeName,
                                        PanNo = model.KrishiFarmInfromationViewModelList.PanNo,
                                        ChairpersonName = model.KrishiFarmInfromationViewModelList.ChairpersonName,
                                        KrishiFarmTypeId = model.KrishiFarmInfromationViewModelList.KrishiFarmTypeId,
                                        MemberCount = model.KrishiFarmInfromationViewModelList.MemberCount,
                                        EmploymentCount = model.KrishiFarmInfromationViewModelList.EmploymentCount,
                                    };
                                    await _context.KrishiFarmInfromation.AddAsync(kdata);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            if (model.KrishiMechinaryInfromationViewModelList != null)
                            {
                                foreach (var item in await _context.KrishiMechinaryInfromation.Where(x => x.AnimalHusbandryId == model.Id).ToListAsync())
                                {
                                    if (!model.KrishiMechinaryInfromationViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.KrishiMechinaryInfromation.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.KrishiMechinaryInfromationViewModelList)
                                {
                                    var agdata = _context.KrishiMechinaryInfromation.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agdata != null)
                                    {
                                        agdata.MechinaryName = item.MechinaryName;
                                        agdata.Swamitya = item.Swamitya;
                                        agdata.Potential = item.Potential;
                                        agdata.TotalCount = item.TotalCount;

                                        _context.Entry(agdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new KrishiMechinaryInfromation()
                                        {
                                            AnimalHusbandryId = model.Id,
                                            MechinaryName = item.MechinaryName,
                                            Swamitya = item.Swamitya,
                                            Potential = item.Potential,
                                            TotalCount = item.TotalCount,
                                        };
                                        await _context.KrishiMechinaryInfromation.AddAsync(newdata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.KrishiSanrachanaInfromationViewModelList != null)
                            {
                                foreach (var item in await _context.KrishiSanrachanaInfromation.Where(x => x.AnimalHusbandryId == model.Id).ToListAsync())
                                {
                                    if (!model.KrishiSanrachanaInfromationViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.KrishiSanrachanaInfromation.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.KrishiSanrachanaInfromationViewModelList)
                                {
                                    var agrdata = _context.KrishiSanrachanaInfromation.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (agrdata != null)
                                    {
                                        agrdata.SanrachanaType = item.SanrachanaType;
                                        agrdata.ToalCount = item.ToalCount;
                                        agrdata.Area = item.Area;

                                        _context.Entry(agrdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var newdata = new KrishiSanrachanaInfromation()
                                        {
                                            AnimalHusbandryId = model.Id,
                                            SanrachanaType = item.SanrachanaType,
                                            ToalCount = item.ToalCount,
                                            Area = item.Area,
                                        };
                                        await _context.KrishiSanrachanaInfromation.AddAsync(newdata);
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
                        var data = new AnimalHusbandry()
                        {
                            FarmerId = model.FarmerId,
                            FiscalYearId = model.FiscalYearId,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.AnimalHusbandry.AddAsync(data);
                        await _context.SaveChangesAsync();

                        if (model.CowInfromationViewModelList != null)
                        {
                            var COdata = new CowInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                CowLocCount = model.CowInfromationViewModelList.CowLocCount,
                                CowLocMilkDaily = model.CowInfromationViewModelList.CowLocMilkDaily,
                                CowLocMilkMonth = model.CowInfromationViewModelList.CowLocMilkMonth,
                                CowUnnatCount = model.CowInfromationViewModelList.CowUnnatCount,
                                CowUnnatMilkDaily = model.CowInfromationViewModelList.CowUnnatMilkDaily,
                                CowUnnatMilkMonth = model.CowInfromationViewModelList.CowUnnatMilkMonth
                            };
                            await _context.CowInfromation.AddAsync(COdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.BuffaloInfromationViewModelList != null)
                        {
                            var BUdata = new BuffaloInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                BuffLocCount = model.BuffaloInfromationViewModelList.BuffLocCount,
                                BuffLocMilkMonth = model.BuffaloInfromationViewModelList.BuffLocMilkMonth,
                                BuffLocMilkDaily = model.BuffaloInfromationViewModelList.BuffLocMilkDaily,
                                BuffUnnatCount = model.BuffaloInfromationViewModelList.BuffUnnatCount,
                                BuffUnnatMilkMonth = model.BuffaloInfromationViewModelList.BuffUnnatMilkMonth,
                                BuffUnnatMilkDaily = model.BuffaloInfromationViewModelList.BuffUnnatMilkDaily,
                            };
                            await _context.BuffaloInfromation.AddAsync(BUdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.CharuiYakInfromationViewModelList != null)
                        {
                            var CHdata = new CharuiYakInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                ChauriCount = model.CharuiYakInfromationViewModelList.ChauriCount,
                                ChauriMilkMonth = model.CharuiYakInfromationViewModelList.ChauriMilkMonth,
                                ChauriMilkDaily = model.CharuiYakInfromationViewModelList.ChauriMilkDaily,
                                YakCount = model.CharuiYakInfromationViewModelList.YakCount,
                                YakMilkMonth = model.CharuiYakInfromationViewModelList.YakMilkMonth,
                                YakMilkDaily = model.CharuiYakInfromationViewModelList.YakMilkDaily,
                            };
                            await _context.CharuiYakInfromation.AddAsync(CHdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.GoruInfromationViewModelList != null)
                        {
                            var GOdata = new GoruInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                GoruCount = model.GoruInfromationViewModelList.GoruCount,
                                RagaCount = model.GoruInfromationViewModelList.RagaCount,
                            };
                            await _context.GoruInfromation.AddAsync(GOdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.BhedaBakhraInfromationViewModelList != null)
                        {
                            var Bhdata = new BhedaBakhraInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                BhedaCount = model.BhedaBakhraInfromationViewModelList.BhedaCount,
                                BhedaKasiCount = model.BhedaBakhraInfromationViewModelList.BhedaKasiCount,
                                BhedaBokaCount = model.BhedaBakhraInfromationViewModelList.BhedaBokaCount,
                                BhedaPathaCount = model.BhedaBakhraInfromationViewModelList.BhedaPathaCount,
                                BakhraCount = model.BhedaBakhraInfromationViewModelList.BakhraCount,
                                BakhraKasiCount = model.BhedaBakhraInfromationViewModelList.BakhraKasiCount,
                                BakhraBokaCount = model.BhedaBakhraInfromationViewModelList.BakhraBokaCount,
                                BakhraPathaCount = model.BhedaBakhraInfromationViewModelList.BakhraPathaCount,
                                ChangraCount = model.BhedaBakhraInfromationViewModelList.ChangraCount,
                                ChangraKasiCount = model.BhedaBakhraInfromationViewModelList.ChangraKasiCount,
                                ChangraBokaCount = model.BhedaBakhraInfromationViewModelList.ChangraBokaCount,
                                ChangraPathaCount = model.BhedaBakhraInfromationViewModelList.ChangraPathaCount,
                            };
                            await _context.BhedaBakhraInfromation.AddAsync(Bhdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.BungurSungurInfromationViewModelList != null)
                        {
                            var Budata = new BungurSungurInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                BungurCount = model.BungurSungurInfromationViewModelList.BungurCount,
                                BungurMaleCount = model.BungurSungurInfromationViewModelList.BungurMaleCount,
                                BungurPathaCount = model.BungurSungurInfromationViewModelList.BungurPathaCount,
                                SungurCount = model.BungurSungurInfromationViewModelList.SungurCount,
                                SungurMaleCount = model.BungurSungurInfromationViewModelList.SungurMaleCount,
                                SungurPathaCount = model.BungurSungurInfromationViewModelList.SungurPathaCount,
                                BadelCount = model.BungurSungurInfromationViewModelList.BadelCount,
                                BadelMaleCount = model.BungurSungurInfromationViewModelList.BadelMaleCount,
                                BadelPathaCount = model.BungurSungurInfromationViewModelList.BadelPathaCount,
                            };
                            await _context.BungurSungurInfromation.AddAsync(Budata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.HenInfromationViewModelList != null)
                        {
                            var Hedata = new HenInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                IsLayers = model.HenInfromationViewModelList.IsLayers,
                                LayersCount = model.HenInfromationViewModelList.LayersCount,
                                LayersEggCount = model.HenInfromationViewModelList.LayersEggCount,
                                LayersChickenProductionCount = model.HenInfromationViewModelList.LayersChickenProductionCount,
                                IsBoiler = model.HenInfromationViewModelList.IsBoiler,
                                BoilerCount = model.HenInfromationViewModelList.BoilerCount,
                                BoilerEggCount = model.HenInfromationViewModelList.BoilerEggCount,
                                BoilerChickenProductionCount = model.HenInfromationViewModelList.BoilerChickenProductionCount,
                            };
                            await _context.HenInfromation.AddAsync(Hedata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.OtherBirdInfromationViewModelList != null)
                        {
                            var OBdata = new OtherBirdInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                DuckCount = model.OtherBirdInfromationViewModelList.DuckCount,
                                DuckEggCount = model.OtherBirdInfromationViewModelList.DuckEggCount,
                                DuckProductionCount = model.OtherBirdInfromationViewModelList.DuckProductionCount,
                                OtherCount = model.OtherBirdInfromationViewModelList.OtherCount,
                                OtherEggCount = model.OtherBirdInfromationViewModelList.OtherEggCount,
                                OtherProductionCount = model.OtherBirdInfromationViewModelList.OtherProductionCount,
                                PegionCount = model.OtherBirdInfromationViewModelList.PegionCount,
                                PegionEggCount = model.OtherBirdInfromationViewModelList.PegionEggCount,
                                PegionProductionCount = model.OtherBirdInfromationViewModelList.PegionProductionCount,
                                LaukatCount = model.OtherBirdInfromationViewModelList.LaukatCount,
                                LaukatEggCount = model.OtherBirdInfromationViewModelList.LaukatEggCount,
                                LaukatProductionCount = model.OtherBirdInfromationViewModelList.LaukatProductionCount,
                                TurkeyCount = model.OtherBirdInfromationViewModelList.TurkeyCount,
                                TurkeyEggCount = model.OtherBirdInfromationViewModelList.TurkeyEggCount,
                                TurkeyProductionCount = model.OtherBirdInfromationViewModelList.TurkeyProductionCount,
                                KalijCount = model.OtherBirdInfromationViewModelList.KalijCount,
                                KalijEggCount = model.OtherBirdInfromationViewModelList.KalijEggCount,
                                KalijProductionCount = model.OtherBirdInfromationViewModelList.KalijProductionCount,
                                AustrichCount = model.OtherBirdInfromationViewModelList.AustrichCount,
                                AustrichEggCount = model.OtherBirdInfromationViewModelList.AustrichEggCount,
                                AustrichProductionCount = model.OtherBirdInfromationViewModelList.AustrichProductionCount,
                                BattaiCount = model.OtherBirdInfromationViewModelList.BattaiCount,
                                BattaiEggCount = model.OtherBirdInfromationViewModelList.BattaiEggCount,
                                BattaiProductionCount = model.OtherBirdInfromationViewModelList.BattaiProductionCount,
                            };
                            await _context.OtherBirdInfromation.AddAsync(OBdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.FishInfromationViewModelList != null)
                        {
                            var Fdata = new FishInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                IsRahu = model.FishInfromationViewModelList.IsRahu,
                                IsNaini = model.FishInfromationViewModelList.IsNaini,
                                IsSilvercarp = model.FishInfromationViewModelList.IsSilvercarp,
                                IsNaibigheadkarpni = model.FishInfromationViewModelList.IsNaibigheadkarpni,
                                IsGrasscarp = model.FishInfromationViewModelList.IsGrasscarp,
                                IsComoncarp = model.FishInfromationViewModelList.IsComoncarp,
                                IsTrout = model.FishInfromationViewModelList.IsTrout,
                                Ischadi = model.FishInfromationViewModelList.Ischadi,
                                IsTilapiya = model.FishInfromationViewModelList.IsTilapiya,
                                IsPangas = model.FishInfromationViewModelList.IsPangas,
                                IsLocal = model.FishInfromationViewModelList.IsLocal,
                                IsOther = model.FishInfromationViewModelList.IsOther,
                                PondArea = model.FishInfromationViewModelList.PondArea,
                                TotalCount = model.FishInfromationViewModelList.TotalCount,
                                ProcustionUseId = model.FishInfromationViewModelList.ProcustionUseId,
                                ProcustionMeasurementId = model.FishInfromationViewModelList.ProcustionMeasurementId,
                                ProcustionQuantity = model.FishInfromationViewModelList.ProcustionQuantity,
                            };
                            await _context.FishInfromation.AddAsync(Fdata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.OtherAnimalInfromationViewModelList != null)
                        {
                            var Odata = new OtherAnimalInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                GhodaCount = model.OtherAnimalInfromationViewModelList.GhodaCount,
                                KhaccedCount = model.OtherAnimalInfromationViewModelList.KhaccedCount,
                                GadhaCount = model.OtherAnimalInfromationViewModelList.GadhaCount,
                                RabbitCount = model.OtherAnimalInfromationViewModelList.RabbitCount,
                                DogCount = model.OtherAnimalInfromationViewModelList.DogCount,
                                CatCount = model.OtherAnimalInfromationViewModelList.CatCount,
                                OtherCount = model.OtherAnimalInfromationViewModelList.OtherCount,
                            };
                            await _context.OtherAnimalInfromation.AddAsync(Odata);
                            await _context.SaveChangesAsync();
                        }
                        if (model.GhaseBaliInfromationViewModelList != null)
                        {
                            var Gdata = new GhaseBaliInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                HudeJaat = model.GhaseBaliInfromationViewModelList.HudeJaat,
                                HudeArea = model.GhaseBaliInfromationViewModelList.HudeArea,
                                HudeGrassProd = model.GhaseBaliInfromationViewModelList.HudeGrassProd,
                                HudeSeedProd = model.GhaseBaliInfromationViewModelList.HudeSeedProd,
                                NurseryJaat = model.GhaseBaliInfromationViewModelList.NurseryJaat,
                                NurseryArea = model.GhaseBaliInfromationViewModelList.NurseryArea,
                                NurseryGrassProd = model.GhaseBaliInfromationViewModelList.NurseryGrassProd,
                                NurserySeedProd = model.GhaseBaliInfromationViewModelList.NurserySeedProd,
                                DaleJaat = model.GhaseBaliInfromationViewModelList.DaleJaat,
                                DaleArea = model.GhaseBaliInfromationViewModelList.DaleArea,
                                DaleGrassProd = model.GhaseBaliInfromationViewModelList.DaleGrassProd,
                                DaleSeedProd = model.GhaseBaliInfromationViewModelList.DaleSeedProd,
                                BahuBarshaJaat = model.GhaseBaliInfromationViewModelList.BahuBarshaJaat,
                                BahuBarshaArea = model.GhaseBaliInfromationViewModelList.BahuBarshaArea,
                                BahuBarshaGrassProd = model.GhaseBaliInfromationViewModelList.BahuBarshaGrassProd,
                                BahuBarshaSeedProd = model.GhaseBaliInfromationViewModelList.BahuBarshaSeedProd,
                                BarshaJaat = model.GhaseBaliInfromationViewModelList.BarshaJaat,
                                BarshaArea = model.GhaseBaliInfromationViewModelList.BarshaArea,
                                BarshaGrassProd = model.GhaseBaliInfromationViewModelList.BarshaGrassProd,
                                BarshaSeedProd = model.GhaseBaliInfromationViewModelList.BarshaSeedProd,
                            };
                            await _context.GhaseBaliInfromation.AddAsync(Gdata);
                            await _context.SaveChangesAsync();
                        }

                        if (model.KrishiFarmInfromationViewModelList != null)
                        {
                            var kdata = new KrishiFarmInfromation()
                            {
                                AnimalHusbandryId = data.Id,
                                DartaNo = model.KrishiFarmInfromationViewModelList.DartaNo,
                                DartaMiti = model.KrishiFarmInfromationViewModelList.DartaMiti,
                                Name = model.KrishiFarmInfromationViewModelList.Name,
                                KaryalayeName = model.KrishiFarmInfromationViewModelList.KaryalayeName,
                                PanNo = model.KrishiFarmInfromationViewModelList.PanNo,
                                ChairpersonName = model.KrishiFarmInfromationViewModelList.ChairpersonName,
                                KrishiFarmTypeId = model.KrishiFarmInfromationViewModelList.KrishiFarmTypeId,
                                MemberCount = model.KrishiFarmInfromationViewModelList.MemberCount,
                                EmploymentCount = model.KrishiFarmInfromationViewModelList.EmploymentCount,
                            };
                            await _context.KrishiFarmInfromation.AddAsync(kdata);
                            await _context.SaveChangesAsync();
                        }

                        if (model.KrishiMechinaryInfromationViewModelList != null)
                        {
                            foreach (var item in model.KrishiMechinaryInfromationViewModelList)
                            {
                                var newdata = new KrishiMechinaryInfromation()
                                {
                                    AnimalHusbandryId = data.Id,
                                    MechinaryName = item.MechinaryName,
                                    Swamitya = item.Swamitya,
                                    Potential = item.Potential,
                                    TotalCount = item.TotalCount,
                                };
                                await _context.KrishiMechinaryInfromation.AddAsync(newdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.KrishiSanrachanaInfromationViewModelList != null)
                        {
                            foreach (var item in model.KrishiSanrachanaInfromationViewModelList)
                            {
                                var Agdata = new KrishiSanrachanaInfromation()
                                {
                                    AnimalHusbandryId = data.Id,
                                    SanrachanaType = item.SanrachanaType,
                                    ToalCount = item.ToalCount,
                                    Area = item.Area,
                                };
                                await _context.KrishiSanrachanaInfromation.AddAsync(Agdata);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("AnimalHusbandry Repo create/update with multiple table (landownership, agrifarm, leasedland) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
