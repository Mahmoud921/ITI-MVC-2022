using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base()
        {}
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
