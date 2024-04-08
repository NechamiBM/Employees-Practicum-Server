using Employees.Core.Entities;
using Employees.Core.Repositories;

namespace Employees.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<RoleType>> GetRolesAsync() => await Task.FromResult(_context.RoleTypes);
        public async Task AddRoleAsync(RoleType role)
        {
            var roles = _context.RoleTypes.FirstOrDefault(r => role.Name == r.Name);
            if (roles == null)
                _context.RoleTypes.Add(role);
            await _context.SaveChangesAsync();
        }
    }
}
