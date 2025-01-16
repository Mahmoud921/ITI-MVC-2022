using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        // Why use virtual ? when create object, dont create new object , it use old reference
        public virtual Department? Department { get; set; }

    }
}
