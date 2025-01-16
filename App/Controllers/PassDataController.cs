using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.ViewModel;

namespace App.Controllers
{
    public class PassDataController : Controller
    {
        AppDbContext _context = new AppDbContext();

        public IActionResult testview(int id)
        {
            var extramodel = new ExtraInfoEmpAndDeptViewModel();
            var empModel = _context.Employees.FirstOrDefault(e => e.Id == id);
            string msg = "Hellow world";
            int age = 50;
            extramodel.Message = msg;
            extramodel.Age = age;


            return View(extramodel);
        }
    }
}
