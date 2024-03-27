using AutoMapper;
using Employees.API.Models;
using Employees.Core.Entities;
using Employees.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get(string? filter)
        {
            return Ok(await _employeeService.GetEmployeesAsync(filter));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeePostModel emp)
        {
            var employee = _mapper.Map<Employee>(emp);
            _mapper.Map<List<RoleEmployee>>(emp.Roles);
            employee.Roles = _mapper.Map<List<RoleEmployee>>(emp.Roles);
            _employeeService.AddEmployeeAsync(employee);
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee emp)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, emp);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}