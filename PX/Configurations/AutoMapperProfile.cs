using AutoMapper;
using PX.API.Models;
using PX.DAL.DTO;

namespace PX.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CompanyModel, Company>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EstablishmentYear, opt => opt.MapFrom(src => src.EstablishmentYear))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            CreateMap<EmployeeModel, Employee>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle));

            CreateMap<Company, CompanyModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EstablishmentYear, opt => opt.MapFrom(src => src.EstablishmentYear))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            CreateMap<Employee, EmployeeModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle));
        }
    }
}