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
                // var sql = "INSERT INTO Companies(Name,Address,City,State,PostCode) VALUES(@Name,@Address,@City,@State,@PostCode)" +
                //"SELECT CAST(SCOPE_IDENTITY() AS INT) ";
                // var countryId = _db.Query<int>(sql, company).Single();

                var sql = "USP_ADD_COMPANY";
                var elements = new DynamicParameters();
                elements.Add("@CompanyId", 0, DbType.Int32, direction: ParameterDirection.Output);
                elements.Add("@Name", company.Name);
                elements.Add("@Address", company.Address);
                elements.Add("@City", company.City);
                elements.Add("@State", company.State);
                elements.Add("@PostCode", company.PostCode);

                _db.Execute(sql, elements, commandType: CommandType.StoredProcedure);
                company.CompanyId = elements.Get<int>("CompanyId");
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
                //var query = "SELECT * FROM Companies Where CompanyId=@CompanyId";
                var query = "GET_COMPANY_BY_ID";
                var company = _db.Query<Company>(query, new { @CompanyId = id ?? 0 }, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
                //var query = "SELECT * FROM Companies";
                var query = "USP_GET_ALL_COMPANY";
                return _db.Query<Company>(query, commandType: CommandType.StoredProcedure).ToList();
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
                var sql = "SELECT TOP 1 * FROM Companies";
                var companyFromDB = _db.Query<Company>(sql).Single();

                if (companyFromDB != null)
                {
                    exists = true;
                }
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
                //var sql = "DELETE Companies WHERE CompanyId=@Id";
                var sql = "USP_DELETE_COMPANY";
                _db.Execute(sql, new { @Id = id ?? 0 }, commandType: CommandType.StoredProcedure);
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

                //var sql = "UPDATE Companies SET Name=@Name,Address=@Address,City=@City,State=@State,PostCode=@PostCode WHERE CompanyId=@CompanyId";
                //var countryId = _db.Query<int>(sql, new { @Name = company.Name, @Address = company.Address, @City = company.City, @State = company.State, @PostCode = company.PostCode, @CompanyId = company.CompanyId }).Single();

                var sql = "USP_UPDATE_COMPANY";
                var elements = new DynamicParameters();
                elements.Add("@CompanyId", company.CompanyId);
                elements.Add("@Name", company.Name);
                elements.Add("@Address", company.Address);
                elements.Add("@City", company.City);
                elements.Add("@State", company.State);
                elements.Add("@PostCode", company.PostCode);
                _db.Execute(sql, elements, commandType: CommandType.StoredProcedure);
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
