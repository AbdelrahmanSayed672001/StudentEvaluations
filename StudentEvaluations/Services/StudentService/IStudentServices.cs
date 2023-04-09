namespace StudentEvaluations.Services.StudentService
{
    public interface IStudentServices
    {
        Task<Student> GetStudentBySId(int Sid);
        Task<Student> GetStudentByName(string name);
        Task<Student> GetStudentById(int id);
        
        Task<Student> AddStudent(Student student);
        Student UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
