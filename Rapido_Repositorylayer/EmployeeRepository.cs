using Dapper;
using Rapido_BusinessEntities.Interfaces;
using Rapido_BusinessEntities.Models;
using Rapido_BusinessEntities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_Repositorylayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public EmployeeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddEmployees(Employee empdetail)
        {
            using (IDbConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                //In Dapper we will use the DynamicParameters class to pass data to the stored procedure input parameters.
                //The DynamicParameters class allows us to define parameters and their values in a flexible way, making it easier to work with stored procedures that require multiple parameters or output parameters.
                //Create object for DynamicParameters class  for Passing  data to Storedprocedure input paramaters..
                //The first argument is the name of the parameter as defined in the stored procedure, and the second argument is the value you want to pass to that parameter.
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredprocedureParameters.EmployeeName, empdetail.empname);
                parameters.Add(StoredprocedureParameters.EmployeeSalary, empdetail.empsalary);
                parameters.Add(StoredprocedureParameters.Insertedvariable, DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredprocedureNames.AddEmployee, parameters, commandType: CommandType.StoredProcedure);
                int inserterdid = parameters.Get<int>(StoredprocedureParameters.Insertedvariable);
                return inserterdid;

            }

        }

        public async Task<string> DeleteEmployeeById(int empid)
        {
            using (IDbConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                DynamicParameters p = new DynamicParameters();
                p.Add(StoredprocedureParameters.EmployeeID, empid);
               var result=  await con.QueryAsync<Employee>(StoredprocedureNames.DeleteEmployee, p, commandType: CommandType.StoredProcedure);
                Employee emp=result.FirstOrDefault();
                if (emp==null)
                {
                    return $"emp Id{empid} does not exist in database. " ;
                }
                else
                {
                    var empData= $"emp Id {emp.empid} with emp name {emp.empname} and emp salary {emp.empsalary} is deleted from database.";
                    await con.ExecuteScalarAsync(StoredprocedureNames.DeleteEmployee, p, commandType: CommandType.StoredProcedure);
                    return empData;
                }


            }

        }

        public async Task<Employee> GetEmployeeById(int empid)
        {
            using (IDbConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add(StoredprocedureParameters.EmployeeID, empid);
                var result = await con.QueryAsync<Employee>(StoredprocedureNames.GetEmployeeByEmpid, p, commandType: CommandType.StoredProcedure);
                Employee emp = result.FirstOrDefault();//FirstOrDefault() it will return the first element of the sequence or a default value if the sequence contains no elements. In this case, it will return the first Employee object from the result set or null if there are no matching records.
                return emp;
            }

        }

        public async Task<List<Employee>> GetEmployees()
        {
            using (IDbConnection conn = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                var queryresult = await conn.QueryAsync<Employee>(StoredprocedureNames.GetEmployee, CommandType.StoredProcedure);
                List<Employee> res = queryresult.ToList();
                return res;
            }

        }

        public async Task<string> UpdateEmployee(Employee empdetail)
        {
            using (IDbConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add(StoredprocedureParameters.EmployeeID, empdetail.empid);
                var result = await con.QueryAsync(StoredprocedureNames.GetEmployeeByEmpid, p, commandType: CommandType.StoredProcedure);
                Employee emp=result.FirstOrDefault();
                if (emp==null)
                {
                    return $"emp Id {empdetail.empid} does not exist in database. ";
                }
                else
                {
                    var UpdatedData = $"Updated Employee: ID={empdetail.empid}, Name={empdetail.empname}, Salary={empdetail.empsalary}";
                    var pu = new DynamicParameters();
                    pu.Add(StoredprocedureParameters.EmployeeID, empdetail.empid);
                    pu.Add(StoredprocedureParameters.EmployeeName, empdetail.empname);
                    pu.Add(StoredprocedureParameters.EmployeeSalary, empdetail.empsalary);
                    await con.ExecuteReaderAsync(StoredprocedureNames.UpdateEmployee, pu, commandType: CommandType.StoredProcedure);
                    return UpdatedData;
                }
            }

        }
    }
}