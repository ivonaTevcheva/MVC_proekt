using System.ComponentModel.DataAnnotations;

namespace MVC_proekt.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string? Degree { get; set; }
        [StringLength(25, MinimumLength = 3)]

        public string? AcademicRank { get; set; }
        [StringLength(10, MinimumLength = 3)]
        public string? OfficeNumber { get; set; }
        [DataType(DataType.Date)]

        public DateTime? HireDate { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
