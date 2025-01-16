using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            List<Department> department= _context.Departments.Include(d => d.Employees).ToList();
            return View(department);
        }
    }
}
