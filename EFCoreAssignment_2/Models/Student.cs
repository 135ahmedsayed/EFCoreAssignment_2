
namespace EFCoreAssignment_2.Models;

internal class Student
{
    public int Id { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }   
    public string? Address { get; set; }
    public int? Age { get; set; }
    public ICollection<Departments> departments { get; set; }
    public int? Dep_id { get; set; }
    public ICollection<StudCourse> StudCourses { get; set; }
    public ICollection<Courses> courses { get; set; }
}
