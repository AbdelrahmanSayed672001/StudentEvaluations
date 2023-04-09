namespace StudentEvaluations.ViewModels
{
    public class StudentViewModel
    {

        [StringLength(100)]
        public string Name { get; set; }
        public int StudentID { get; set; }
        public int SubjectsId { get; set; }
    }
}
