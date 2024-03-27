using Employees.Core.Entities;
using Employees.Core.Repositories;
using System.Data.Entity;

namespace Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context) => _context = context;


        public async Task<IEnumerable<Employee>> GetEmployeesAsync() => await Task.FromResult(_context.Employees.Include(e => e.Roles));

        public async Task<Employee> GetEmployeeAsync(int id) => await Task.FromResult(_context.Employees.Include(e => e.Roles).FirstOrDefault(e => e.Id == id));

        public async Task AddEmployeeAsync(Employee emp)
        {
            _context.Employees.Add(emp);
            emp.Roles.Select(r => r.EmployeeId = emp.Id);
            await Task.FromResult(_context.SaveChangesAsync());
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        {

            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                employee.Identity = emp.Identity;
                employee.BirthDate = emp.BirthDate;
                employee.Gender = emp.Gender;
                employee.StartWorkDate = emp.StartWorkDate;
                employee.Roles = emp.Roles;
                employee.Roles.Select(r => r.EmployeeId = employee.Id);
            }
            await _context.SaveChangesAsync();
            return emp;
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
