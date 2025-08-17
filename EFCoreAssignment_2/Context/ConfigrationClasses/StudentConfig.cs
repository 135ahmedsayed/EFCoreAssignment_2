using EFCoreAssignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment_2.Context.ConfigrationClasses;

internal class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
    {
        //builder.ToTable("Students")
    }
}
