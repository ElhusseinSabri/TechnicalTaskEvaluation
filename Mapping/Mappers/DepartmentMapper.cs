using DTOs.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Mappers
{
    public class DepartmentMapper
    {
        public Department MapToDepartmentFromDepartmentDto(DepartmentDto departmentDto)
        {
            return new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
            };
        }

        public DepartmentDto MapToDepartmentDtoFromDepartment(Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
            };
        }
    }
}
