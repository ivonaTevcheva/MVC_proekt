using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_proekt.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcademicRank = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    OfficeNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcquiredCredits = table.Column<int>(type: "int", nullable: true),
                    CurrentSemester = table.Column<int>(type: "int", nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Programme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FirstProfessorId = table.Column<int>(type: "int", nullable: true),
                    SecondProfessorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Professor_FirstProfessorId",
                        column: x => x.FirstProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subject_Professor_SecondProfessorId",
                        column: x => x.SecondProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    SeminaIUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExamPoints = table.Column<int>(type: "int", nullable: true),
                    SeminalPoints = table.Column<int>(type: "int", nullable: true),
                    AdditionalPoints = table.Column<int>(type: "int", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_CourseId",
                table: "StudentSubject",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FirstProfessorId",
                table: "Subject",
                column: "FirstProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SecondProfessorId",
                table: "Subject",
                column: "SecondProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
