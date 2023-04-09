using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentEvaluations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectServices subjectServices;

        public SubjectsController(ISubjectServices subjectServices)
        {
            this.subjectServices = subjectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var subject = await subjectServices.GetAllSubjects();
            if (subject.Count() == 0)
                return NotFound("There are no subjects now");

            return Ok(subject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var subject = await subjectServices.GetSubjectById(id);
            if (subject == null)
                return NotFound($"There is no subject with ID: {id}");
            return Ok(subject);
        }
        [HttpGet("/api/[controller]/GetByNameAsync")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var subject = await subjectServices.GetSubjectByName(name);
            if (subject == null)
                return NotFound($"There is no subject with name: {name}");
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SubjectViewModel model)
        {
            var subject = new Subjects
            {
                Name = model.Name,
            };

            var result = await subjectServices.GetSubjectByName(subject.Name.ToLower());
            if (result == null)
            {
                await subjectServices.AddSubjects(subject);
                return Ok(subject);
            }
            return BadRequest($"{subject.Name} is already exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SubjectViewModel model)
        {
            var subject = await subjectServices.GetSubjectById(id);
            if (subject == null)
                return NotFound($"there are no subject with ID:{id}");

            subject.Name = model.Name;

            var result = await subjectServices.GetSubjectByName(subject.Name.ToLower());
            if (result != null)
                return BadRequest($"{subject.Name} is already exists");
            
            subjectServices.UpdateSubject(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var subject = await subjectServices.GetSubjectById(id);
            if (subject == null)
                return NotFound($"there are no subject with ID:{id}");

            subjectServices.DeleteSubject(subject);
            return Ok($"Subject: {subject.Name} with ID: {id} is deleted successfully");
        }
    }
}
