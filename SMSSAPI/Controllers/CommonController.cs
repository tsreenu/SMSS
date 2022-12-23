using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSSAPI.Models.Interface;

namespace SMSSAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private ICommonService commonService;
        public CommonController(ICommonService commonService)
        {
            this.commonService = commonService;
        }
        [HttpGet]
        public async Task<ActionResult> GetStates()
        {
            try
            {
                return Ok(await commonService.GetStates());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
    }
}
