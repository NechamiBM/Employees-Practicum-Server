using Employees.Core.Entities;

namespace Employees.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleType>> GetRolesAsync();
        Task AddRoleAsync(RoleType role);
    }
}
