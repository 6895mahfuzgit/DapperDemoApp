using Dapper;
using DapperDemoApp.Models;
using DapperDemoApp.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Repository.Implimentation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;


        public EmployeeRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Employee> Add(Employee employee)
        {
            try
            {

                var query = "INSERT INTO Employees(Name,Email,Title,Phone,CompanyId) VALUES (@Name,@Email,@Title,@Phone,@CompanyId); SELECT CAST( SCOPE_IDENTITY()AS INT)";
                var employeeId = await _db.QueryAsync<int>(query, employee);
                employee.EmployeeId = employeeId.Single();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Employee> Find(int? id)
        {
            try
            {
                var query = "SELECT E.*,C.* FROM  Employees E JOIN Companies  C ON  E.CompanyId=C.CompanyId WHERE E.EmployeeId=@Id";
                var employee = _db.Query<Employee, Company, Employee>(query, (E, C) =>
               {
                   Employee emp;
                   emp = E;
                   emp.Company = C;
                   return E;
               }, new { @Id = id }, splitOn: "CompanyId").Single();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            try
            {
                var query = "SELECT E.*,C.* FROM  Employees E JOIN Companies  C ON  E.CompanyId=C.CompanyId";
                var employees = _db.Query<Employee, Company, Employee>(query, (E, C) =>
                  {
                      Employee employee;
                      employee = E;
                      employee.Company = C;
                      return E;
                  }, splitOn: "CompanyId"
                  ).AsQueryable().ToList();

                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool IsEmployeeExists(int id)
        {
            try
            {
                var isEmplyeeExist = false;
                var query = "SELECT * FROM  Employees WHERE EmployeeId=@Id";
                var employee = _db.Query<Employee>(query, new { @Id = id }).Single();

                if (employee != null)
                {
                    isEmplyeeExist = true;
                }
                return isEmplyeeExist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task Remove(int? id)
        {
            try
            {
                var query = "DELETE  Employees WHERE EmployeeId=@Id";
                var employee = _db.Execute(query, new { @Id = id ?? 0 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Employee> Update(Employee employee)
        {
            try
            {
                var query = "UPDATE Employees SET Name=@Name,Email=@Email,Title=@Title,Phone=@Phone,CompanyId=@CompanyId WHERE EmployeeId=@EmployeeId ";
                _db.Execute(query, employee);
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
