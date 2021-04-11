using DapperDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Repository
{
    public interface ICompanyRepository
    {
        Task<Company> Find(int? id);
        Task<List<Company>> GetAll();
        Task<Company> Add(Company company);
        Task<Company> Update(Company company);
        Task Remove(int? id);
        bool IsCompanyExists(int id);
    }
}
