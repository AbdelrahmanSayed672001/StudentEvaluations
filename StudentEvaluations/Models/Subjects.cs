namespace StudentEvaluations.Models
{
    public class Subjects
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        
        public virtual List<Student> Students  { get; set; }
        public virtual Teacher Teacher{ get; set; }

    }
}
