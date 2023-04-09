namespace TeacherEvaluations.Services.TeacherService
{
    public interface ITeacherServices
    {
        Task<Teacher> GetTeacherByName(string name);
        Task<IEnumerable<Teacher>> GetAll();
        Task<Teacher> GetTeacherById(int id);
        Task<Teacher> GetTeacherBySubjectId(int SubjectId);
        Task<Teacher> GetTeacherBySubjectIdIgnore(int id, int SubjectId);
        Task<Teacher> AddTeacher(Teacher teacher);
        Teacher UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
    }
}
