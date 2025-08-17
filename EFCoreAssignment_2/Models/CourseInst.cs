using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment_2.Models;
[PrimaryKey(nameof(Inst_ID),nameof(Course_ID))]
internal class CourseInst
{
    public int Inst_ID { get; set; }
    public int Course_ID { get; set; }
    public string Evaluate { get; set; }
    public Instructors instructors { get; set; }

    public Courses courses { get; set; }

}
