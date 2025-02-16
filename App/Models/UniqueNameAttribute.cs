using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        AppDbContext _context = new AppDbContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();
            Employee emp = _context.Employees.FirstOrDefault(e => e.Name == name);
            if (emp == null) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Found");
        }
    }
}
