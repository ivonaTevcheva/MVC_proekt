using Microsoft.EntityFrameworkCore;
using MVC_proekt.Data;

namespace MVC_proekt.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVC_proektContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<MVC_proektContext>>()))
            {
                // Look for any movies.
                if (context.Student.Any() || context.Professor.Any() || context.Subject.Any() || context.StudentSubject.Any())
                {
                    return; // DB has been seeded
                }
                context.Student.AddRange(
                new Student { /*Id = 1, */FirstName = "Ana", LastName = "Lazarova", Index = "14", EnrollmentDate = DateTime.Parse("09-09-2019"), AcquiredCredits = 150, CurrentSemester = 6, EducationLevel = "Student" },
                new Student { /*Id = 2, */FirstName = "Matej", LastName = "Ivanov", Index = "29", EnrollmentDate = DateTime.Parse("08-09-2020"), AcquiredCredits = 60, CurrentSemester = 4, EducationLevel = "Student" },
                new Student { /*Id = 3, */FirstName = "Petar", LastName = "Trajkov", Index = "54", EnrollmentDate = DateTime.Parse("08-09-2021"), AcquiredCredits = 30, CurrentSemester = 2, EducationLevel = "Student" }
                );
                context.SaveChanges();
                context.Professor.AddRange(
                new Professor { /*Id = 1, */FirstName = "Darko", LastName = "Petrovski", Degree = "PHD", AcademicRank = "Professor", OfficeNumber="092", HireDate= DateTime.Parse("09-09-2010") },
                new Professor { /*Id = 2, */FirstName = "Marija", LastName = "Trajkovska", Degree = "PHD", AcademicRank = "Professor", OfficeNumber = "102", HireDate = DateTime.Parse("09-10-2009") },
                new Professor { /*Id = 3, */FirstName = "Sara", LastName = "Andova", Degree = "Master", AcademicRank = "Assistant", OfficeNumber = "200", HireDate = DateTime.Parse("08-10-2015") },
                new Professor { /*Id = 4, */FirstName = "Ivan", LastName = "Markov", Degree = "Master", AcademicRank = "Assistant", OfficeNumber = "204", HireDate = DateTime.Parse("26-09-2016") }
                );
                context.SaveChanges();

                context.Subject.AddRange(
                new Subject { /*Id = 1, */Title = "OE", Credits = 6, Semester = 1, Programme = "KSIAR", FirstProfessorId = 1, SecondProfessorId = 4 },
                new Subject { /*Id = 2, */Title = "OEK", Credits = 6, Semester = 1, Programme = "KSIAR", FirstProfessorId = 2, SecondProfessorId = 4 },
                new Subject { /*Id = 3, */Title = "Mathematica 3", Credits = 6, Semester = 3, Programme = "KTI", FirstProfessorId = 3, SecondProfessorId = 2 },
                new Subject { /*Id = 4, */Title = "RSWEB", Credits = 6, Semester = 6, Programme = "TKII", FirstProfessorId = 4, SecondProfessorId = 1 },
                new Subject { /*Id = 5, */Title = "OWEB", Credits = 6, Semester = 5, Programme = "TKII", FirstProfessorId = 3, SecondProfessorId = 4 }
                );

                context.SaveChanges();
                context.StudentSubject.AddRange
                (
                new StudentSubject { CourseId = 1, StudentId = 1 },
                new StudentSubject { CourseId = 2, StudentId = 2 },
                new StudentSubject { CourseId = 3, StudentId = 3 },
                new StudentSubject { CourseId = 4, StudentId = 1 },
                new StudentSubject { CourseId = 5, StudentId = 2 }

                );
                context.SaveChanges();
            }
        }
    }
}