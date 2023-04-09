
namespace StudentEvaluations.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public virtual DbSet<Student> Students{ get; set; }
        public virtual DbSet<Teacher> Teachers{ get; set; }
        public virtual DbSet<Subjects> Subjects{ get; set; }
        public virtual DbSet<Feedback> Feedbacks{ get; set; }

    }
}
