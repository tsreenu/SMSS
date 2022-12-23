using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffDetailsService staffRepository;
        public StaffController(IStaffDetailsService staffDetailsService)
        {
           this.staffRepository = staffDetailsService;
        }
        [HttpGet]
        public async Task<ActionResult> GetStaffs()
        {
            try
            {
                return Ok(await staffRepository.GetStaffDetails());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }        
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetStaff(int Id)
        {
            try
            {
                return Ok(await staffRepository.GetStaffDetails(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StaffDetails>> AddStaff(StaffDetails staff)
        {
            try
            {
                if (staff == null)
                {
                    return BadRequest();
                }
                var createdStaff = await staffRepository.AddStaff(staff);
                return CreatedAtAction(nameof(GetStaff), new { id = createdStaff.Id }, createdStaff);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            try
            {
                var emp = staffRepository.GetStaffDetails(id);
                if (emp == null)
                {
                    return NotFound($"Employye Id = {id} not found");
                }
                await staffRepository.DeleteStaff(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<StaffDetails>> UpdateEmployee(StaffDetails staffDetails)
        {
            try
            {
                var emp = await staffRepository.GetStaffDetails(staffDetails.Id);
                if (emp == null)
                {
                    return NotFound($"Staff Id = {staffDetails.Id} not found");
                }
                var res = await staffRepository.UpdateStaff(staffDetails);
                return res;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
    }
}
