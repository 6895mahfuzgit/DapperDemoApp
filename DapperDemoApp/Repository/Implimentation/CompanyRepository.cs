using DapperDemoApp.Base;
using DapperDemoApp.Context;
using DapperDemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Repository.Implimentation
{
    public class CompanyRepository : EntityBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Company> Add(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }


        public async Task<Company> Find(int? id)
        {
            try
            {
                var companyFromDb = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.CompanyId == (id ?? 0));
                if (companyFromDb != null)
                {
                    return companyFromDb;
                }
                return new Company();
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
                var companies = await _context.Companies.AsNoTracking().ToListAsync();
                return companies;
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
                var companyFromDb = _context.Companies.AsNoTracking().FirstOrDefault(x => x.CompanyId == id);
                if (companyFromDb != null)
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
                var companyFromDb = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyId == (id ?? 0));
                _context.Companies.Remove(companyFromDb);
                await _context.SaveChangesAsync();
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
                var companyFromDb = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.CompanyId == company.CompanyId);
                if (companyFromDb != null)
                {
                    companyFromDb.Name = company.Name;
                    companyFromDb.Address = company.Address;
                    companyFromDb.City = company.City;
                    companyFromDb.State = company.State;
                    companyFromDb.PostCode = company.PostCode;
                    await _context.SaveChangesAsync();
                }
                return companyFromDb;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
