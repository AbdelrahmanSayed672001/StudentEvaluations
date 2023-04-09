using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentEvaluations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices studentServices;

        public StudentsController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        [HttpGet("/api/[controller]/GetStudentBySIDAsync")]
        public async Task<IActionResult> GetStudentBySIDAsync(int sid)
        {
            var student = await studentServices.GetStudentBySId(sid);
            if (student == null)
            {
                return NotFound($"{sid} is not found");
            }

            return Ok(student);
        }

        [HttpGet("/api/[controller]/GetStudentByNameAsync")]
        public async Task<IActionResult> GetStudentByNameAsync(string name)
        {
            
            var student = await studentServices.GetStudentByName(name);
            if (student == null)
            {
                return NotFound($"Student with name: {name} is not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync([FromBody] StudentViewModel model)
        {
            var student = new Student
            {
                Name = model.Name,
                StudentID = model.StudentID,
                SubjectsId = model.SubjectsId
            };
            var result= await studentServices.GetStudentBySId(student.StudentID);

            if (result == null)
            {
                await studentServices.AddStudent(student);
                return Ok(student);
            }

            return BadRequest($"{student.StudentID} is already exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id,[FromBody] StudentViewModel model)
        {
            var student=await studentServices.GetStudentById(id);
            if (student == null)
                return NotFound($"{id} is not found");
            
            student.StudentID = model.StudentID;
            student.Name = model.Name;
            student.SubjectsId = model.SubjectsId;

            var result = await studentServices.GetStudentBySId(student.StudentID);
            if(result is not null)
                return NotFound($"{student.StudentID} is already exists");

            studentServices.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{sid}")]
        public async Task<IActionResult> DeleteStudentAsync(int sid)
        {
            var student=await studentServices.GetStudentBySId(sid);
            if (student == null)
                return NotFound($"Student with SID:{sid} is not found");
            studentServices.DeleteStudent(student);
            return Ok($"Student:{student.Name} with SID:{sid} is deleted successfully ");
        }
    }
}
