using MainDbContext;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) => _context = context;

        public async Task<Employee> GetByNameAsync(string name)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
