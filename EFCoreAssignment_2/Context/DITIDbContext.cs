
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment_2.Context
{
    internal class DITIDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ClassConfiguration
        }
    }
}
