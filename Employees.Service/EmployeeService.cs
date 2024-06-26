﻿using Employees.Core.Entities;
using Employees.Core.Repositories;
using Employees.Core.Services;

namespace Employees.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(string? filter)
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return employees.Where(employee => employee.IsActive == true && (filter == null ||
                (employee.FirstName != null && employee.FirstName.Contains(filter, StringComparison.OrdinalIgnoreCase)) ||
                (employee.LastName != null && employee.LastName.Contains(filter, StringComparison.OrdinalIgnoreCase)) ||
                (employee.Identity != null && employee.Identity.Contains(filter, StringComparison.OrdinalIgnoreCase)) ||
                (employee.Roles != null && employee.Roles.Any(role => (role.RoleType.Name != null && role.RoleType.Name.Contains(filter, StringComparison.OrdinalIgnoreCase))))));
        }

        public async Task<Employee> GetEmployeeAsync(int id) => await _employeeRepository.GetEmployeeAsync(id);

        public async Task AddEmployeeAsync(Employee emp)
        {
            emp.IsActive = true;
            emp.Roles=emp.Roles.DistinctBy(r => r.RoleTypeId).ToList();
            await _employeeRepository.AddEmployeeAsync(emp);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp) => await _employeeRepository.UpdateEmployeeAsync(id, emp);

        public void DeleteEmployee(int id) => _employeeRepository.DeleteEmployeeAsync(id);
    }
}
