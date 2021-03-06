﻿using System;
using System.Linq;
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

        public IQueryable<Company> GetAll()
        {
            return _context.Companies.Include(e => e.Employees).AsNoTracking().AsQueryable();
        }

        public async Task<Company> GetByIdAsync(long companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task<long> AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Attach(company);
            _context.Entry(company).State = EntityState.Modified;

            await _context.Employees.Where(q => q.CompanyId == company.Id).ForEachAsync(e => _context.Employees.Remove(e));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            if (_context.Entry(company).State == EntityState.Detached) _context.Companies.Attach(company);
            _context.Remove(company);

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}