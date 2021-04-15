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
                _db.Insert(company);
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
                return _db.Get<Company>(id ?? 0);
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
                var isExists = false;
                var comapny = _db.Get<Company>(new Company { CompanyId = id });
                if (comapny != null)
                {
                    isExists = true;
                }

                return isExists;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remove(int? id = 0)
        {
            try
            {
                _db.Delete(new Company { CompanyId = id ?? 0 });
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
                _db.Update(company);
                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
