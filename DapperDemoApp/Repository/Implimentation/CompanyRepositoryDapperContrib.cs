using Dapper.Contrib.Extensions;
using DapperDemoApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Repository.Implimentation
{
    public class CompanyRepositoryDapperContrib : ICompanyRepository
    {
        private readonly IDbConnection _db;


        public CompanyRepositoryDapperContrib(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Company> Add(Company company)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Company> Find(int? id)
        {
            try
            {
                return null;
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
                var companies = _db.GetAll<Company>().ToList();
                return companies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool IsCompanyExists(int id)
        {
            try
            {
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task Remove(int? id)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Company> Update(Company company)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
