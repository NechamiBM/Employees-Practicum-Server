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
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Identity must contain exactly 9 digits.")]
        public string Identity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidateStartWorkDate(ErrorMessage = "Start work date cannot be a future date.")]
        public DateTime StartWorkDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidateBirthDate(ErrorMessage = "Birth date must be at least 16 years ago.")]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [ValidateRoleStartDatesAttribute(ErrorMessage = "Role start date cannot be before employee's start work date.")]
        public List<RolePostModel> Roles { get; set; }
    }


    public class ValidateBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthDate = (DateTime)value;
            if (birthDate > DateTime.Now.AddYears(-16))
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }

    public class ValidateStartWorkDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startWorkDate = (DateTime)value;
            if (startWorkDate >= DateTime.Now)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }

    public class ValidateRoleStartDatesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var roles = value as List<RolePostModel>;
            if (roles == null)
                return ValidationResult.Success; 
            var employeePostModel = validationContext.ObjectInstance as EmployeePostModel;
            if (employeePostModel == null)
                return new ValidationResult("Invalid employee data.");
            if (roles.Any(role => role.StartDate < employeePostModel.StartWorkDate))
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
}
