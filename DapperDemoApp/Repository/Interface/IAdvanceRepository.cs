using DapperDemoApp.Models;
using System.Collections.Generic;

namespace DapperDemoApp.Repository.Interface
{
    public interface IAdvanceRepository
    {
        Company GetCompanyWithAddress(int id);
        List<Company> GetCompanyWithEmployees();
    }
}
