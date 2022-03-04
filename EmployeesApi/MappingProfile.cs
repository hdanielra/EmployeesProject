using AutoMapper;
using Employees.Entities.Responses;
using Employees.Entities.Models;
using Employees.Entities.ViewModels;

namespace AutoMapperMVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = CreateMap<EmployeeResponse, Employee>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.EmployeeName, o => o.MapFrom(s => s.Employee_Name))
                .ForMember(d => d.EmployeeAge, o => o.MapFrom(s => s.Employee_Age))
                .ForMember(d => d.EmployeeSalary, o => o.MapFrom(s => s.Employee_Salary))
                .ForMember(d => d.ProfileImage, o => o.MapFrom(s => s.Profile_Image))
                .ReverseMap();


            _ = CreateMap<EmployeeResponse, EmployeeDisplayViewModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.EmployeeName, o => o.MapFrom(s => s.Employee_Name))
                .ForMember(d => d.EmployeeAge, o => o.MapFrom(s => s.Employee_Age))
                .ForMember(d => d.EmployeeSalary, o => o.MapFrom(s => s.Employee_Salary))
                .ForMember(d => d.ProfileImage, o => o.MapFrom(s => s.Profile_Image))
                .ReverseMap();

        }
    }
}
