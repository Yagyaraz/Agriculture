using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class NabikaranController : ControllerBase
    {
        private readonly INabikaran _Nabikaran;

        public NabikaranController(INabikaran Nabikaran)
        {
            _Nabikaran = Nabikaran;
        }

        #region Nabikaran

        [HttpGet("GetAllNabikaran")]
        public async Task<IActionResult> GetAllNabikaran()
        {
            var data = await _Nabikaran.NabikaranList();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Nabikaran" : "Nabikaran Not Generated Try Again", Data = data });
        }
        [HttpGet("GetNabikaranById/{id}")]
        public async Task<IActionResult> GetNabikaranById(int id = 0)
        {
            var data = await _Nabikaran.GetNabikaranById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of Nabikaran" : "Nabikaran Not Fetched Try Again", Data = data });
        }
        [AllowAnonymous]
        [HttpPost("CreateNabikaran")]
        public async Task<IActionResult> CreateNabikaran(NabikaranViewModel model)
        {
            var data = await _Nabikaran.CreateNabikaran(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created Nabikaran" : "Nabikaran Not Created Try Again", Data = data });
        }
        #endregion
    }
}
