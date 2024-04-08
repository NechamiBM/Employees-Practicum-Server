using Employees.Core.Entities;
using Employees.Core.Repositories;
using Employees.Core.Services;

namespace Employees.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public async Task<IEnumerable<RoleType>> GetRolesAsync() => await _roleRepository.GetRolesAsync();

        public async Task AddRoleAsync(RoleType role)=> await _roleRepository.AddRoleAsync(role);

    }
}
