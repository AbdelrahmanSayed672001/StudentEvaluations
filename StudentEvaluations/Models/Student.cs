
namespace StudentEvaluations.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name{ get; set; }
        public int StudentID{ get; set; }
        public int SubjectsId { get; set; }
        public virtual List<Subjects> Subjects{ get; set; }
    }
}
