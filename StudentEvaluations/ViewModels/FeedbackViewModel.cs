﻿namespace StudentEvaluations.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string message { get; set; }
        public int SID { get; set; }

        [StringLength(100)]
        public string TeacherName { get; set; }
    }
}
