using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BindController : Controller
    {
        //Model Binding
        // Bind Primative Type
        public IActionResult testprimative(int id, string name)
        {
            return Content($"the name is {name} and the id is {id}");
        }
        // Bind custom or complex type 
        public IActionResult testcomplex(Department dept)
        {
            return Content("Ok");
        }
    }
}
