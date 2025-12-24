using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agriculture.Areas.Admin.Repositories
{
    public class StoresCenterRepository : IStoresCenter
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<StoresCenterRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public StoresCenterRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<StoresCenterRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }
        #region FertilizerStore

        public async Task<List<FertilizerStoreViewModel>> GetAllFertilizerStore()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.FertilizerStore.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new FertilizerStoreViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    //DisplayPhotoPath = x.FilePath,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                }).ToListAsync();
        }

        public async Task<FertilizerStoreViewModel> GetFertilizerStoreById(int id)
        {
            return await _context.FertilizerStore.Where(x => x.Id == id)
                  .Select(x => new FertilizerStoreViewModel()
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Address = x.Address,
                      //DisplayPhotoPath = x.FilePath,
                      Email = x.Email,
                      PhoneNo = x.PhoneNo,
                      FertilizerStoreProductionViewModelList = _context.FertilizerStoreProduction.Where(z => z.FertilizerStoreId == id)
                      .Select(z => new FertilizerStoreProductionViewModel()
                      {
                          Id = z.Id,
                          FertilizerStoreId = z.FertilizerStoreId,
                          CategoryId = z.CategoryId,
                          ProductId = z.ProductId,
                          TypeId = z.TypeId,
                      }).ToList() ?? new List<FertilizerStoreProductionViewModel>(),

                      FertilizerStoreContactPersonViewModelList = _context.FertilizerStoreContactPerson.Where(q => q.FertilizerStoreId == id)
                      .Select(q => new FertilizerStoreContactPersonViewModel()
                      {
                          Id = q.Id,
                          FertilizerStoreId = q.FertilizerStoreId,
                          Name = q.Name,
                          PhoneNo = q.PhoneNo,
                      }).ToList() ?? new List<FertilizerStoreContactPersonViewModel>(),
                  }).FirstOrDefaultAsync() ?? new FertilizerStoreViewModel();
        }

        public async Task<bool> InsertUpdateFertilizerStore(FertilizerStoreViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var filepath = "";

                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.FertilizerStore.FirstOrDefaultAsync(x => x.Id == model.Id);
                        //if (model.Photo != null)
                        //{
                        //    filepath = _utility.UploadImgReturnPathAndName("FertilizerStore", model.Photo, "Photo").Result.FilePath;
                        //    if (app.FilePath != null)
                        //    {
                        //        await _utility.RemoveFileFormServer(app.FilePath);
                        //    }
                        //}
                        if (app != null)
                        {
                            app.Id = model.Id;
                            app.Name = model.Name;
                            app.Address = model.Address;
                            app.Email = model.Email;
                            app.PhoneNo = model.PhoneNo;
                            //app.FilePath = filepath == "" ? app.FilePath : filepath;

                            app.UpdatedBy = _userId;
                            app.UpdatedDate = DateTime.Now;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.FertilizerStoreProductionViewModelList != null)
                            {
                                foreach (var item in await _context.FertilizerStoreProduction.Where(x => x.FertilizerStoreId == model.Id).ToListAsync())
                                {
                                    if (!model.FertilizerStoreProductionViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.FertilizerStoreProduction.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.FertilizerStoreProductionViewModelList)
                                {
                                    var data = await _context.FertilizerStoreProduction.FirstOrDefaultAsync(x => x.Id == item.Id);
                                    if (data != null)
                                    {
                                        data.TypeId = item.TypeId;
                                        data.CategoryId = item.CategoryId;
                                        data.ProductId = item.ProductId;

                                        data.UpdatedBy = _userId;
                                        data.UpdatedDate = DateTime.Now;

                                        _context.Entry(data).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var adata = new FertilizerStoreProduction()
                                        {
                                            FertilizerStoreId = model.Id,
                                            TypeId = item.TypeId,
                                            CategoryId = item.CategoryId,
                                            ProductId = item.ProductId,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.FertilizerStoreProduction.AddAsync(adata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.FertilizerStoreContactPersonViewModelList != null)
                            {
                                foreach (var item in await _context.FertilizerStoreContactPerson.Where(x => x.FertilizerStoreId == model.Id).ToListAsync())
                                {
                                    if (!model.FertilizerStoreContactPersonViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.FertilizerStoreContactPerson.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.FertilizerStoreContactPersonViewModelList)
                                {
                                    var fdata = await _context.FertilizerStoreContactPerson.FirstOrDefaultAsync(x => x.Id == item.Id);
                                    if (fdata != null)
                                    {
                                        fdata.Name = item.Name;
                                        fdata.PhoneNo = item.PhoneNo;

                                        fdata.UpdatedBy = _userId;
                                        fdata.UpdatedDate = DateTime.Now;

                                        _context.Entry(fdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var dataa = new FertilizerStoreContactPerson()
                                        {
                                            FertilizerStoreId = model.Id,
                                            Name = item.Name,
                                            PhoneNo = item.PhoneNo,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.FertilizerStoreContactPerson.AddAsync(dataa);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }

                        }
                        else return false;
                    }
                    else
                    {
                        //if (model.Photo != null)
                        //{
                        //    filepath = _utility.UploadImgReturnPathAndName("FertilizerStore", model.Photo, "Photo").Result.FilePath;
                        //}
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var newdata = new FertilizerStore()
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Address = model.Address,
                            PhoneNo = model.PhoneNo,
                            //FilePath = filepath,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.FertilizerStore.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                        if (model.FertilizerStoreProductionViewModelList != null)
                        {
                            foreach (var item in model.FertilizerStoreProductionViewModelList)
                            {
                                var dara = new FertilizerStoreProduction()
                                {
                                    FertilizerStoreId = newdata.Id,
                                    TypeId = item.TypeId,
                                    CategoryId = item.CategoryId,
                                    ProductId = item.ProductId,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.FertilizerStoreProduction.AddAsync(dara);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.FertilizerStoreContactPersonViewModelList != null)
                        {
                            foreach (var item in model.FertilizerStoreContactPersonViewModelList)
                            {
                                var dataa = new FertilizerStoreContactPerson()
                                {
                                    FertilizerStoreId = newdata.Id,
                                    Name = item.Name,
                                    PhoneNo = item.PhoneNo,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.FertilizerStoreContactPerson.AddAsync(dataa);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("InsertUpdateFertilizerStore Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion

        #region SeedStore

        public async Task<List<SeedStoreViewModel>> GetAllSeedStore()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.SeedStore.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new SeedStoreViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    //DisplayPhotoPath = x.FilePath,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                }).ToListAsync();
        }

        public async Task<SeedStoreViewModel> GetSeedStoreById(int id)
        {
            return await _context.SeedStore.Where(x => x.Id == id)
                  .Select(x => new SeedStoreViewModel()
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Address = x.Address,
                      //DisplayPhotoPath = x.FilePath,
                      Email = x.Email,
                      PhoneNo = x.PhoneNo,
                      SeedStoreProductionViewModelList = _context.SeedStoreProduction.Where(z => z.SeedStoreId == id)
                      .Select(z => new SeedStoreProductionViewModel()
                      {
                          Id = z.Id,
                          SeedStoreId = z.SeedStoreId,
                          CategoryId = z.CategoryId,
                          ProductId = z.ProductId,
                          TypeId = z.TypeId,
                      }).ToList() ?? new List<SeedStoreProductionViewModel>(),

                      SeedStoreContactPersonViewModelList = _context.SeedStoreContactPerson.Where(q => q.SeedStoreId == id)
                      .Select(q => new SeedStoreContactPersonViewModel()
                      {
                          Id = q.Id,
                          SeedStoreId = q.SeedStoreId,
                          Name = q.Name,
                          PhoneNo = q.PhoneNo,
                      }).ToList() ?? new List<SeedStoreContactPersonViewModel>(),
                  }).FirstOrDefaultAsync() ?? new SeedStoreViewModel();
        }

        public async Task<bool> InsertUpdateSeedStore(SeedStoreViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var filepath = "";

                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.SeedStore.FirstOrDefaultAsync(x => x.Id == model.Id);
                        //if (model.Photo != null)
                        //{
                        //    filepath = _utility.UploadImgReturnPathAndName("SeedStore", model.Photo, "Photo").Result.FilePath;
                        //    if (app.FilePath != null)
                        //    {
                        //        await _utility.RemoveFileFormServer(app.FilePath);
                        //    }
                        //}
                        if (app != null)
                        {
                            app.Id = model.Id;
                            app.Name = model.Name;
                            app.Address = model.Address;
                            app.Email = model.Email;
                            app.PhoneNo = model.PhoneNo;
                            //app.FilePath = filepath == "" ? app.FilePath : filepath;

                            app.UpdatedBy = _userId;
                            app.UpdatedDate = DateTime.Now;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.SeedStoreProductionViewModelList != null)
                            {
                                foreach (var item in await _context.SeedStoreProduction.Where(x => x.SeedStoreId == model.Id).ToListAsync())
                                {
                                    if (!model.SeedStoreProductionViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.SeedStoreProduction.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.SeedStoreProductionViewModelList)
                                {
                                    var data = await _context.SeedStoreProduction.FirstOrDefaultAsync(x => x.Id == item.Id);
                                    if (data != null)
                                    {
                                        data.TypeId = item.TypeId;
                                        data.CategoryId = item.CategoryId;
                                        data.ProductId = item.ProductId;

                                        data.UpdatedBy = _userId;
                                        data.UpdatedDate = DateTime.Now;

                                        _context.Entry(data).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var adata = new SeedStoreProduction()
                                        {
                                            SeedStoreId = model.Id,
                                            TypeId = item.TypeId,
                                            CategoryId = item.CategoryId,
                                            ProductId = item.ProductId,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.SeedStoreProduction.AddAsync(adata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                            if (model.SeedStoreContactPersonViewModelList != null)
                            {
                                foreach (var item in await _context.SeedStoreContactPerson.Where(x => x.SeedStoreId == model.Id).ToListAsync())
                                {
                                    if (!model.SeedStoreContactPersonViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.SeedStoreContactPerson.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.SeedStoreContactPersonViewModelList)
                                {
                                    var fdata = await _context.SeedStoreContactPerson.FirstOrDefaultAsync(x => x.Id == item.Id);
                                    if (fdata != null)
                                    {
                                        fdata.Name = item.Name;
                                        fdata.PhoneNo = item.PhoneNo;

                                        fdata.UpdatedBy = _userId;
                                        fdata.UpdatedDate = DateTime.Now;

                                        _context.Entry(fdata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var dataa = new SeedStoreContactPerson()
                                        {
                                            SeedStoreId = model.Id,
                                            Name = item.Name,
                                            PhoneNo = item.PhoneNo,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.SeedStoreContactPerson.AddAsync(dataa);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                        else return false;
                    }
                    else
                    {
                        //if (model.Photo != null)
                        //{
                        //    filepath = _utility.UploadImgReturnPathAndName("SeedStore", model.Photo, "Photo").Result.FilePath;
                        //}
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var newdata = new SeedStore()
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Address = model.Address,
                            PhoneNo = model.PhoneNo,
                            //FilePath = filepath,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.SeedStore.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                        if (model.SeedStoreProductionViewModelList != null)
                        {
                            foreach (var item in model.SeedStoreProductionViewModelList)
                            {
                                var dara = new SeedStoreProduction()
                                {
                                    SeedStoreId = newdata.Id,
                                    TypeId = item.TypeId,
                                    CategoryId = item.CategoryId,
                                    ProductId = item.ProductId,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.SeedStoreProduction.AddAsync(dara);
                                await _context.SaveChangesAsync();
                            }
                        }
                        if (model.SeedStoreContactPersonViewModelList != null)
                        {
                            foreach (var item in model.SeedStoreContactPersonViewModelList)
                            {
                                var dataa = new SeedStoreContactPerson()
                                {
                                    SeedStoreId = newdata.Id,
                                    Name = item.Name,
                                    PhoneNo = item.PhoneNo,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.SeedStoreContactPerson.AddAsync(dataa);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("InsertUpdateSeedStore Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
        #region InsuranceCenter

        public async Task<List<InsuranceCenterViewModel>> GetAllInsuranceCenter()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.InsuranceCenter.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new InsuranceCenterViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                }).ToListAsync();
        }

        public async Task<InsuranceCenterViewModel> GetInsuranceCenterById(int id)
        {
            return await _context.InsuranceCenter.Where(x => x.Id == id)
                  .Select(x => new InsuranceCenterViewModel()
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Address = x.Address,
                      Email = x.Email,
                      PhoneNo = x.PhoneNo,
                  }).FirstOrDefaultAsync() ?? new InsuranceCenterViewModel();
        }

        public async Task<bool> InsertUpdateInsuranceCenter(InsuranceCenterViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.InsuranceCenter.FirstOrDefaultAsync(x => x.Id == model.Id);

                        if (app != null)
                        {
                            app.Id = model.Id;
                            app.Name = model.Name;
                            app.Address = model.Address;
                            app.Email = model.Email;
                            app.PhoneNo = model.PhoneNo;

                            app.UpdatedBy = _userId;
                            app.UpdatedDate = DateTime.Now;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                        }
                        else return false;
                    }
                    else
                    {
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var newdata = new InsuranceCenter()
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Address = model.Address,
                            PhoneNo = model.PhoneNo,


                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.InsuranceCenter.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("InsertUpdateInsuranceCenter Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
        #region AgricultureEquipment

        public async Task<List<AgricultureEquipmentViewModel>> GetAllAgricultureEquipment()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.AgricultureEquipment.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                .Select(x => new AgricultureEquipmentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                }).ToListAsync();
        }

        public async Task<AgricultureEquipmentViewModel> GetAgricultureEquipmentById(int id)
        {
            return await _context.AgricultureEquipment.Where(x => x.Id == id)
                  .Select(x => new AgricultureEquipmentViewModel()
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Address = x.Address,
                      Email = x.Email,
                      PhoneNo = x.PhoneNo,
                  }).FirstOrDefaultAsync() ?? new AgricultureEquipmentViewModel();
        }

        public async Task<bool> InsertUpdateAgricultureEquipment(AgricultureEquipmentViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.AgricultureEquipment.FirstOrDefaultAsync(x => x.Id == model.Id);

                        if (app != null)
                        {
                            app.Id = model.Id;
                            app.Name = model.Name;
                            app.Address = model.Address;
                            app.Email = model.Email;
                            app.PhoneNo = model.PhoneNo;

                            app.UpdatedBy = _userId;
                            app.UpdatedDate = DateTime.Now;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                        }
                        else return false;
                    }
                    else
                    {
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var newdata = new AgricultureEquipment()
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Address = model.Address,
                            PhoneNo = model.PhoneNo,


                            CreatedBy = _userId,
                            CreatedWardId = wardId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.AgricultureEquipment.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("InsertUpdateAgricultureEquipment Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
    }
}
