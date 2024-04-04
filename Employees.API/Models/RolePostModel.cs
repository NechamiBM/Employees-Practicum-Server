using Employees.Core.Entities;

namespace Employees.API.Models
{
    public class RolePostModel
    {
        public int RoleTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdministrative { get; set; }
    }
}
