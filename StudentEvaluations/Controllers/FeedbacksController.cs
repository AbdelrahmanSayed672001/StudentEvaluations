using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentEvaluations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackServices feedbackServices;
        private readonly IStudentServices studentServices;
        private readonly ITeacherServices teacherServices;

        public FeedbacksController(IFeedbackServices feedbackServices
            ,IStudentServices studentServices,ITeacherServices teacherServices)
        {
            this.feedbackServices = feedbackServices;
            this.studentServices = studentServices;
            this.teacherServices = teacherServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await feedbackServices.GetAll();

            if(result.Count() == 0)
                return NotFound("Not found any feedbacks yet");
            return Ok(result);
        }

        [HttpGet("/api/[controller]/GetBySIDAsync")]
        public async Task<IActionResult> GetBySIDAsync(int sid)
        {
            if (sid == 0)
                return BadRequest($"There is no student with ID: {sid}");

            var result = await feedbackServices.GetBySID(sid);

            if (result.Count() == 0)
                return NotFound($"Student_ID: {sid} does not exists in feedback table");
            return Ok(result);
        }
        
        [HttpGet("/api/[controller]/GetByTeacherNameAsync")]
        public async Task<IActionResult> GetByTeacherNameAsync(string TName)
        {
            
            var result = await feedbackServices.GetByTeacherName(TName);

            if (result.Count() == 0)
                return NotFound($"DR.{TName} does not exists in feedback table");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]FeedbackViewModel model)
        {
            var feedback = new Feedback
            {
                SID=model.SID,
                TeacherName=model.TeacherName,
                message=model.message
            };
            var StudentID = await studentServices.GetStudentBySId(feedback.SID);
            if (StudentID == null)
                return NotFound($"{feedback.SID} is not a correct Student_ID");

            var TName=await teacherServices.GetTeacherByName(feedback.TeacherName);
            if (TName == null)
                return NotFound($"{feedback.TeacherName} is not a correct teacher name");

            await feedbackServices.Add(feedback);
            return Ok(feedback);
        }
    }
}
