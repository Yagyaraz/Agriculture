using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class AgriCalendarController : ControllerBase
    {
        private readonly IAgriCalendar _AgriCalendar;

        public AgriCalendarController(IAgriCalendar agriCalendar)
        {
            _AgriCalendar = agriCalendar;
        }
        #region AgriCalendarType

        [HttpGet("GetAllAgriCalendarType")]
        public async Task<IActionResult> GetAllAgriCalendarType()
        {
            var data = await _AgriCalendar.GetAllAgriCalendarType();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendarType" : "AgriCalendarType Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarTypeById/{id}")]
        public async Task<IActionResult> GetAgriCalendarTypeById(int id = 0)
        {
            var data = await _AgriCalendar.GetAgriCalendarTypeById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of AgriCalendarType" : "AgriCalendarType Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAgriCalendarType")]
        public async Task<IActionResult> CreateAgriCalendarType(AgriCalendarTypeViewModel model)
        {
            var data = await _AgriCalendar.InsertUpdateAgriCalendarType(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created AgriCalendarType" : "AgriCalendarType Not Created Try Again", Data = data });
        } 
        #endregion
        #region AgriCalendarCategory

        [HttpGet("GetAllAgriCalendarCategory")]
        public async Task<IActionResult> GetAllAgriCalendarCategory()
        {
            var data = await _AgriCalendar.GetAllAgriCalendarCategory();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendarCategory" : "AgriCalendarCategory Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarCategoryById/{id}")]
        public async Task<IActionResult> GetAgriCalendarCategoryById(int id = 0)
        {
            var data = await _AgriCalendar.GetAgriCalendarCategoryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of AgriCalendarCategory" : "AgriCalendarCategory Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAgriCalendarCategory")]
        public async Task<IActionResult> CreateAgriCalendarCategory(AgriCalendarCategoryViewModel model)
        {
            var data = await _AgriCalendar.InsertUpdateAgriCalendarCategory(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created AgriCalendarCategory" : "AgriCalendarCategory Not Created Try Again", Data = data });
        } 
        #endregion
        #region AgriCalendarProduct

        [HttpGet("GetAllAgriCalendarProduct")]
        public async Task<IActionResult> GetAllAgriCalendarProduct()
        {
            var data = await _AgriCalendar.GetAllAgriCalendarProduct();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendarProduct" : "AgriCalendarProduct Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarProductById/{id}")]
        public async Task<IActionResult> GetAgriCalendarProductById(int id = 0)
        {
            var data = await _AgriCalendar.GetAgriCalendarProductById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of AgriCalendarProduct" : "AgriCalendarProduct Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAgriCalendarProduct")]
        public async Task<IActionResult> CreateAgriCalendarProduct(AgriCalendarProductViewModel model)
        {
            var data = await _AgriCalendar.InsertUpdateAgriCalendarProduct(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created AgriCalendarProduct" : "AgriCalendarProduct Not Created Try Again", Data = data });
        } 
        #endregion
        #region AgriCalendar

        [HttpGet("GetAllAgriCalendar")]
        public async Task<IActionResult> GetAllAgriCalendar()
        {
            var data = await _AgriCalendar.GetAllAgriCalendar();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendar" : "AgriCalendar Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarById/{id}")]
        public async Task<IActionResult> GetAgriCalendarById(int id = 0)
        {
            var data = await _AgriCalendar.GetAgriCalendarById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of AgriCalendar" : "AgriCalendar Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAgriCalendar")]
        public async Task<IActionResult> CreateAgriCalendar(AgriCalendarViewModel model)
        {
            var data = await _AgriCalendar.InsertUpdateAgriCalendar(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created AgriCalendar" : "AgriCalendar Not Created Try Again", Data = data });
        } 
        #endregion
    }
}
