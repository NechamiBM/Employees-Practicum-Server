using System.ComponentModel.DataAnnotations;

namespace Employees.API.Models
{
    public class RoleTypePostModel
    {
        [Required]
        public string Name { get; set; }
    }
}