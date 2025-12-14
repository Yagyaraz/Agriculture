using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GunasoController : ControllerBase
    {
        private readonly IGunaso _gunaso;

        public GunasoController(IGunaso gunaso)
        {
            _gunaso = gunaso;
        }

        #region Gunaos

        [HttpGet("GetAllGunaso")]
        public async Task<IActionResult> GetAllGunaos()
        {
            var data = await _gunaso.GunasoList();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Gunaos" : "Gunaos Not Generated Try Again", Data = data });
        }
        [HttpGet("GetGunaosById/{id}")]
        public async Task<IActionResult> GetGunaosById(int id = 0)
        {
            var data = await _gunaso.GetGunasoById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of Gunaos" : "Gunaos Not Fetched Try Again", Data = data });
        }
        [AllowAnonymous]
        [HttpPost("CreateGunaos")]
        public async Task<IActionResult> CreateGunaso(GunasoViewModel model)
        {
            var data = await _gunaso.CreateGunaso(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created Gunaos" : "Gunaos Not Created Try Again", Data = data });
        }
        #endregion
    }
}
