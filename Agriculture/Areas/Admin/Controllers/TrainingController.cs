using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITraining _Training;

        public TrainingController(ITraining training)
        {
            _Training = training;
        }

        [HttpGet("GetAllTraining")]
        public async Task<IActionResult> GetAllTraining()
        {
            var data = await _Training.GetAllTraining();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetTrainingById/{id}")]
        public async Task<IActionResult> GetTrainingById(int id = 0)
        {
            var data = await _Training.GetTrainingById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateTraining")]
        public async Task<IActionResult> CreateTraining([FromForm] TrainingViewModel model)
        {
            var data = await _Training.InsertUpdateTraining(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
    }
}
