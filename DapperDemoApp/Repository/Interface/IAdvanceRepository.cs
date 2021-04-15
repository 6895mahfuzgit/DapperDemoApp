using DapperDemoApp.Models;

namespace DapperDemoApp.Repository.Interface
{
    public interface IAdvanceRepository
    {
        Company GetCompanyWithAddress(int id);
    }
}
