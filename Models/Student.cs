using System.ComponentModel.DataAnnotations;

namespace MVC_proekt.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Index { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
        public int? AcquiredCredits { get; set; }
        public int? CurrentSemester { get; set; }
        public string? EducationLevel { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        [StringLength(25, MinimumLength = 3)]
        public ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
