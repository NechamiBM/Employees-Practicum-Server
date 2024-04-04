using Employees.Core.Entities;

namespace Employees.API.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public List<RolePostModel> Roles { get; set; }
    }
}
