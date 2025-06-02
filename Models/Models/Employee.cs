using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
