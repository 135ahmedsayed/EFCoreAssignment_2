namespace EFCoreAssignment_2.Models;
internal class Departments
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Instructors> instructors { get; set; }
    public int Ins_Id { get; set; } // Manager's Instructor ID
    public Instructors ManagerIns { get; set; } 
    public DateTime HiringDate { get; set; }
}
