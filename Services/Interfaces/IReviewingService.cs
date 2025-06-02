using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReviewingService
    {
        Task<List<EmployeeReviewDto>> GetEmployeeEvaluationsAsync(string name);
        Task SubmitRatingsAsync(EmployeeRatingDto employeeRatingDto);
    }
}
