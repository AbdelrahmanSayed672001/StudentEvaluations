namespace StudentEvaluations.Services.FeedbackService
{
    public class FeedbackService : IFeedbackServices
    {
        private readonly ApplicationDbContext dbContext;

        public FeedbackService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Feedback>> GetAll()
        {
            return await dbContext.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetBySID(int sid)
        {
            return await dbContext.Feedbacks.Where(f => f.SID == sid).ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByTeacherName(string teacherName)
        {
            return await dbContext.Feedbacks.Where(f => f.TeacherName.ToLower() == teacherName.ToLower() ).ToListAsync();

        }
        public async Task<Feedback> Add(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
            await dbContext.SaveChangesAsync();
            return feedback;
        }


    }
}
