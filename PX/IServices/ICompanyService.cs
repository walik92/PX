using System.Collections.Generic;
using System.Threading.Tasks;
using PX.API.Models;

namespace PX.API.IServices
{
    public interface ICompanyService
    {
        Task<IEnumerable<T>> SearchAsync<T>(SearchModel searchModel) where T : class;
        Task<long> CreateAsync(CompanyModel companyModel);
        Task UpdateAsync(long companyId, CompanyModel companyModel);
        Task DeleteAsync(long companyId);
    }
}