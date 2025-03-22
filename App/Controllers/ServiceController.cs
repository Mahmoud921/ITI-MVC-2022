using App.Filters;
using App.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    // [MyFilter]    filter works on this all controller methods
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
        [MyFilter]
        public IActionResult test() {
            return Content("Hello");
        }

    }
}
