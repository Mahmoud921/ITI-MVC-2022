using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [RegularExpression(@"[a-z]+\.(jpg|png)")]
        public string? Image { get; set; }

        public string Email { get; set; }

        [RegularExpression(@"[0-9]{4}")]
        [Range(2000, 7000)]
        [Required]
        public int Salary { get; set; }

        [RegularExpression("(Fayoum|Cairo|Alex|Sohag)")]
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        // Why use virtual ? when create object, dont create new object , it use old reference
        public virtual Department? Department { get; set; }

    }
}
