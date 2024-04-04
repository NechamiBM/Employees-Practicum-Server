using AutoMapper;
using Employees.Core.DTOs;
using Employees.Core.Entities;

namespace Employees.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
