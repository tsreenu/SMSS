using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDetails>>> GetSubjectDetails()
        {
            try
            {
                return Ok(await subjectService.GetSubjectDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDetails>> GetSubjectDetails(int id)
        {
            try
            {
                var subjectDetails = await subjectService.GetSubjectDetails(id);
                if (subjectDetails == null)
                {
                    return NotFound();
                }
                return Ok(subjectDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

 
        [HttpPut]
        public async Task<ActionResult<SubjectDetails>> UpdateSubject(SubjectDetails subjectDetails)
        {
            try
            {
                var emp = await subjectService.GetSubjectDetails(subjectDetails.SubjectId);
                if (emp == null)
                {
                    return NotFound($"Subject Id = {subjectDetails.SubjectId} not found");
                }
                var res = await subjectService.UpdateSubject(subjectDetails);
                return res;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }



        [HttpPost]
        public async Task<ActionResult<SubjectDetails>> AddSubject(SubjectDetails subjectDetails)
        {
            try
            {
                if (subjectDetails == null)
                {
                    return BadRequest();
                }
                var createdSubject = await subjectService.AddSubject(subjectDetails);
                return CreatedAtAction(nameof(GetSubjectDetails), new { id = createdSubject.SubjectId }, createdSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
            return Ok();
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                var emp = subjectService.GetSubjectDetails(id);
                if (emp == null)
                {
                    return NotFound($"Subject Id = {id} not found");
                }
                await subjectService.DeleteSubject(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
    }
}
