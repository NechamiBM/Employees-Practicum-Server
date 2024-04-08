using System.ComponentModel.DataAnnotations;

namespace Employees.API.Models
{
    public class RolePostModel
    {
        [Required]
        public int RoleTypeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public bool IsAdministrative { get; set; }
    }
}