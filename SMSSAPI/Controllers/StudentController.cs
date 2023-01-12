using Microsoft.AspNetCore.Mvc;
using SMSSAPI.Models.Interface;
using SMSSModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMSSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentDetailsService studentRepository;

        public StudentController(IStudentDetailsService studentService)
        {
            this.studentRepository = studentService;
        }
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await studentRepository.GetStudentDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetStudent(int Id)
        {
            try
            {
                return Ok(await studentRepository.GetStudentDetails(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDetails>> AddStudent(StudentDetails student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                var createdStudent = await studentRepository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var emp = studentRepository.GetStudentDetails(id);
                if (emp == null)
                {
                    return NotFound($"Employye Id = {id} not found");
                }
                await studentRepository.DeleteStudent(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<StudentDetails>> UpdateStudent(StudentDetails studentDetails)
        {
            try
            {
                var emp = await studentRepository.GetStudentDetails(studentDetails.Id);
                if (emp == null)
                {
                    return NotFound($"Student Id = {studentDetails.Id} not found");
                }
                var res = await studentRepository.UpdateStudent(studentDetails);
                return res;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
    }
}
