using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibrary _Library;
        public LibraryController(ILibrary library) 
        {
            _Library = library;
        }
        [HttpGet("GetAllLibrary")]
        public async Task<IActionResult> GetAllLibrary()
        {
            var data = await _Library.GetAllLibrary();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetLibraryById/{id}")]
        public async Task<IActionResult> GetLibraryById(int id = 0)
        {
            var data = await _Library.GetLibraryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpGet("GetLibraryDetailById/{id}")]
        public async Task<IActionResult> GetLibraryDetailById(int id = 0)
        {
            var data = await _Library.GetLibraryDetailById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateLibrary")]
        public async Task<IActionResult> CreateLibrary([FromForm]LibraryViewModel model)
        {
            var data = await _Library.InsertUpdateLibrary(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
    }
}
