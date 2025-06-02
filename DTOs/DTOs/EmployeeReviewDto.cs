using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs
{
    public class EmployeeReviewDto
    {
        public int Id { get; set; }
        public EmployeeDto? Employee { get; set; }
        public EmployeeDto? ReviewedEmployee { get; set; }
        public int EmployeeRate { get; set; }
    }


  
    public class EmployeeRatingDto
    {
       public string? ReviewerName { get; set; }
        public List<RatingEntryDto> Ratings { get; set; } = new(); 
    }
    public class RatingEntryDto
    {
        public string? EmployeeName { get; set; } 
        public int Rate { get; set; } 
    }
}
