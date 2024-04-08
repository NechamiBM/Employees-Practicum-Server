using AutoMapper;
using Employees.Core.Entities;
using Employees.Core.Services;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService) => _roleService = roleService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleType role)
        {
            await _roleService.AddRoleAsync(role);
            return Ok();
        }
    }
}