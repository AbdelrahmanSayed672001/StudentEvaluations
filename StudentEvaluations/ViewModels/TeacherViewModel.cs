namespace StudentEvaluations.ViewModels
{
    public class TeacherViewModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        public int SubjectsId { get; set; }
    }
}
