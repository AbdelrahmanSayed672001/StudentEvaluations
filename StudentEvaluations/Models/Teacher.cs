
namespace StudentEvaluations.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public int SubjectsId { get; set; }
        public Subjects Subjects { get; set; }
    }
}