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
    public class AgricultureFarmerGroupController : ControllerBase
    {
        public readonly IAgricultureFarmerGroup _AgricultureFarmerGroup;
        public AgricultureFarmerGroupController(IAgricultureFarmerGroup agricultureFarmerGroup)
        {
            _AgricultureFarmerGroup = agricultureFarmerGroup;
        }
        [HttpGet("GetAllAgricultureFarmerGroup")]
        public async Task<IActionResult> GetAllAgricultureFarmerGroup()
        {
            var data = await _AgricultureFarmerGroup.GetAllAgricultureFarmerGroup();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetAgricultureFarmerGroupById/{id}")]
        public async Task<IActionResult> GetAgricultureFarmerGroupById(int id = 0)
        {
            var data = await _AgricultureFarmerGroup.GetAgricultureFarmerGroupById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAgricultureFarmerGroup")]
        public async Task<IActionResult> CreateAgricultureFarmerGroup(AgricultureFarmerGroupViewModel model)
        {
            var data = await _AgricultureFarmerGroup.InsertUpdateAgricultureFarmerGroup(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
    }
}
