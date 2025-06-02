using DTOs.DTOs;
using Models.Enums;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Mappers
{
    public class EmployeeReviewMapper
    {
        EmployeeMapper employeeMapper = new EmployeeMapper();

        public EmployeeReview MapToEmployeeReview(EmployeeReviewDto employeeReviewDto)
        {
            return new EmployeeReview
            {
                Id = employeeReviewDto.Id,
                Employee = employeeMapper.MapToEmployeeFromEmployeeDto(employeeReviewDto.Employee),
                ReviewedEmployee = employeeMapper.MapToEmployeeFromEmployeeDto(employeeReviewDto.ReviewedEmployee),
                EmployeeRate =(RatingEnum)employeeReviewDto.EmployeeRate,
            };


        }
        public EmployeeReview MapToEmployeeReviewFromEmployeeRatingDtoAndId(Employee employee, Employee reviewdEmployee, int rate)
        {
            return new EmployeeReview
            {
                Employee = employee,
                ReviewedEmployee = reviewdEmployee,
                EmployeeRate = (RatingEnum)rate
            };

        }

        public EmployeeReviewDto MapToEmployeeReviewDtoFromEmployeeReview(EmployeeReview employeeReview)
        {
            return  new EmployeeReviewDto
            {

                Id = employeeReview.Id,
                Employee = employeeMapper.MapToEmployeeDtoFromEmployee( employeeReview.Employee),
                EmployeeRate = (int)employeeReview.EmployeeRate,
                ReviewedEmployee = employeeMapper.MapToEmployeeDtoFromEmployee(employeeReview.ReviewedEmployee)
            };
        }

        public List<EmployeeReviewDto> MapListToEmployeeReviewDtosFromListEmployeeReview(List<EmployeeReview> reviews)
        {
            return reviews
                .Select(MapToEmployeeReviewDtoFromEmployeeReview)
                .ToList();
        }


    }
}
