using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EFCoreAssignment_2.Models;
[Table("Course")]
internal class Courses
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int? Duration { get; set; }
    [MaxLength(15)]
    [Column(TypeName = "VarChar")]
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public Topics topics { get; set; }
    [ForeignKey(nameof(Top_id))]
    public int Top_id { get; set; }
    public ICollection<Instructors> instructors { get; set; }
    public ICollection<StudCourse> StudCourses { get; set; }

    public ICollection<Student> Students { get; set; }

}
