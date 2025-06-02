using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByNameAsync(string name);
        Task<List<Employee>> GetByNamesAsync(List<string> names);

    }
}
