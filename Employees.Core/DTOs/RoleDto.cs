using Employees.Core.Entities;
namespace Employees.Core.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public RoleType Role { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdministrative { get; set; }
    }
}
