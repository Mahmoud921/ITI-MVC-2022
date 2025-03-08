using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class RouteController : Controller
    {
        //Test Routing
        public IActionResult Index(string name)
        {
            return Content(name);
        }
    }
}
