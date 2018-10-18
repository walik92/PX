using System.Collections.Generic;
using System.Threading.Tasks;
using PX.DAL.DTO;

namespace PX.DAL.IRepository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<long> AddAsync(Company company);
        Task UpdateAsync(long companyId, Company company);
        Task DeleteAsync(int companyId);
    }
}