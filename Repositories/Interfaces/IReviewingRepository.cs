using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IReviewingRepository
    {
        Task InsertAsync(EmployeeReview employeeReview);
        Task<List<EmployeeReview>> GetEmployeeReviewsAsync(string employeeName);
        Task<EmployeeReview> GetByReviewerAndReviewedAsync(int reviewerId, int reviewedId);
        Task InsertRangeAsync(List<EmployeeReview> reviews);

        Task<List<EmployeeReview>> GetByReviewerAndReviewedsAsync(int reviewerId, List<int> reviewedIds);

    }
}
