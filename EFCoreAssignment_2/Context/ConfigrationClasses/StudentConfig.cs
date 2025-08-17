using System.Reflection.Emit;
using EFCoreAssignment_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EFCoreAssignment_2.Context.ConfigrationClasses;

internal class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students")
            .HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .UseIdentityColumn(1,1);
        builder.Property(e => e.FName)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("VarChar");
        builder.Property(e => e.LName)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("VarChar");
        builder.HasOne<Departments>()
            .WithMany()
            .HasForeignKey(e => e.Dep_id);

    }
}
