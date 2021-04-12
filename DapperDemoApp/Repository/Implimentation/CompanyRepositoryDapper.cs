using Dapper;
using DapperDemoApp.Base;
using DapperDemoApp.Context;
using DapperDemoApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Repository.Implimentation
{
    public class CompanyRepositoryDapper : ICompanyRepository
    {

        private readonly IDbConnection _db;
        public CompanyRepositoryDapper(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Company> Add(Company company)
        {
            try
            {
                var sql = "INSERT INTO Companies(Name,Address,City,State,PostCode) VALUES(@Name,@Address,@City,@State,@PostCode)" +
               "SELECT CAST(SCOPE_IDENTITY() AS INT) ";
                //var countryId = _db.Query<int>(sql, new { @Name = company.Name, @Address = company.Address, @City = company.City, @State = company.State, @PostCode = company.PostCode }).Single();
                var countryId = _db.Query<int>(sql, company).Single();
                company.CompanyId = countryId;
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Company> Find(int? id)
        {
            try
            {
                var query = "SELECT * FROM Companies Where CompanyId=@CompanyId";
                var company = _db.Query<Company>(query, new { @CompanyId = id ?? 0 }).SingleOrDefault();
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<List<Company>> GetAll()
        {
            try
            {
                var query = "SELECT * FROM Companies";
                return _db.Query<Company>(query).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsCompanyExists(int id)
        {
            try
            {
                var exists = false;
                //var companyFromDb = _context.Companies.AsNoTracking().FirstOrDefault(x => x.CompanyId == id);
                //if (companyFromDb != null)
                //{
                //    exists = true;
                //}
                return exists;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remove(int? id)
        {
            try
            {
                var sql = "DELETE Companies WHERE CompanyId=@Id";
                _db.Execute(sql, new { @Id = id ?? 0 });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Company> Update(Company company)
        {
            try
            {

                var sql = "UPDATE Companies SET Name=@Name,Address=@Address,City=@City,State=@State,PostCode=@PostCode WHERE CompanyId=@CompanyId";
                //var countryId = _db.Query<int>(sql, new { @Name = company.Name, @Address = company.Address, @City = company.City, @State = company.State, @PostCode = company.PostCode, @CompanyId = company.CompanyId }).Single();
                _db.Execute(sql, company);

                return company;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
