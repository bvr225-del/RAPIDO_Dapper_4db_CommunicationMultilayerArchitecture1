using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int deptid);
        Task<int> AddDepartment(Department deptdetail);
        Task<string> DeleteDepartment(int departmentid);
        Task<string> UpdateDepartment(Department deptdetail);

    }
}
