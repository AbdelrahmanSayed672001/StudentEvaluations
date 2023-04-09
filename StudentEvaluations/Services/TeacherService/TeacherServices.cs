
namespace StudentEvaluations.Services.TeacherService
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ApplicationDbContext dbContext;

        public TeacherServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Teacher> GetTeacherById(int id)
        {
            //var r = await dbContext.Teachers.Join(dbContext.Subjects, t => t.SubjectsId, s => s.Id,
            //    (t, s) => new TeacherDetailsViewModel
            //    {
            //        Id=t.Id,
            //        Name=t.Name,
            //        SubjectsId=t.SubjectsId,
            //        SubjectName=s.Name
            //    }).SingleOrDefaultAsync(t => t.Id == id);

            return /*r;*/ await dbContext.Teachers.SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Teacher> GetTeacherBySubjectId(int SubjectId)
        {
            return await dbContext.Teachers.SingleOrDefaultAsync(t => t.SubjectsId == SubjectId);
        }
        
        public async Task<Teacher> GetTeacherBySubjectIdIgnore(int id,int SubjectId)
        {
            return await dbContext.Teachers.Where(t=>t.Id!=id).SingleOrDefaultAsync(t => t.SubjectsId == SubjectId);
        }

        public async Task<Teacher> GetTeacherByName(string name)
        {
            //var r = await dbContext.Teachers.Join(dbContext.Subjects, t => t.SubjectsId, s => s.Id,
            //    (t, s) => new TeacherDetailsViewModel
            //    {
            //        Id = t.Id,
            //        Name = t.Name,
            //        SubjectsId = t.SubjectsId,
            //        SubjectName = s.Name
            //    }).SingleOrDefaultAsync(t => t.Name == name);
            return /*r;*/ await dbContext.Teachers.OrderBy(o => o.Name).FirstOrDefaultAsync(t=>t.Name.ToLower()==name.ToLower());
        }
        public async Task<IEnumerable<Teacher>> GetAll()
        {
            //var r = dbContext.Teachers.Join(dbContext.Subjects, t => t.SubjectsId, s => s.Id,
            //    (t, s) => new TeacherDetailsViewModel
            //    {
            //        Id = t.Id,
            //        Name = t.Name,
            //        SubjectsId = t.SubjectsId,
            //        SubjectName = s.Name
            //    });
            return /*r;*/ await dbContext.Teachers.OrderBy(o => o.Name).ToListAsync();
        }
        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            return teacher;
        }
        public Teacher UpdateTeacher(Teacher teacher)
        {
            dbContext.Teachers.Update(teacher);
            dbContext.SaveChanges();
            return teacher;
        }
        public void DeleteTeacher(Teacher teacher)
        {
            dbContext.Teachers.Remove(teacher);
            dbContext.SaveChanges();
        }


    }
}
