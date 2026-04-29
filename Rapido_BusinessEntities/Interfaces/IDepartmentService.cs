using Rapido_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartmentById(int deptid);
        Task<int> AddDepartment(DepartmentDto deptdetail);
        Task<string> DeleteDepartment(int departmentid);
        Task<string> UpdateDepartment(DepartmentDto deptdetail);

    }
}
