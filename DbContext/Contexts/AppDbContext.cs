using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DbContext.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
=        }
        public DbSet<User> User { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BorrowedBooks> BorrowedBooks { get; set; }


    }
}
