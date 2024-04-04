using Employees.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entities
{
    public enum Gender { Male, Female }
    public class Employee
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
