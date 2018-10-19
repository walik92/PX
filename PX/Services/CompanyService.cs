using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Expression<Func<Company, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(searchModel.Keyword))
                predicate = c => EF.Functions.Like(c.Name, $"{searchModel.Keyword}%")
                                 || c.Employees.Any(e => EF.Functions.Like(e.FirstName, $"{searchModel.Keyword}%"))
                                 || c.Employees.Any(e => EF.Functions.Like(e.Surname, $"{searchModel.Keyword}%"));

            if (searchModel.EmployeeDateOfBirthFrom.HasValue) predicate = c => c.Employees.Any(e => e.DateOfBirth.Date >= searchModel.EmployeeDateOfBirthFrom.Value.Date);

            if (searchModel.EmployeeDateOfBirthTo.HasValue) predicate = c => c.Employees.Any(e => e.DateOfBirth.Date <= searchModel.EmployeeDateOfBirthTo.Value.Date);

            if (searchModel.EmployeeJobTitles != null) predicate = c => c.Employees.Any(e => searchModel.EmployeeJobTitles.Contains(e.JobTitle));

            var result = await _companyRepository.GetAsync(predicate);
            return _mapper.Map<IEnumerable<T>>(result);
        }

        public async Task<long> CreateAsync(CompanyModel companyModel)
        {
            var company = _mapper.Map<Company>(companyModel);
            return await _companyRepository.AddAsync(company);
        }
    }
}