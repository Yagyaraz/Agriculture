using AgricultureView.Areas.Admin.Models;
using AgricultureView.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FarmerViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public FarmerViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetAllFarmer");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<FarmerViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<FarmerViewModel>());
        }

        public async Task<IActionResult> Create(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetFarmerById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FarmerViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FarmerViewModel());
        }
        public async Task<IActionResult> GetFarmerById(int id)
        {
            var model = new FarmerViewModel();

            var farmerResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetFarmerById/" + id);
            if (farmerResponse.Status && farmerResponse.Data != null)
            {
                model = JsonConvert.DeserializeObject<FarmerViewModel>(
                    farmerResponse.Data.ToString()
                );
            }
            else
            {
                return View(new FarmerViewModel());
            }

            var krishiResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetKrishiDetail/" + id);
            if (krishiResponse.Status && krishiResponse.Data != null)
            {
                model.krishi = JsonConvert.DeserializeObject<KrishiDetailsViewModel>(
                    krishiResponse.Data.ToString()
                );
            }

            var familyResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetFamilyDetails/" + id);
            if (familyResponse.Status && familyResponse.Data != null)
            {
                model.Family = JsonConvert.DeserializeObject<FamilyDetailssViewModel>(
                    familyResponse.Data.ToString()
                );
            }

            var fieldResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetFieldDetails/" + id);
            if (fieldResponse.Status && fieldResponse.Data != null)
            {
                model.Field = JsonConvert.DeserializeObject<FieldDetailsViewModel>(
                    fieldResponse.Data.ToString()
                );
            }

            var cropsResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetCropsInformation/" + id);
            if (cropsResponse.Status && cropsResponse.Data != null)
            {
                model.CropsInformation = JsonConvert.DeserializeObject<CropsInformationViewModel>(
                    cropsResponse.Data.ToString()
                );
            }

            var animalResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetAnimalHusbandry/" + id);
            if (animalResponse.Status && animalResponse.Data != null)
            {
                model.Animal = JsonConvert.DeserializeObject<AnimalHusbandryViewModel>(
                    animalResponse.Data.ToString()
                );
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FarmerViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Farmer/CreateFarmer", model);
            if (response.Status)
            {
                return RedirectToAction("CreateKrishiDetails", new { FarmerId = response.Data });
            }
            return View(model);
        }
        #region KrishiDetails
        public async Task<IActionResult> CreateKrishiDetails(int FarmerId = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetKrishiDetail/" + FarmerId);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<KrishiDetailsViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new KrishiDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateKrishiDetails(KrishiDetailsViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Farmer/CreateKrishiDetail", model);
            if (response.Status)
            {
                return RedirectToAction("CreateFamilyDetails", new { FarmerId = response.Data });
            }
            return View(model);
        }
        public IActionResult AgriDetails() => PartialView("_AgricultureDetail", new AgricultureDetailViewModel());
        #endregion

        #region FamilyDetails
        public async Task<IActionResult> CreateFamilyDetails(int FarmerId = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetFamilyDetails/" + FarmerId);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FamilyDetailssViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FamilyDetailssViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFamilyDetails(FamilyDetailssViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Farmer/CreateFamilyDetails", model);
            if (response.Status)
            {
                return RedirectToAction("CreateFieldDetails", new { FarmerId = response.Data });
            }
            return View(model);
        }
        public IActionResult AgriInvolved() => PartialView("_AgricultureInvolvedDetail", new FamilyDetailsInvolvedInAgriViewModel());
        #endregion

        #region FieldDetails
        public async Task<IActionResult> CreateFieldDetails(int FarmerId = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetFieldDetails/" + FarmerId);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FieldDetailsViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FieldDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFieldDetails(FieldDetailsViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Farmer/CreateFieldDetails", model);
            if (response.Status)
            {
                return RedirectToAction("CreateCropsInformation", new { FarmerId = response.Data });
            }
            return View(model);
        }
        public IActionResult LandOwner() => PartialView("_LandOwnership", new LandOwnershipViewModel());
        public IActionResult AgriFarm() => PartialView("_AgriFarmMoreThanOne", new AgriFarmMoreThanOneLocalLevelViewModel());
        public IActionResult LeasedLand() => PartialView("_LeasedLand", new LeasedLandDetailViewModel());
        #endregion

        #region CropsInformation
        public async Task<IActionResult> CreateCropsInformation(int FarmerId = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetCropsInformation/" + FarmerId);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CropsInformationViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CropsInformationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCropsInformation(CropsInformationViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Farmer/CreateCropsInformation", model);
            if (response.Status)
            {
                return RedirectToAction("CreateAnimalHusbandry", new { FarmerId = response.Data });
            }
            return View(model);
        }
        public IActionResult EatableCrops() => PartialView("_EatableCrops", new EatableCropsViewModel());
        public IActionResult FruitCrops() => PartialView("_FruitCrops", new FruitCropsViewModel());
        public IActionResult SeedCrops() => PartialView("_SeedCrops", new SeedCropsViewModel());
        public IActionResult MushroomCrpos() => PartialView("_MushroomCrpos", new MushroomCrposViewModel());
        public IActionResult SilkCrops() => PartialView("_SilkCrops", new SilkCropsViewModel());
        public IActionResult BeeCrops() => PartialView("_BeeCrops", new BeeCropsViewModel());
        #endregion
        #region Animal Husbandry
        public async Task<IActionResult> CreateAnimalHusbandry(int FarmerId = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Farmer/GetAnimalHusbandry/" + FarmerId);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AnimalHusbandryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AnimalHusbandryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimalHusbandry(AnimalHusbandryViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Farmer/CreateAnimalHusbandry", model);
            if (response.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult KrishiMechinary() => PartialView("_KrishiMechinary", new KrishiMechinaryInfromationViewModel());
        public IActionResult KrishiSanrachana() => PartialView("_KrishiSanrachana", new KrishiSanrachanaInfromationViewModel());


        //this is to generate the list of animal Husbandry which are active through setup
        public async Task<JsonResult> GetAllActiveAgriculture()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Common/GetAllActiveAgriculture");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        #endregion


    }
}
