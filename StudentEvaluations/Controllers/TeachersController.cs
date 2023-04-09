using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace StudentEvaluations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherServices teacherServices;
        private readonly ISubjectServices subjectServices;

        public TeachersController(ITeacherServices teacherServices,ISubjectServices subjectServices)
        {
            this.teacherServices = teacherServices;
            this.subjectServices = subjectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await teacherServices.GetAll();
            if(result.Count() == 0 )
                return BadRequest("There are no teachers");
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            
            var result = await teacherServices.GetTeacherById(id);
            if (result is null)
                return BadRequest($"There is no teacher with ID: {id}");
            return Ok(result);
        }

        [HttpGet("/api/[controller]/GetByNameAsync")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await teacherServices.GetTeacherByName(name);
            if (result == null)
                return BadRequest($"There is no teacher with Name: {name}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TeacherViewModel model)
        {
            var teacher = new Teacher
            {
                Name = model.Name,
                SubjectsId = model.SubjectsId
            };
            var result = await teacherServices.GetTeacherByName(teacher.Name);
            var isValidSubjectId = await subjectServices.GetSubjectById(teacher.SubjectsId);
            var SubjectIdIsExists = await teacherServices.GetTeacherBySubjectId(teacher.SubjectsId);
            if (result == null)
            {
                if (isValidSubjectId == null)
                    return BadRequest($"Invalid Subject_ID: {teacher.SubjectsId}");
                
                if (SubjectIdIsExists != null)
                    return BadRequest($"Subject_ID: {teacher.SubjectsId} is already assigned to another teacher");

                await teacherServices.AddTeacher(teacher);
                return Ok(teacher);
            }
            return BadRequest($"DR.{teacher.Name} is already exists");  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody]TeacherViewModel model)
        {
            var teacher =await teacherServices.GetTeacherById(id);
            if(teacher == null)
                return NotFound($"{id} is not found");

            teacher.Name = model.Name;
            teacher.SubjectsId = model.SubjectsId;

            var result = await teacherServices.GetTeacherByName(teacher.Name);
            if(result == null)
            {
                var subjectIdIsValid=await teacherServices.GetTeacherBySubjectIdIgnore(id,teacher.SubjectsId);
                if (subjectIdIsValid != null)
                    return BadRequest($"{teacher.SubjectsId} is assigned to another teacher");

                teacherServices.UpdateTeacher(teacher);
                return Ok(teacher);
            }
            return BadRequest($"DR.{teacher.Name} is already exists");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var teacher = await teacherServices.GetTeacherById(id);
            if (teacher == null)
                return NotFound($"{id} is not found");
            
            teacherServices.DeleteTeacher(teacher);
            return Ok($"DR.{teacher.Name} " +
                $"with ID: {teacher.Id} " +
                $"which teached: {teacher.SubjectsId} " +
                $"was deleted successfully ");
        }
    }
}
