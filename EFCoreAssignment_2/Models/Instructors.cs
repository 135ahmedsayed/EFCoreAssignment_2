using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment_2.Models;
internal class Instructors
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20)]
    [Required]
    [Column(TypeName = "VarChar")]
    public string Name { get; set; }
    [Column(TypeName = "Decimal(3,2)")]
    public decimal? Bouns { get; set; }
    [Column(TypeName = "Decimal(10,2)")]
    public decimal Salary { get; set; }
    [Column(TypeName = "Decimal(5,2)")]
    public decimal? hourrate { get; set; }
    public ICollection<Departments> departments { get; set; }
    public int Dep_id { get; set; }
    public Departments departments1 { get; set; }
    public ICollection<Courses> courses { get; set; }

}
