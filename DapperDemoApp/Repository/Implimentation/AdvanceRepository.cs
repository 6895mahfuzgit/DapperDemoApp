using Dapper;
using DapperDemoApp.Models;
using DapperDemoApp.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
