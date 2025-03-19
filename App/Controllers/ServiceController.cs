using App.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ServiceController : Controller
    {
        IEmployeeRepository _empRepo;
        public ServiceController(IEmployeeRepository EmpRepo)
        {
            _empRepo = EmpRepo;
        }
        public IActionResult Index()
        {
            ViewBag.ID = _empRepo.Id;
            return View();
        }
    }
}
