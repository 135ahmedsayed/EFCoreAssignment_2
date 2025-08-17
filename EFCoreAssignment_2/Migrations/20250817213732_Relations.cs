using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAssignment_2.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    topicsId = table.Column<int>(type: "int", nullable: false),
                    Top_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Topics_topicsId",
                        column: x => x.topicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesInstructors",
                columns: table => new
                {
                    coursesId = table.Column<int>(type: "int", nullable: false),
                    instructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesInstructors", x => new { x.coursesId, x.instructorsId });
                    table.ForeignKey(
                        name: "FK_CoursesInstructors_Course_coursesId",
                        column: x => x.coursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesStudent",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    coursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesStudent", x => new { x.StudentsId, x.coursesId });
                    table.ForeignKey(
                        name: "FK_CoursesStudent_Course_coursesId",
                        column: x => x.coursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ins_Id = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Bouns = table.Column<decimal>(type: "Decimal(3,2)", nullable: true),
                    Salary = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    hourrate = table.Column<decimal>(type: "Decimal(5,2)", nullable: true),
                    Dep_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_Dep_id",
                        column: x => x.Dep_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Dep_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_Dep_id",
                        column: x => x.Dep_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudCourses",
                columns: table => new
                {
                    Stud_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudCourses", x => new { x.Stud_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_StudCourses_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudCourses_Course_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudCourses_Students_Stud_Id",
                        column: x => x.Stud_Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_topicsId",
                table: "Course",
                column: "topicsId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInstructors_instructorsId",
                table: "CoursesInstructors",
                column: "instructorsId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesStudent_coursesId",
                table: "CoursesStudent",
                column: "coursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Ins_Id",
                table: "Departments",
                column: "Ins_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StudentId",
                table: "Departments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dep_id",
                table: "Instructors",
                column: "Dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_Course_Id",
                table: "StudCourses",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_CourseId",
                table: "StudCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_StudentId",
                table: "StudCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dep_id",
                table: "Students",
                column: "Dep_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesInstructors_Instructors_instructorsId",
                table: "CoursesInstructors",
                column: "instructorsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesStudent_Students_StudentsId",
                table: "CoursesStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_Ins_Id",
                table: "Departments",
                column: "Ins_Id",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Students_StudentId",
                table: "Departments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_Ins_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Students_StudentId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "CoursesInstructors");

            migrationBuilder.DropTable(
                name: "CoursesStudent");

            migrationBuilder.DropTable(
                name: "StudCourses");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
