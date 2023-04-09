namespace StudentEvaluations.Services.FeedbackService
{
    public interface IFeedbackServices
    {
        Task<IEnumerable<Feedback>> GetAll();
        Task<IEnumerable<Feedback>> GetBySID(int sid);
        Task<IEnumerable<Feedback>> GetByTeacherName(string TName);

        Task<Feedback> Add(Feedback feedback);
    }
}
