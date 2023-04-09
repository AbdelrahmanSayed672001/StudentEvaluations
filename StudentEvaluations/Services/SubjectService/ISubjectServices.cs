namespace StudentEvaluations.Services.SubjectService
{
    public interface ISubjectServices
    {
        Task<IEnumerable<Subjects>> GetAllSubjects();
        Task<Subjects> GetSubjectById(int id);
        Task<Subjects> GetSubjectByName(string name);

        Task<Subjects> AddSubjects(Subjects Subject);
        Subjects UpdateSubject(Subjects Subject);
        void DeleteSubject(Subjects Subject);
        Task<bool> IsValidSubjectId(int id);
    }
}