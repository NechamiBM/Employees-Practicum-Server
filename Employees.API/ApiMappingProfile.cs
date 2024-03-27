using AutoMapper;
using Employees.API.Models;
using Employees.Core.Entities;

namespace Employees.API
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Employee, EmployeePostModel>().ReverseMap();
            CreateMap<RoleEmployee, RoleEmployeePostModel>().ReverseMap();
        }
    }

}
