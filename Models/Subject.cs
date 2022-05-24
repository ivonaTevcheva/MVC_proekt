using System.ComponentModel.DataAnnotations;

namespace MVC_proekt.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int Semester { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string? Programme { get; set; }

        [StringLength(25, MinimumLength = 3)]
        public string? EducationLevel { get; set; }
        public int? FirstProfessorId { get; set; }
        public Professor? FirstProfessor { get; set; }
        public int? SecondProfessorId { get; set; }
        public Professor? SecondProfessor { get; set; }
        public ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
