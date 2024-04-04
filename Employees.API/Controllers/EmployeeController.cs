using AutoMapper;
using Employees.API.Models;
using Employees.Core.DTOs;
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
            var employees = await _employeeService.GetEmployeesAsync(filter);
            var employeeDtos = employees.Select(e => _mapper.Map<EmployeeDto>(e));//_mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            if (employee == null)
                return NotFound();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeePostModel emp)
        {
            var employeeToAdd = _mapper.Map<Employee>(emp);
            employeeToAdd.Roles = emp.Roles.Select(role => _mapper.Map<Role>(role)).ToList();
            _employeeService.AddEmployeeAsync(employeeToAdd);
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeePostModel emp)
        {
            var employee = _mapper.Map<Employee>(emp);
            var updatedEmp = await _employeeService.UpdateEmployeeAsync(id,employee);
            var empDto= _mapper.Map<EmployeeDto>(updatedEmp);
            return Ok(empDto);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}