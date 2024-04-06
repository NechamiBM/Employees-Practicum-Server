using Employees.Core.Entities;
namespace Employees.Core.DTOs
{
    public class RoleDto
    {
        public RoleType RoleType { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdministrative { get; set; }
    }
}
