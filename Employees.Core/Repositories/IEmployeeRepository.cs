using Employees.Core.Entities;

namespace Employees.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task AddEmployeeAsync(Employee emp);
        Task<Employee> UpdateEmployeeAsync(int id, Employee emp);
        Task DeleteEmployeeAsync(int id);
    }
}
