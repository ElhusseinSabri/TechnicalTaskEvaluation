using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class EmployeeReview
    {
        public int Id { get; set; }
        public Employee? Employee { get; set; }
        public Employee? ReviewedEmployee { get; set; }
        public RatingEnum EmployeeRate {  get; set; }
    }
}
