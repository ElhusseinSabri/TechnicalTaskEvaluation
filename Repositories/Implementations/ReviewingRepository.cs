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
    public class ReviewingRepository : IReviewingRepository
    {
        private readonly AppDbContext _appDbContext;
        public ReviewingRepository(AppDbContext appDbContext)=>_appDbContext = appDbContext;
        public async Task InsertAsync(EmployeeReview employeeReview)
        {
            _appDbContext.EmployeeReviews.Add(employeeReview);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task <List<EmployeeReview>> GetEmployeeReviewsAsync(string employeeName)
        {
            return await _appDbContext.EmployeeReviews
           .Include(r => r.Employee) 
           .ThenInclude(e => e.Department)
           .Include(r => r.ReviewedEmployee) 
           .ThenInclude(e => e.Department)
           .Where(r => r.ReviewedEmployee.Name == employeeName)
           .ToListAsync();





        }
        public async Task<EmployeeReview> GetByReviewerAndReviewedAsync(int employeeId, int reviewedId)
        {
            return await _appDbContext.EmployeeReviews.FirstOrDefaultAsync(e => e.Employee.Id == employeeId && e.ReviewedEmployee.Id == reviewedId);

        }


    }
}
