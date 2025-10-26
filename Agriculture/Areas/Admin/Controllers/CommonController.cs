using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommon _Common;

        public CommonController(ICommon common)
        {
            _Common = common;
        }

        #region FiscalYear
        [HttpGet("GetAllFiscalYear")]
        public async Task<IActionResult> GetAllFiscalYear()
        {
            var data = await _Common.GetAllFiscalYear();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });
        }
        [HttpGet("GetFiscalYearById/{id}")]
        public async Task<IActionResult> GetFiscalYearById(int id = 0)
        {
            var data = await _Common.GetFiscalYearById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFiscalYear")]
        public async Task<IActionResult> CreateFiscalYear(FiscalYearViewModel model)
        {
            var data = await _Common.InsertUpdateFiscalYear(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion

        #region Office
        [HttpGet("GetAllOffice")]
        public async Task<IActionResult> GetAllOffice()
        {
            var data = await _Common.GetAllOffice();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of office" : "Office Not Generated Try Again", Data = data });
        }
        [HttpGet("GetOfficeById/{id}")]
        public async Task<IActionResult> GetOfficeById(int id = 0)
        {
            var data = await _Common.GetOfficeById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of office" : "Office Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateOffice")]
        public async Task<IActionResult> CreateOffice(OfficeViewModel model)
        {
            var data = await _Common.InsertUpdateOffice(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created office" : "Office Not Created Try Again", Data = data });
        }
        #endregion
        #region EducationLevel
        [HttpGet("GetAllEducationLevel")]
        public async Task<IActionResult> GetAllEducationLevel()
        {
            var data = await _Common.GetAllEducationLevel();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of EducationLevel" : "EducationLevel Not Generated Try Again", Data = data });
        }
        [HttpGet("GetEducationLevelById/{id}")]
        public async Task<IActionResult> GetEducationLevelById(int id = 0)
        {
            var data = await _Common.GetEducationLevelById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of EducationLevel" : "EducationLevel Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateEducationLevel")]
        public async Task<IActionResult> CreateEducationLevel(CommonViewModel model)
        {
            var data = await _Common.InsertUpdateEducationLevel(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created EducationLevel" : "EducationLevel Not Created Try Again", Data = data });
        }
        #endregion
        #region FarmerGroup
        [HttpGet("GetAllFarmerGroup")]
        public async Task<IActionResult> GetAllFarmerGroup()
        {
            var data = await _Common.GetAllFarmerGroup();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of FarmerGroup" : "FarmerGroup Not Generated Try Again", Data = data });
        }
        [HttpGet("GetFarmerGroupById/{id}")]
        public async Task<IActionResult> GetFarmerGroupById(int id = 0)
        {
            var data = await _Common.GetFarmerGroupById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of FarmerGroup" : "FarmerGroup Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFarmerGroup")]
        public async Task<IActionResult> CreateFarmerGroup(CommonViewModel model)
        {
            var data = await _Common.InsertUpdateFarmerGroup(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created FarmerGroup" : "FarmerGroup Not Created Try Again", Data = data });
        }
        #endregion
        #region FarmerCategory
        [HttpGet("GetAllFarmerCategory")]
        public async Task<IActionResult> GetAllFarmerCategory()
        {
            var data = await _Common.GetAllFarmerCategory();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of FarmerCategory" : "FarmerCategory Not Generated Try Again", Data = data });
        }
        [HttpGet("GetFarmerCategoryById/{id}")]
        public async Task<IActionResult> GetFarmerCategoryById(int id = 0)
        {
            var data = await _Common.GetFarmerCategoryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of FarmerCategory" : "FarmerCategory Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateFarmerCategory")]
        public async Task<IActionResult> CreateFarmerCategory(CommonViewModel model)
        {
            var data = await _Common.InsertUpdateFarmerCategory(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created FarmerCategory" : "FarmerCategory Not Created Try Again", Data = data });
        }
        #endregion
        #region AnimalSetup
        [HttpGet("GetAllAnimalSetup")]
        public async Task<IActionResult> GetAllAnimalSetup()
        {
            var data = await _Common.GetAllAnimalSetup();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AnimalSetup" : "AnimalSetup Not Generated Try Again", Data = data });
        }
       
        [HttpPost("GetAnimalSetupById")]
        public async Task<IActionResult> GetAnimalSetupById(BooleianViewModel model)
        {
            var data = await _Common.GetAnimalSetupById(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Fetched data According to Id of AnimalSetup" : "AnimalSetup Not Fetched Try Again", Data = data });
        }
        //this is to generate the list of animal Husbandry which are active through setup

        [HttpGet("GetAllActiveAgriculture")]
        public async Task<IActionResult> GetAllActiveAgriculture()
        {
            var data = await _Common.GetAllActiveAgriculture();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Active AnimalSetup" : "AnimalSetup Active list Not Generated Try Again", Data = data });
        }
        #endregion
        #region UserControl

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            var data = await _Common.RegisterUser(model);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "User registered Successfully" : "User Not registered Try Again", Data = data });
        }



        [HttpGet("GetAllUserList")]
        public async Task<IActionResult> GetAllUserList()
        {
            var data = await _Common.GetAllUserList();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of UserList" : "UserList Not Generated Try Again", Data = data });
        }
        #endregion

        #region WardSetup
        [HttpGet("GetAllWardSetup")]
        public async Task<IActionResult> GetAllWardSetup()
        {
            var data = await _Common.GetAllWardSetup();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Ward" : "WardSetup Not Generated Try Again", Data = data });
        }
        [HttpGet("GetWardSetupById/{id}")]
        public async Task<IActionResult> GetWardSetupById(int id = 0)
        {
            var data = await _Common.GetWardSetupById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id of Ward" : "WardSetup Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateWardSetup")]
        public async Task<IActionResult> CreateWardSetup(CommonViewModel model)
        {
            var data = await _Common.InsertUpdateWardSetup(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created Ward" : "WardSetup Not Created Try Again", Data = data });
        }
        #endregion
    }
}
