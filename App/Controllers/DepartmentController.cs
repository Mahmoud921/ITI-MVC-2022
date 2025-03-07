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
        public IActionResult ShowEmpDepartment()
        {
            List<Department> deptList = _context.Departments.ToList();
            return View(deptList);
        }
        // Department/GetEmpForDepartment?deptId=1
        public IActionResult GetEmpForDepartment(int deptId) {
            List<Employee> emps = _context.Employees.Where(e => e.DeptId == deptId).ToList();
            return Json(emps);
        }
        // opent embty form
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Department dept)
        {
            if(dept.Name != null)
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New",dept);
        }
    }
}
