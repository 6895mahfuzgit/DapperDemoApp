using DapperDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperDemoApp.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> Find(int? id);
        Task<List<Employee>> GetAll();
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task Remove(int? id);
        bool IsEmployeeExists(int id);
    }
}
