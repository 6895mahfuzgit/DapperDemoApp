using Dapper;
using DapperDemoApp.Models;
using DapperDemoApp.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DapperDemoApp.Repository.Implimentation
{
    public class AdvanceRepository : IAdvanceRepository
    {
        private readonly IDbConnection _db;

        public AdvanceRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }


        //Multi Query Execute
        public Company GetCompanyWithAddress(int id)
        {
            try
            {
                var countryIdObj = new { CompanyId = id };
                var query = @"SELECT * FROM Companies WHERE CompanyId=@CompanyId
                              SELECT * FROM Employees WHERE CompanyId=@CompanyId";
                Company company;
                using (var lists = _db.QueryMultiple(query, countryIdObj))
                {
                    company = lists.Read<Company>().ToList().FirstOrDefault();
                    company.Employees = lists.Read<Employee>().ToList();
                }
                return company;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<Company> GetCompanyWithEmployees()
        {
            try
            {
                var query = @"SELECT C.*,E.* FROM Companies  C JOIN  Employees E ON c.CompanyId=E.CompanyId";
                var companyDictionary = new Dictionary<int, Company>();

                var companies = _db.Query<Company, Employee, Company>(query, (c, e) =>
                {
                    if (!companyDictionary.TryGetValue(c.CompanyId, out var currentCompany))
                    {
                        currentCompany = c;
                        companyDictionary.Add(currentCompany.CompanyId, currentCompany);
                    }
                    
                    currentCompany.Employees.Add(e);
                    return currentCompany;
                }, splitOn: "EmployeeId");

                return companies.Distinct().ToList();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
