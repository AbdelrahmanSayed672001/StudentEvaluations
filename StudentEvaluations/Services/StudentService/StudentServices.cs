namespace StudentEvaluations.Services.StudentService
{
    public class StudentServices : IStudentServices
    {
        private readonly ApplicationDbContext dbContext;

        public StudentServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Student> GetStudentByName(string name)
        {
            return await dbContext.Students.OrderBy(o=>o.Name).FirstOrDefaultAsync(s=>s.Name==name); 
        }

        public async Task<Student> GetStudentBySId(int Sid)
        {
            return await dbContext.Students.FirstOrDefaultAsync(s => s.StudentID== Sid);
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await dbContext.Students.FindAsync(id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }
        public Student UpdateStudent(Student student)
        {
            dbContext.Students.Update(student);
            dbContext.SaveChangesAsync();
            return student;
        }
        public void DeleteStudent(Student student)
        {
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }

        
    }
}
