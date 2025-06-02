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
            using var transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var reviewer = await _employeeRepo.GetByNameAsync(dto.ReviewerName);
                if (reviewer == null)
                    throw new Exception("Reviewer not found");

                foreach (var entry in dto.Ratings)
                {
                    if (entry.Rate < 1 || entry.Rate > 5)
                        throw new Exception($"Invalid rating for {entry.EmployeeName} rating should be From {RatingEnum.One} to {RatingEnum.Five}");

                    var reviewed = await _employeeRepo.GetByNameAsync(entry.EmployeeName);
                    if (reviewed == null)
                        throw new Exception($"Employee {entry.EmployeeName} not found");

                    if (reviewed.Department.Id != reviewer.Department.Id)
                        throw new Exception($"{entry.EmployeeName} is not in the same department");

                    if (entry.EmployeeName == dto.ReviewerName)
                        throw new Exception($"You cannot rate yourself");

                    var existingReview = await _reviewRepo.GetByReviewerAndReviewedAsync(reviewer.Id, reviewed.Id);
                    if (existingReview != null)
                        throw new Exception($"You have already rated {entry.EmployeeName}");
                    else
                    {
                        var employeeReview = _employeeReviewMapper.MapToEmployeeReviewFromEmployeeRatingDtoAndId(reviewer, reviewed, entry.Rate);
                        await _reviewRepo.InsertAsync(employeeReview);
                    }
                }
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                
                    await transaction.RollbackAsync();
                    if (string.IsNullOrEmpty(ex.Message))
                        throw new Exception("An unknown error occurred while submitting ratings Please Submit Again.");
                    else
                        throw;
                
            }
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
