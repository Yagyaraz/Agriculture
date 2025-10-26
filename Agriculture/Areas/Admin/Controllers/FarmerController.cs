using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IFarmer _Farmer;

        public FarmerController( IFarmer farmer)
        {
            _Farmer = farmer;
        }
        #region Farmer
        [HttpGet("GetAllFarmer")]
        public async Task<IActionResult> GetAllFarmer()
        {
            var data = await _Farmer.GetAllFarmer();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetFarmerById/{id}")]
        public async Task<IActionResult> GetFarmerById(int id = 0)
        {
            var data = await _Farmer.GetFarmerById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFarmer")]
        public async Task<IActionResult> CreateFarmer(FarmerViewModel model)
        {
            var (data, newId) = await _Farmer.InsertUpdateFarmer(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = newId });
        }
        #endregion


        #region KrishiDetail

        [HttpGet("GetKrishiDetail/{id}")]
        public async Task<IActionResult> GetKrishiDetail(int id)
        {
            var data = await _Farmer.GetKrishiDetail(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateKrishiDetail")]
        public async Task<IActionResult> CreateKrishiDetail(KrishiDetailsViewModel model)
        {
            var data = await _Farmer.InsertUpdateKrishiDetail(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = model.FarmerId });
        }
        #endregion


        #region Family Details
        [HttpGet("GetFamilyDetails/{id}")]
        public async Task<IActionResult> GetFamilyDetails(int id)
        {
            var data = await _Farmer.GetFamilyDetails(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFamilyDetails")]
        public async Task<IActionResult> CreateFamilyDetails(FamilyDetailssViewModel model)
        {
            var data = await _Farmer.InsertUpdateFamilyDetails(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = model.FarmerId });
        } 
        #endregion


        #region Field Details
        [HttpGet("GetFieldDetails/{id}")]
        public async Task<IActionResult> GetFieldDetails(int id)
        {
            var data = await _Farmer.GetFieldDetails(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFieldDetails")]
        public async Task<IActionResult> CreateFieldDetails(FieldDetailsViewModel model)
        {
            var data = await _Farmer.InsertUpdateFieldDetails(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = model.FarmerId });
        } 
        #endregion


        #region Crops Information
        [HttpGet("GetCropsInformation/{id}")]
        public async Task<IActionResult> GetCropsInformation(int id)
        {
            var data = await _Farmer.GetCropsInformation(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateCropsInformation")]
        public async Task<IActionResult> CreateCropsInformation(CropsInformationViewModel model)
        {
            var data = await _Farmer.InsertUpdateCropsInformation(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = model.FarmerId });
        }
        #endregion

        #region Animal Husbandry
        [HttpGet("GetAnimalHusbandry/{id}")]
        public async Task<IActionResult> GetAnimalHusbandry(int id)
        {
            var data = await _Farmer.GetAnimalHusbandry(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAnimalHusbandry")]
        public async Task<IActionResult> CreateAnimalHusbandry(AnimalHusbandryViewModel model)
        {
            var data = await _Farmer.InsertUpdateAnimalHusbandry(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        } 
        #endregion


    }
}
