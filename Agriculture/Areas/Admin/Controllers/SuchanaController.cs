using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{

    [Route("api/Admin/[controller]")]
    [ApiController]
    public class SuchanaController : ControllerBase
    {
        private readonly ISuchana _suchana;

        public SuchanaController(ISuchana suchana)
        {
            _suchana = suchana;
        }
        [HttpGet("GetAllSuchana")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSuchana()
        {
            var data = await _suchana.GetAllSuchana();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetSuchanaById/{id}")]
        public async Task<IActionResult> GetSuchanaById(int id = 0)
        {
            var data = await _suchana.GetSuchanaById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateSuchana")]
        public async Task<IActionResult> CreateSuchana([FromForm] SuchanaViewModel model)
        {
            var data = await _suchana.InsertUpdateSuchana(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
    }
}
