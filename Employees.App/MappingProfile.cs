using AutoMapper;
using Employees.Entities.Responses;
using Employees.Entities.ViewModels;

namespace EmployeesApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeResponse, EmployeeDisplayViewModel>().ReverseMap();

        }
    }
}
