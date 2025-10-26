using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class StoresCenterController : ControllerBase
    {

        private readonly IStoresCenter _StoresCenter;
        public StoresCenterController(IStoresCenter storesCenter)
        {
            _StoresCenter = storesCenter;
        }
        #region FertilizerStore

        [HttpGet("GetAllFertilizerStore")]
        public async Task<IActionResult> GetAllFertilizerStore()
        {
            var data = await _StoresCenter.GetAllFertilizerStore();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetFertilizerStoreById/{id}")]
        public async Task<IActionResult> GetFertilizerStoreById(int id = 0)
        {
            var data = await _StoresCenter.GetFertilizerStoreById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFertilizerStore")]
        public async Task<IActionResult> CreateFertilizerStore(FertilizerStoreViewModel model)
        {
            var data = await _StoresCenter.InsertUpdateFertilizerStore(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region SeedStore

        [HttpGet("GetAllSeedStore")]
        public async Task<IActionResult> GetAllSeedStore()
        {
            var data = await _StoresCenter.GetAllSeedStore();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetSeedStoreById/{id}")]
        public async Task<IActionResult> GetSeedStoreById(int id = 0)
        {
            var data = await _StoresCenter.GetSeedStoreById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateSeedStore")]
        public async Task<IActionResult> CreateSeedStore(SeedStoreViewModel model)
        {
            var data = await _StoresCenter.InsertUpdateSeedStore(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region InsuranceCenter

        [HttpGet("GetAllInsuranceCenter")]
        public async Task<IActionResult> GetAllInsuranceCenter()
        {
            var data = await _StoresCenter.GetAllInsuranceCenter();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetInsuranceCenterById/{id}")]
        public async Task<IActionResult> GetInsuranceCenterById(int id = 0)
        {
            var data = await _StoresCenter.GetInsuranceCenterById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateInsuranceCenter")]
        public async Task<IActionResult> CreateInsuranceCenter(InsuranceCenterViewModel model)
        {
            var data = await _StoresCenter.InsertUpdateInsuranceCenter(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region AgricultureEquipment

        [HttpGet("GetAllAgricultureEquipment")]
        public async Task<IActionResult> GetAllAgricultureEquipment()
        {
            var data = await _StoresCenter.GetAllAgricultureEquipment();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetAgricultureEquipmentById/{id}")]
        public async Task<IActionResult> GetAgricultureEquipmentById(int id = 0)
        {
            var data = await _StoresCenter.GetAgricultureEquipmentById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAgricultureEquipment")]
        public async Task<IActionResult> CreateAgricultureEquipment(AgricultureEquipmentViewModel model)
        {
            var data = await _StoresCenter.InsertUpdateAgricultureEquipment(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
    }
}
