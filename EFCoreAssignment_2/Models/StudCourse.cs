
namespace EFCoreAssignment_2.Models;
internal class StudCourse
{
    public int Stud_Id { get; set; }
    public int Course_Id { get; set; }
    public double Grade { get; set; }
    public Student Student { get; set; }
    public Courses Course { get; set; }
}
