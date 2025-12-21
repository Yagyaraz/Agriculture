using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [AllowAnonymous]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationForm _ApplicationForm;

        public ApplicationFormController(IApplicationForm ApplicationForm)
        {
            _ApplicationForm = ApplicationForm;
        }

        [HttpGet("GetAllApplicationForm")]
        public async Task<IActionResult> GetAllApplicationForm()
        {
            var data = await _ApplicationForm.GetAllApplicationForm();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetApplicationFormById/{id}")]
        public async Task<IActionResult> GetApplicationFormById(int id = 0)
        {
            var data = await _ApplicationForm.GetApplicationFormById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateApplicationForm")]
        public async Task<IActionResult> CreateApplicationForm([FromForm] ApplicationFormViewModel model)
        {
            var data = await _ApplicationForm.InsertUpdateApplicationForm(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
    }
}
