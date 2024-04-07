using Employees.Core.Entities;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Employee>> GetEmployeesAsync() => await Task.FromResult(_context.Employees.Include(e => e.Roles).ThenInclude(r => r.RoleType));

        public async Task<Employee> GetEmployeeAsync(int id) => await _context.Employees.Where(e => e.Id == id).Include(e => e.Roles).ThenInclude(r => r.RoleType).FirstOrDefaultAsync();

        public async Task AddEmployeeAsync(Employee emp)
        {
            emp.Roles.DistinctBy(r => r.RoleTypeId).ToList();
            _context.Employees.Add(emp);
            await Task.FromResult(_context.SaveChangesAsync());
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        {
            var employee = await _context.Employees.Where(e => e.Id == id).Include(e => e.Roles).FirstOrDefaultAsync();
            if (employee != null)
            {
                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                employee.Identity = emp.Identity;
                employee.BirthDate = emp.BirthDate;
                employee.Gender = emp.Gender;
                employee.StartWorkDate = emp.StartWorkDate;
                employee.Roles= emp.Roles.DistinctBy(r => r.RoleTypeId).ToList();
            }
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
                employee.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
