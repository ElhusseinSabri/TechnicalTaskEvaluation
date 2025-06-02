using DTOs.DTOs;
using MainDbContext;
using Mapping.Mappers;
using Models.Enums;
using Models.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ReviewingService : IReviewingService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IReviewingRepository _reviewRepo;
        private readonly AppDbContext _appDbContext;
        private EmployeeReviewMapper _employeeReviewMapper = new EmployeeReviewMapper();
        public ReviewingService(IEmployeeRepository employeeRepo, IReviewingRepository reviewRepo, AppDbContext appDbContext)
        {
            _employeeRepo = employeeRepo;
            _reviewRepo = reviewRepo;
            _appDbContext = appDbContext;
        }
        public async Task SubmitRatingsAsync(EmployeeRatingDto dto)
        {
         
            var reviewer = await _employeeRepo.GetByNameAsync(dto.ReviewerName);
            if (reviewer == null)
                throw new KeyNotFoundException("Reviewer not found");

            var ratedEmployeeNames = dto.Ratings
                .Select(r => r.EmployeeName)
                .Distinct()
                .ToList();

            var reviewedEmployees = await _employeeRepo.GetByNamesAsync(ratedEmployeeNames);
            var reviewedDict = reviewedEmployees.ToDictionary(e => e.Name, StringComparer.OrdinalIgnoreCase);

            var existingReviews = await _reviewRepo.GetByReviewerAndReviewedsAsync(reviewer.Id, reviewedEmployees.Select(e => e.Id).ToList());
            var existingReviewPairs = new HashSet<(int, int)>(
                existingReviews.Select(r => (r.Employee.Id, r.ReviewedEmployee.Id)));

            var newReviews = new List<EmployeeReview>();

            foreach (var entry in dto.Ratings)
            {
                if (entry.Rate < 1 || entry.Rate > 5)
                    throw new ArgumentException($"Invalid rating for {entry.EmployeeName}. Must be between {RatingEnum.One} and {RatingEnum.Five}");

                if (entry.EmployeeName.Equals(dto.ReviewerName, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("You cannot rate yourself");

                if (!reviewedDict.TryGetValue(entry.EmployeeName, out var reviewed))
                    throw new KeyNotFoundException($"Employee {entry.EmployeeName} not found");

                if (reviewed.Department.Id != reviewer.Department.Id)
                    throw new InvalidOperationException($"{entry.EmployeeName} is not in the same department");

                if (existingReviewPairs.Contains((reviewer.Id, reviewed.Id)))
                    throw new InvalidOperationException($"You have already rated {entry.EmployeeName}");

                var employeeReview = _employeeReviewMapper.MapToEmployeeReviewFromEmployeeRatingDtoAndId(reviewer, reviewed, entry.Rate);
                newReviews.Add(employeeReview);
            }

            await _reviewRepo.InsertRangeAsync(newReviews);
        }
        

        public async Task<List<EmployeeReviewDto>> GetEmployeeEvaluationsAsync(string employeeName){

            var employee = await _employeeRepo.GetByNameAsync(employeeName);
            if (employee == null) throw new Exception("No Employee Exist with this Name");
            var reviews = await _reviewRepo.GetEmployeeReviewsAsync(employeeName);

            if (!reviews.Any())
                throw new Exception("No reviews found for this employee");
            return _employeeReviewMapper.MapListToEmployeeReviewDtosFromListEmployeeReview(reviews);

        }



    }
}
