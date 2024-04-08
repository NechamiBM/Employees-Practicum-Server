namespace Employees.Core.Entities
{
    public class Role
    {
        public RoleType RoleType { get; set; }
        public int RoleTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdministrative { get; set; }
        public int EmployeeId { get; set; }
    }
}