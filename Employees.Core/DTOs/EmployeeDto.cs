using Employees.Core.Entities;

namespace Employees.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public List<Role> Roles { get; set; }
        public bool IsActive { get; set; } 
    }
}
