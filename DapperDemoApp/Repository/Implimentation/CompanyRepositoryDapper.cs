﻿using Dapper;
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
            //await _context.Companies.AddAsync(company);
            //await _context.SaveChangesAsync();
            return company;
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
                //var companyFromDb = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyId == (id ?? 0));
                //_context.Companies.Remove(companyFromDb);
                //await _context.SaveChangesAsync();
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
                //var companyFromDb = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.CompanyId == company.CompanyId);
                //if (companyFromDb != null)
                //{
                //    companyFromDb.Name = company.Name;
                //    companyFromDb.Address = company.Address;
                //    companyFromDb.City = company.City;
                //    companyFromDb.State = company.State;
                //    companyFromDb.PostCode = company.PostCode;
                //    await _context.SaveChangesAsync();
                //}
                //return companyFromDb;
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
