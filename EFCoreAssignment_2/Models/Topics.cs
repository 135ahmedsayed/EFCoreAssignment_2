namespace EFCoreAssignment_2.Models;
internal class Topics
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Courses> courses { get; set; }
}

