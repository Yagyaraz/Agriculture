using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class FarmerServiceController : ControllerBase
    {
        private readonly IFarmerService _FarmerService;

        public FarmerServiceController(IFarmerService farmerService)
        {
            _FarmerService = farmerService;
        }
        #region Family Service

        [HttpGet("GetAllFarmerService")]
        public async Task<IActionResult> GetAllFarmerService()
        {
            var data = await _FarmerService.GetAllFarmerService();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetFarmerServiceById/{id}")]
        public async Task<IActionResult> GetFarmerServiceById(int id = 0)
        {
            var data = await _FarmerService.GetFarmerServiceById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFarmerService")]
        public async Task<IActionResult> CreateFarmerService(FarmerServiceViewModel model)
        {
            var data = await _FarmerService.InsertUpdateFarmerService(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region Farmer Service card

        [HttpGet("GetAllFarmerServiceCard")]
        public async Task<IActionResult> GetAllFarmerServiceCard()
        {
            var data = await _FarmerService.GetAllFarmerServiceCard();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetFarmerServiceCardById/{id}")]
        public async Task<IActionResult> GetFarmerServiceCardById(int id = 0)
        {
            var data = await _FarmerService.GetFarmerServiceCardById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFarmerServiceCard")]
        public async Task<IActionResult> CreateFarmerServiceCard(FarmerServiceCardViewModel model)
        {
            var data = await _FarmerService.InsertUpdateFarmerServiceCard(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        } 
        #endregion
    }
}
