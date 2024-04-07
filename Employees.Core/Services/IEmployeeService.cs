using Employees.Core.Entities;

namespace Employees.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(string? filter);
        Task<Employee> GetEmployeeAsync(int id);
        Task<bool> AddEmployeeAsync(Employee emp);
        Task<Employee> UpdateEmployeeAsync(int id, Employee emp);
        void DeleteEmployee(int id);
    }
}
