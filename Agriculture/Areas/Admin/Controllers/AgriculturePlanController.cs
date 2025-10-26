using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class AgriculturePlanController : ControllerBase
    {
        private readonly IAgriculturePlan _AgriculturePlan;

        public AgriculturePlanController(IAgriculturePlan agriculturePlan)
        {
            _AgriculturePlan = agriculturePlan;
        }
        #region Program
        [HttpGet("GetAllProgram")]
        public async Task<IActionResult> GetAllProgram()
        {
            var data = await _AgriculturePlan.GetAllProgram();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetProgramById/{id}")]
        public async Task<IActionResult> GetProgramById(int id = 0)
        {
            var data = await _AgriculturePlan.GetProgramById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateProgram")]
        public async Task<IActionResult> CreateProgram(AgricultureProgramViewModel model)
        {
            var data = await _AgriculturePlan.InsertUpdateProgram(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region AgricultureProject

        [HttpGet("GetAllProject")]
        public async Task<IActionResult> GetAllProject()
        {
            var data = await _AgriculturePlan.GetAllProject();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetProjectById/{id}")]
        public async Task<IActionResult> GetProjectById(int id = 0)
        {
            var data = await _AgriculturePlan.GetProjectById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(AgricultureProjectViewModel model)
        {
            var data = await _AgriculturePlan.InsertUpdateProject(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region AgricultureService

        [HttpGet("GetAllService")]
        public async Task<IActionResult> GetAllService()
        {
            var data = await _AgriculturePlan.GetAllService();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetServiceById/{id}")]
        public async Task<IActionResult> GetServiceById(int id = 0)
        {
            var data = await _AgriculturePlan.GetServiceById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(AgricultureServiceViewModel model)
        {
            var data = await _AgriculturePlan.InsertUpdateService(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region AgricultureApplicatoionForm

        [HttpGet("GetAllApplicatoionForm")]
        public async Task<IActionResult> GetAllApplicatoionForm()
        {
            var data = await _AgriculturePlan.GetAllApplicatoionForm();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetApplicatoionFormById/{id}")]
        public async Task<IActionResult> GetApplicatoionFormById(int id = 0)
        {
            var data = await _AgriculturePlan.GetApplicatoionFormById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateApplicatoionForm")]
        public async Task<IActionResult> CreateApplicatoionForm([FromForm]AgricultureApplicatoionFormViewModel model)
        {
            var data = await _AgriculturePlan.InsertUpdateApplicatoionForm(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
    }
}
