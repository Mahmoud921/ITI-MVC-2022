using App.Models;
using App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace App.Controllers
{
    public class DepartmentController : Controller
    {
        //AppDbContext _context = new AppDbContext();
        
        DepartmentRepository _deptRepo = new DepartmentRepository();
        EmployeeRepository _empRepo = new EmployeeRepository();

        public IActionResult Index()
        {
            List<Department> department = _deptRepo.GetAllWithEmp();
            return View(department);
        }
        public IActionResult ShowEmpDepartment()
        {
            List<Department> deptList = _deptRepo.GetAll();
            return View(deptList);
        }
        // Department/GetEmpForDepartment?deptId=1
        public IActionResult GetEmpForDepartment(int deptId) {
            List<Employee> emps = _empRepo.GetByDeptId(deptId);
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
                _deptRepo.Insert(dept);
                return RedirectToAction("Index");
            }
            return View("New",dept);
        }
    }
}
