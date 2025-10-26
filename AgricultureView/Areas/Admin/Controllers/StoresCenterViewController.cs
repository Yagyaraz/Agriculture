using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoresCenterViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public StoresCenterViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region FertilizerStore
        public async Task<IActionResult> FertilizerStore()
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllFertilizerStore");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<FertilizerStoreViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<FertilizerStoreViewModel>());
        }

        public async Task<IActionResult> CreateFertilizerStore(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetFertilizerStoreById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FertilizerStoreViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FertilizerStoreViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateFertilizerStore(FertilizerStoreViewModel model)
        {
            //using (MultipartFormDataContent formData = new MultipartFormDataContent())
            //{
            //    // Adding simple form data
            //    formData.Add(new StringContent(model.Id.ToString()), "Id");
            //    formData.Add(new StringContent(model.Name), "Name");
            //    formData.Add(new StringContent(model.Email), "Email");
            //    formData.Add(new StringContent(model.PhoneNo), "PhoneNo");
            //    formData.Add(new StringContent(model.Address), "Address");

            //    // Adding complex data (lists) as JSON strings
            //    var productionListJson = JsonConvert.SerializeObject(model.FertilizerStoreProductionViewModelList);
            //    formData.Add(new StringContent(productionListJson, Encoding.UTF8, "application/json"), "FertilizerStoreProductionViewModelList");

            //    var contactPersonListJson = JsonConvert.SerializeObject(model.FertilizerStoreContactPersonViewModelList);
            //    formData.Add(new StringContent(contactPersonListJson, Encoding.UTF8, "application/json"), "FertilizerStoreContactPersonViewModelList");

            //    // Adding a file (if any)
            //    if (model.Photo != null)
            //    {
            //        StreamContent photoContent = new StreamContent(model.Photo.OpenReadStream());
            //        formData.Add(photoContent, "Photo", model.Photo.FileName);
            //    }

            //    // Sending the form data to the API
            //    var response = await _globalVeriable.PostFileMethodWithPartial("Admin/StoresCenter/CreateFertilizerStore", formData);
            //    if (response.Status)
            //    {
            //        return RedirectToAction("FertilizerStore");
            //    }
            //}
            var response = await _globalVeriable.PostMethod("Admin/StoresCenter/CreateFertilizerStore", model);
            if (response.Status)
            {
                return RedirectToAction("FertilizerStore");
            }
            return View(model);
        }

        public IActionResult StorageProduction() => PartialView("_StorageProduction", new FertilizerStoreProductionViewModel());
        public IActionResult ContactPerson() => PartialView("_ContactPerson", new FertilizerStoreContactPersonViewModel());

        #endregion

        #region SeedStore
        public async Task<IActionResult> SeedStore()
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllSeedStore");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<SeedStoreViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<SeedStoreViewModel>());
        }

        public async Task<IActionResult> CreateSeedStore(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetSeedStoreById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SeedStoreViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new SeedStoreViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeedStore(SeedStoreViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/StoresCenter/CreateSeedStore", model);
            if (response.Status)
            {
                return RedirectToAction("SeedStore");
            }
            return View(model);
        }

        public IActionResult SeedStorageProduction() => PartialView("_SeedStorageProduction", new SeedStoreProductionViewModel());
        public IActionResult SeedStorageContactPerson() => PartialView("_SeedStorageContactPerson", new SeedStoreContactPersonViewModel());

        #endregion

        #region InsuranceCenter
        public async Task<IActionResult> InsuranceCenter()
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllInsuranceCenter");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<InsuranceCenterViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<InsuranceCenterViewModel>());
        }

        public async Task<IActionResult> CreateInsuranceCenter(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetInsuranceCenterById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<InsuranceCenterViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new InsuranceCenterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateInsuranceCenter(InsuranceCenterViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/StoresCenter/CreateInsuranceCenter", model);
            if (response.Status)
            {
                return RedirectToAction("InsuranceCenter");
            }
            return View(model);
        }

        #endregion
        #region AgricultureEquipment
        public async Task<IActionResult> AgricultureEquipment()
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllAgricultureEquipment");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgricultureEquipmentViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgricultureEquipmentViewModel>());
        }

        public async Task<IActionResult> CreateAgricultureEquipment(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAgricultureEquipmentById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureEquipmentViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureEquipmentViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgricultureEquipment(AgricultureEquipmentViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/StoresCenter/CreateAgricultureEquipment", model);
            if (response.Status)
            {
                return RedirectToAction("AgricultureEquipment");
            }
            return View(model);
        }

        #endregion
    }
}
