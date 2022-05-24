using System.ComponentModel.DataAnnotations;

namespace MVC_proekt.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Subject? Course { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [StringLength(10, MinimumLength = 3)]
        public string? Semester { get; set; }
        public int? Year { get; set; }
        public int? Grade { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string? SeminaIUrl { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string? ProjectUrl { get; set; }
        public int? ExamPoints { get; set; }
        public int? SeminalPoints { get; set; }
        public int? AdditionalPoints { get; set; }

        [DataType(DataType.Date)]

        public DateTime? FinishDate { get; set; }
    }
}
