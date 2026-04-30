using AutoMapper;
using Rapido_BusinessEntities.Dtos;
using Rapido_BusinessEntities.Interfaces;
using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_ServiceLayer
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        //Don't create dirrect object of repository class here
        //create the onstructor of this service class and inject the repository interface into the constructor and assign it to the private readonly field of the repository interface type.

        //constructor injection
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            this._mapper = mapper;
        }
        public async Task<int> AddDepartment(DepartmentDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department dept = new Department();
            _mapper.Map(deptdetail, dept);
            var res = await _departmentRepository.AddDepartment(dept);
            return res;

        }

        public async Task<string> DeleteDepartment(int departmentid)
        {
            var result = await _departmentRepository.DeleteDepartment(departmentid);
            return result;

        }

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var res = await _departmentRepository.GetDepartmentById(deptid);
            return _mapper.Map<DepartmentDto>(res);

        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {
            var res = await _departmentRepository.GetDepartments();
            return _mapper.Map<List<DepartmentDto>>(res);

        }

        public async Task<string> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            _mapper.Map(deptdetail, dept);
          string result =  await _departmentRepository.UpdateDepartment(dept);
            return result;

        }
    }
}
