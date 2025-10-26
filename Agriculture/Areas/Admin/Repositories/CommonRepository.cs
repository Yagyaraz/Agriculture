using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Models;
using Agriculture.Security;
using Agriculture.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class CommonRepository : ICommon
    {
        private readonly AgricultureDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<CommonRepository> _logger;

        private readonly IUtility _utility;
        private readonly string _userId;
        private readonly IHttpContextAccessor _httpContext;

        public CommonRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ILogger<CommonRepository> logger)
        {
            _context = context;
            _utility = utility;
            _httpContext = httpContextAccessor;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.userManager = userManager;
            this.roleManager = roleManager;
            _logger = logger;

        }

        #region FisacalYear
        public async Task<List<FiscalYearViewModel>> GetAllFiscalYear()
        {
            return await _context.FiscalYear
                .Select(x => new FiscalYearViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Name_En = x.Name_En,
                    StartYear = x.StartYear,
                    EndYear = x.EndYear,
                    Code = x.Code,
                    PreviousFiscalYearId = x.PreviousFiscalYearId,
                    IsActive = x.IsActive,
                    DateFrom = x.DateFrom,
                    DateFromEng = x.DateFromEng,
                    DateTo = x.DateTo,
                    DateToEng = x.DateToEng,
                }).ToListAsync();
        }
        public async Task<FiscalYearViewModel> GetFiscalYearById(int id)
        {
            return await _context.FiscalYear.Where(x => x.Id == id)
                .Select(x => new FiscalYearViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Name_En = x.Name_En,
                    Code = x.Code,
                    StartYear = x.StartYear,
                    EndYear = x.EndYear,
                    IsActive = x.IsActive,
                    DateFrom = x.DateFrom,
                    DateFromEng = x.DateFromEng,
                    DateTo = x.DateTo,
                    DateToEng = x.DateToEng,
                    PreviousFiscalYearId = x.PreviousFiscalYearId,
                }).FirstOrDefaultAsync() ?? new FiscalYearViewModel();
        }
        public async Task<bool> InsertUpdateFiscalYear(FiscalYearViewModel model)
        {
            try
            {
                if (model.IsActive == true)
                {
                    foreach (var item in await _context.FiscalYear.Where(x => x.IsActive == true).ToListAsync())
                    {
                        item.IsActive = false;
                        _context.Entry(item).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }

                var fiscalYear = await _context.FiscalYear.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (fiscalYear != null)
                {
                    fiscalYear.Name = model.Name;
                    fiscalYear.Name_En = model.Name_En;
                    fiscalYear.StartYear = model.StartYear;
                    fiscalYear.EndYear = model.EndYear;
                    fiscalYear.Code = model.Code;
                    fiscalYear.IsActive = model.IsActive;
                    fiscalYear.DateFrom = model.DateFrom;
                    fiscalYear.DateFromEng = model.DateFromEng;
                    fiscalYear.DateTo = model.DateTo;
                    fiscalYear.DateToEng = model.DateToEng;
                    fiscalYear.PreviousFiscalYearId = model.PreviousFiscalYearId;
                    fiscalYear.UpdatedBy = _userId;
                    fiscalYear.UpdatedDate = DateTime.Now;

                    _context.Entry(fiscalYear).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var fiscal = new FiscalYear()
                    {
                        Name = model.Name,
                        Name_En = model.Name_En,
                        StartYear = model.StartYear,
                        EndYear = model.EndYear,
                        Code = model.Code,
                        IsActive = model.IsActive,
                        DateFrom = model.DateFrom,
                        DateFromEng = model.DateFromEng,
                        DateTo = model.DateTo,
                        DateToEng = model.DateToEng,
                        PreviousFiscalYearId = model.PreviousFiscalYearId,
                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                    };
                    await _context.FiscalYear.AddAsync(fiscal);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Office
        public async Task<List<OfficeViewModel>> GetAllOffice()
        {
            return await _context.Office
                .Select(x => new OfficeViewModel()
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

                }).ToListAsync();
        }
        public async Task<OfficeViewModel> GetOfficeById(int id)
        {
            return await _context.Office
                       .Select(x => new OfficeViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           Name_En = x.Name_En,
                           Code = x.Code,
                           Address = x.Address,
                           Address_En = x.Address_En,
                           PhoneNo = x.PhoneNo,
                           FaxNo = x.FaxNo,
                           Email = x.Email,
                           Url = x.Url,
                           StateId = x.StateId,
                           DistrictId = x.DistrictId,
                           PalikaId = x.PalikaId,
                           PalikaName = x.Palika.PalikaNameNep,
                           StateName = x.State.StateNameNep,
                           DistrictName = x.District.DistrictNameNep,
                           StateName_En = x.State.StateName,
                           DistrictName_En = x.District.DistrictName,
                           PalikaName_En = x.Palika.PalikaName
                       }).FirstOrDefaultAsync() ?? new OfficeViewModel();
        }
        public async Task<bool> InsertUpdateOffice(OfficeViewModel model)
        {
            try
            {
                var data = _context.Office.FirstOrDefault();
                if (data != null)
                {
                    data.Name = model.Name;
                    data.Name_En = model.Name_En;
                    data.Code = model.Code;
                    data.Address = model.Address;
                    data.Address_En = model.Address_En;
                    data.PhoneNo = model.PhoneNo;
                    data.FaxNo = model.FaxNo;
                    data.Email = model.Email;
                    data.Url = model.Url;
                    data.StateId = model.StateId;
                    data.DistrictId = model.DistrictId;
                    data.PalikaId = model.PalikaId;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new Office()
                    {
                        Name = model.Name,
                        Name_En = model.Name_En,
                        Code = model.Code,
                        Address = model.Address,
                        Address_En = model.Address_En,
                        PhoneNo = model.PhoneNo,
                        FaxNo = model.FaxNo,
                        Email = model.Email,
                        Url = model.Url,
                        StateId = model.StateId,
                        DistrictId = model.DistrictId,
                        PalikaId = model.PalikaId,
                    };
                    await _context.Office.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region EducationLevel
        public async Task<List<CommonViewModel>> GetAllEducationLevel()
        {
            return await _context.EducationLevel
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                }).ToListAsync();
        }
        public async Task<CommonViewModel> GetEducationLevelById(int id)
        {
            return await _context.EducationLevel.Where(x => x.Id == id)
                       .Select(x => new CommonViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                       }).FirstOrDefaultAsync() ?? new CommonViewModel();
        }
        public async Task<bool> InsertUpdateEducationLevel(CommonViewModel model)
        {
            try
            {
                var data = _context.EducationLevel.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new EducationLevel()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                    };
                    await _context.EducationLevel.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region FarmerGroup
        public async Task<List<CommonViewModel>> GetAllFarmerGroup()
        {
            return await _context.FarmerGroup
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                }).ToListAsync();
        }
        public async Task<CommonViewModel> GetFarmerGroupById(int id)
        {
            return await _context.FarmerGroup.Where(x => x.Id == id)
                       .Select(x => new CommonViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                       }).FirstOrDefaultAsync() ?? new CommonViewModel();
        }
        public async Task<bool> InsertUpdateFarmerGroup(CommonViewModel model)
        {
            try
            {
                var data = _context.FarmerGroup.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new FarmerGroup()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                    };
                    await _context.FarmerGroup.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region WardSetup
        public async Task<List<CommonViewModel>> GetAllWardSetup()
        {
            return await _context.Ward
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                }).ToListAsync();
        }
        public async Task<CommonViewModel> GetWardSetupById(int id)
        {
            return await _context.Ward.Where(x => x.Id == id)
                       .Select(x => new CommonViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                       }).FirstOrDefaultAsync() ?? new CommonViewModel();
        }
        public async Task<bool> InsertUpdateWardSetup(CommonViewModel model)
        {
            try
            {
                var data = _context.Ward.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new Ward()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                    };
                    await _context.Ward.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region FarmerCategory
        public async Task<List<CommonViewModel>> GetAllFarmerCategory()
        {
            return await _context.FarmerCategory
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                }).ToListAsync();
        }
        public async Task<CommonViewModel> GetFarmerCategoryById(int id)
        {
            return await _context.FarmerCategory.Where(x => x.Id == id)
                       .Select(x => new CommonViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                       }).FirstOrDefaultAsync() ?? new CommonViewModel();
        }
        public async Task<bool> InsertUpdateFarmerCategory(CommonViewModel model)
        {
            try
            {
                var data = _context.FarmerCategory.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new FarmerCategory()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                    };
                    await _context.FarmerCategory.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region AnimalSetup

        public async Task<List<AnimalSetupViewModel>> GetAllAnimalSetup()
        {
            return await _context.AnimalSetup
                       .Select(x => new AnimalSetupViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                           IsSelect = x.IsSelect,
                       }).ToListAsync();
        }


        public async Task<bool> GetAnimalSetupById(BooleianViewModel model)
        {
            try
            {
                var data = await _context.AnimalSetup.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (data != null)
                {
                    data.IsSelect = model.IsSelect == true ? true : false;

                    _context.Entry(data).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> InsertUpdateAnimalSetup(AnimalSetupViewModel model)
        {
            try
            {
                var data = _context.AnimalSetup.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;
                    data.IsSelect = model.IsSelect;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new AnimalSetup()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                        IsSelect = model.IsSelect,
                    };
                    await _context.AnimalSetup.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<SelectList> GetAllActiveAgriculture()
        {
            return new SelectList(await _context.AnimalSetup.Where(x => x.IsSelect == true).ToListAsync(), "Id", "Name");
        }
        #endregion

        #region UserList
        //public async Task<ApiResponse> RegisterUser(RegisterViewModel model)
        //{
        //    try
        //    {
        //        var existingEmail = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToUpper() == model.Email.ToUpper());

        //        var userExists = await userManager.FindByNameAsync(existingEmail.Email);
        //        if (userExists != null)
        //            return new ApiResponse { Status = false, Message = "User Already Registered !" };
        //        var user = new ApplicationUser
        //        {
        //            UserName = model.Email,
        //            Email = model.Email,
        //            FullName = model.FullName,
        //            FullNameNep = model.FullNameNep,
        //            WardId = model.WardId,
        //            IsActive = true,
        //            EmailConfirmed = true,
        //        };
        //        IdentityResult result = await userManager.CreateAsync(user, model.Password);
        //        if (!result.Succeeded)
        //        {
        //            var errors = new List<string>();
        //            foreach (var item in result.Errors)
        //            {
        //                errors.Add(item.Description);
        //            }
        //            return new ApiResponse { Status = false, Message = string.Join(null, errors.ToList()) };
        //        }
        //        if (result.Succeeded)
        //        {
        //            var userid = await _context.Users.Where(x => x.UserName == model.Email).Select(x => x.Id).FirstOrDefaultAsync();
        //            if (!string.IsNullOrWhiteSpace(model.Role) && await roleManager.RoleExistsAsync(model.Role))
        //            {
        //                await userManager.AddToRoleAsync(user, model.Role);
        //            }
        //            return new ApiResponse { Status = true, Message = "Employee Register SuccessFully", Data = userid };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation("Register User Error : ", ex);
        //    }
        //    return new ApiResponse { Status = false, Message = "User Not Register, Please Try Again !" };

        //}
        public async Task<ApiResponse> RegisterUser(RegisterViewModel model)
        {
            try
            {
                var existingEmail = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToUpper() == model.Email.ToUpper());


                if (existingEmail != null)
                {
                    return new ApiResponse { Status = false, Message = "User Already Registered!" };
                }
                var farmerWard = model.FarmerId != null && model.FarmerId != 0
            ? await _context.Farmer.Where(z => z.Id == model.FarmerId).FirstOrDefaultAsync() : null;


                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = farmerWard == null ? model.FullName : farmerWard.FullNameEng,
                    FullNameNep = farmerWard == null ? model.FullNameNep : farmerWard.FullName,
                    PhoneNumber = farmerWard == null ? model.PhoneNo : farmerWard.PhoneNo,
                    WardId = farmerWard == null ? model.WardId : farmerWard.WardNo,
                    FarmerId = model.FarmerId,
                    IsActive = true,
                    EmailConfirmed = true,
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    var errors = new List<string>();
                    foreach (var item in result.Errors)
                    {
                        errors.Add(item.Description);
                    }
                    return new ApiResponse { Status = false, Message = string.Join(null, errors.ToList()) };
                }
                if (result.Succeeded)
                {
                    var userid = await _context.Users.Where(x => x.UserName == model.Email).Select(x => x.Id).FirstOrDefaultAsync();
                    if (!string.IsNullOrWhiteSpace(model.Role) && await roleManager.RoleExistsAsync(model.Role))
                    {
                        await userManager.AddToRoleAsync(user, model.Role);
                    }
                    return new ApiResponse { Status = true, Message = "Employee Register SuccessFully", Data = userid };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user");
                return new ApiResponse { Status = false, Message = "User Not Registered, Please Try Again!" };
            }
            return new ApiResponse { Status = false, Message = "User Not Register, Please Try Again !" };
        }






        public async Task<List<RegisterViewModel>> GetAllUserList()
        {
            if (!_httpContext.HttpContext.User.IsInRole(UserRoles.Administrator) && !_httpContext.HttpContext.User.IsInRole(UserRoles.SuperAdmin))
            {
                var userId = _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
                return await _context.Users
                    .Where(x => !x.UserName.Equals("softech@gmail.com")
                    && !x.UserName.Equals("superadmin@gmail.com")
                    && (userId == null || x.Id == userId)
                    ).Select(x => new RegisterViewModel()
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        UserName = x.UserName,
                        Email = x.Email,
                        Role = (from ur in _context.UserRoles join r in _context.Roles on ur.RoleId equals r.Id where ur.UserId == x.Id select r.Name).FirstOrDefault(),
                        //Active = (x.LockoutEnd ?? DateTime.UtcNow) <= DateTime.UtcNow
                    }).ToListAsync();
            }
            return await _context.Users.Where(x => !x.UserName.Equals("softech@gmail.com") && !x.UserName.Equals("superadmin@gmail.com"))
               .Select(x => new RegisterViewModel()
               {
                   Id = x.Id,
                   FullName = x.FullName,
                   UserName = x.UserName,
                   Email = x.Email,
                   Role = (from ur in _context.UserRoles join r in _context.Roles on ur.RoleId equals r.Id where ur.UserId == x.Id select r.Name).FirstOrDefault(),
                   //Active = (x.LockoutEnd ?? DateTime.UtcNow) <= DateTime.UtcNow
               }).ToListAsync();
        }

        #endregion
    }
}
