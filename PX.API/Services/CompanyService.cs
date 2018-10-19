using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PX.API.IServices;
using PX.API.Models;
using PX.DAL.DTO;
using PX.DAL.IRepository;

namespace PX.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> SearchAsync<T>(SearchModel searchModel) where T : class
        {
            var query = _companyRepository.GetAll();
            if (!string.IsNullOrEmpty(searchModel.Keyword))
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{searchModel.Keyword}%")
                                         || c.Employees.Any(e => EF.Functions.Like(e.FirstName, $"%{searchModel.Keyword}%"))
                                         || c.Employees.Any(e => EF.Functions.Like(e.LastName, $"%{searchModel.Keyword}%")));

            if (searchModel.EmployeeDateOfBirthFrom.HasValue) query = query.Where(c => c.Employees.Any(e => e.DateOfBirth.Date >= searchModel.EmployeeDateOfBirthFrom.Value.Date));

            if (searchModel.EmployeeDateOfBirthTo.HasValue) query = query.Where(c => c.Employees.Any(e => e.DateOfBirth.Date <= searchModel.EmployeeDateOfBirthTo.Value.Date));

            if (searchModel.EmployeeJobTitles != null) query = query.Where(c => c.Employees.Any(e => searchModel.EmployeeJobTitles.Contains(e.JobTitle)));

            return _mapper.Map<IEnumerable<T>>(await query.ToListAsync());
        }

        public async Task<long> CreateAsync(CompanyModel companyModel)
        {
            var company = _mapper.Map<Company>(companyModel);
            return await _companyRepository.AddAsync(company);
        }

        public async Task UpdateAsync(long companyId, CompanyModel companyModel)
        {
            var companyDb = await GetByIdAsync(companyId);
            _mapper.Map(companyModel, companyDb);
            await _companyRepository.UpdateAsync(companyDb);
        }

        public async Task DeleteAsync(long companyId)
        {
            await _companyRepository.DeleteAsync(await GetByIdAsync(companyId));
        }

        private async Task<Company> GetByIdAsync(long companyId)
        {
            var companyDb = await _companyRepository.GetByIdAsync(companyId);
            if (companyDb == null) throw new ArgumentException($"Not found company by Id {companyId}");
            return companyDb;
        }
    }
}