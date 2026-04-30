using Rapido_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int empid);
        Task<int> AddEmployees(EmployeeDto empdetail);
        Task<bool> DeleteEmployeeById(int empid);
        Task<bool> UpdateEmployee(EmployeeDto empdetail);

    }
}
