using Employees.Core.Entities;

namespace Employees.Core.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleType>> GetRolesAsync();
        Task AddRoleAsync(RoleType role);
    }
}
