using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PX.DAL.DTO;

namespace PX.DAL.IRepository
{
    public interface ICompanyRepository
    {
        IQueryable<Company> GetAll();
        Task<Company> GetByIdAsync(long companyId);
        Task<long> AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
    }
}