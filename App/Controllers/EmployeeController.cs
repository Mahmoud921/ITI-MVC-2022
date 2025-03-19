using App.Models;
using App.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class EmployeeController : Controller
    {
        //AppDbContext _context = new AppDbContext();
        IEmployeeRepository _empRepo;
        IDepartmentRepository _deptRepo;
        public EmployeeController(IEmployeeRepository EmpRepo, IDepartmentRepository DeptRepo)
        {
            _empRepo = EmpRepo;
            _deptRepo = DeptRepo;
        }
        public IActionResult Index()
        {
            var emp =_empRepo.GetAll();
            return View(emp);
        }

        //Add New Employee
        [HttpGet]
        public IActionResult New()
        {
            ViewData["deptList"] = _deptRepo.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _empRepo.Insert(emp);
                    return RedirectToAction("Index");
                }
                catch (Exception ex) {
                    ModelState.AddModelError(String.Empty,ex.Message.ToString());
                }
                
            }
            ViewData["deptList"] = _deptRepo.GetAll();
            return View("New",emp);
        }

        // Edit Employee
        public IActionResult Edit(int id)
        {
            var emp = _empRepo.GetById(id);
            ViewData["deptList"]= _deptRepo.GetAll();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(int id,Employee newEmp)
        {
            if (ModelState.IsValid) // validation server side
            {
                _empRepo.Update(id,newEmp);
                  return RedirectToAction("Index");  
            }
            ViewData["deptList"] = _deptRepo.GetAll();
            return View("Edit",newEmp);
        }
    }
}
