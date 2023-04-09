

namespace StudentEvaluations.Services.SubjectService
{
    public class SubjectServices : ISubjectServices
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Subjects>> GetAllSubjects()
        {
            return await dbContext.Subjects.OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<Subjects> GetSubjectById(int id)
        {
            return await dbContext.Subjects.OrderBy(o => o.Name).SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subjects> GetSubjectByName(string name)
        {
            return await dbContext.Subjects.OrderBy(o => o.Name.ToLower()).SingleOrDefaultAsync(s => s.Name == name);
        }
        public async Task<Subjects> AddSubjects(Subjects Subject)
        {
            dbContext.Subjects.Add(Subject);
            await dbContext.SaveChangesAsync();
            return Subject;
        }
        public Subjects UpdateSubject(Subjects Subject)
        {
            dbContext.Update(Subject);
            dbContext.SaveChanges();
            return Subject;
        }
        public void DeleteSubject(Subjects Subject)
        {
            dbContext.Subjects.Remove(Subject);
            dbContext.SaveChanges();
        }

        public Task<bool> IsValidSubjectId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
