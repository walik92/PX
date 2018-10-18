using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PX.DAL.Context;
using PX.DAL.DTO;
using PX.DAL.IRepository;

namespace PX.DAL.Repository
{
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        private readonly PxDbContext _context;

        public CompanyRepository(PxDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<long> AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            return company.Id;
        }

        public async Task UpdateAsync(long companyId, Company company)
        {
            var companyOld = await _context.Companies.FindAsync(companyId);

            companyOld.EstablishmentYear = company.EstablishmentYear;
            companyOld.Name = company.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}