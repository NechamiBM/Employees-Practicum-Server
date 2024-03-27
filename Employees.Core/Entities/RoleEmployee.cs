namespace Employees.Core.Entities
{
    public class RoleEmployee
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdministrative { get; set; }
        public int EmployeeId { get; set; }
    }
}
