using DTOs.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Mappers
{
    public class EmployeeMapper
    {
        DepartmentMapper departmentMapper = new DepartmentMapper();

        public Employee MapToEmployeeFromEmployeeDto(EmployeeDto employeeDto)
        {
            return new Employee
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Department = departmentMapper.MapToDepartmentFromDepartmentDto(employeeDto.DepartmentDto)

            };

        }

        public EmployeeDto MapToEmployeeDtoFromEmployee(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                DepartmentDto = departmentMapper.MapToDepartmentDtoFromDepartment(employee.Department)

            };
        }
    }
}
