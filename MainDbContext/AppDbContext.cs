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


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Department>().HasData(
        //        new Department { Id = 1, Name = "Marketing" },
        //        new Department { Id = 2, Name = "Development" }
        //    );

        //    modelBuilder.Entity<Employee>().HasData(
        //        new Employee { Id = 1, Name = "Mohamed", DepartmentId = 1 },
        //        new Employee { Id = 2, Name = "Ahmed", DepartmentId = 1 },
        //        new Employee { Id = 3, Name = "Sarah", DepartmentId = 1 },
        //        new Employee { Id = 4, Name = "Nahla", DepartmentId = 2 },
        //        new Employee { Id = 5, Name = "Hanaa", DepartmentId = 2 },
        //        new Employee { Id = 6, Name = "Soaad", DepartmentId = 2 }
        //    );
        //}


    }
}
