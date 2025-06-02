using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Globalization;

namespace MainDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeReview> EmployeeReviews { get; set; }

    }
}
