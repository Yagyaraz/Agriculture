using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class SubsidyController : ControllerBase
    {
        private readonly ISubsidy _Subsidy;

        public SubsidyController(ISubsidy subsidy)
        {
            _Subsidy = subsidy;
        }
        #region Category
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = await _Subsidy.GetAllCategory();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id = 0)
        {
            var data = await _Subsidy.GetCategoryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryViewModel model)
        {
            var data = await _Subsidy.InsertUpdateCategory(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region SubCategory
        [HttpGet("GetAllSubCategory")]
        public async Task<IActionResult> GetAllSubCategory()
        {
            var data = await _Subsidy.GetAllSubCategory();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetSubCategoryById/{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id = 0)
        {
            var data = await _Subsidy.GetSubCategoryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateSubCategory")]
        public async Task<IActionResult> CreateSubCategory(SubCategoryViewModel model)
        {
            var data = await _Subsidy.InsertUpdateSubCategory(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region Subsidy
        [HttpGet("GetAllSubsidyForUser")]
        public async Task<IActionResult> GetAllSubsidyForUser()
        {
            var data = await _Subsidy.GetAllSubsidyForUser();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetAllSubsidy")]
        public async Task<IActionResult> GetAllSubsidy()
        {
            var data = await _Subsidy.GetAllSubsidy();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetSubsidyById/{id}")]
        public async Task<IActionResult> GetSubsidyById(int id = 0)
        {
            var data = await _Subsidy.GetSubsidyById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateSubsidy")]
        public async Task<IActionResult> CreateSubsidy(SubsidyViewModel model)
        {
            var data = await _Subsidy.InsertUpdateSubsidy(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }

        [HttpGet("GetSubsidyByIdForPopUp/{id}")]
        public async Task<IActionResult> GetSubsidyByIdForPopUp(int id = 0)
        {
            var data = await _Subsidy.GetSubsidyByIdForPopUp(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CareateSaveRequestedSubsidy")]
        public async Task<IActionResult> CareateSaveRequestedSubsidy([FromBody] List<SaveRequestedSubsidyViewModel> model)
        {
            var data = await _Subsidy.SaveRequestedSubsidy(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }

        #endregion
        #region OtherSubsidy
        [HttpGet("GetAllOtherSubsidy")]
        public async Task<IActionResult> GetAllOtherSubsidy()
        {
            var data = await _Subsidy.GetAllOtherSubsidy();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetOtherSubsidyById/{id}")]
        public async Task<IActionResult> GetOtherSubsidyById(int id = 0)
        {
            var data = await _Subsidy.GetOtherSubsidyById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateOtherSubsidy")]
        public async Task<IActionResult> CreateOtherSubsidy(OtherSubsidyViewModel model)
        {
            var data = await _Subsidy.InsertUpdateOtherSubsidy(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
    }
}
