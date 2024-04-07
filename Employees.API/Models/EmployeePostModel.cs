using Employees.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Employees.API.Models
{
    public class EmployeePostModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required]
       // [RegularExpression(9[0-9])]
        public string Identity { get; set; }
        [Required]
        public DateTime StartWorkDate { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public List<RolePostModel> Roles { get; set; }
    }
}
