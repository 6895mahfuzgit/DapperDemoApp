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

        public Task<Company> Add(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Find(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsCompanyExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
