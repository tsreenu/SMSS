using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassDetailsService classRepository;
        public ClassController(IClassDetailsService classDetailsService)
        {
                this.classRepository = classDetailsService;
        }
        [HttpGet]
        public async Task<ActionResult> GetClass()
        {
            try
            {
                return Ok(await classRepository.GetClassDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetClass(int Id)
        {
            try
            {
                return Ok(await classRepository.GetClassDetails(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClassDetails>> AddClass(ClassDetails Class)
        {
            try
            {
                if (Class == null)
                {
                    return BadRequest();
                }
                var createdClass = await classRepository.AddClass(Class);
                return CreatedAtAction(nameof(GetClass), new { id = createdClass.Id }, createdClass);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            try
            {
                var emp = classRepository.GetClassDetails(id);
                if (emp == null)
                {
                    return NotFound($"Employye Id = {id} not found");
                }
                await classRepository.DeleteClass(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ClassDetails>> UpdateClass(ClassDetails classDetails)
        {
            try
            {
                var Class = await classRepository.GetClassDetails(classDetails.Id);
                if (Class == null)
                {
                    return NotFound($"Class Id = {classDetails.Id} not found");
                }
                var res = await classRepository.UpdateClass(classDetails);
                return res;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
    }
}
