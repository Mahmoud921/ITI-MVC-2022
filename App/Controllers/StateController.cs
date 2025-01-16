using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class StateController : Controller
    {
        public IActionResult setcookie()
        {
            CookieOptions cook = new CookieOptions();
            cook.Expires = DateTimeOffset.Now.AddHours(2);
            Response.Cookies.Append("name", "Ali",cook);
            Response.Cookies.Append("age", "20");
            return Content("Cookies saved");
        }
        public IActionResult getcookie()

        {
            string name = Request.Cookies["name"];
            int age = int.Parse(Request.Cookies["age"]);
            return Content($"Cookies saved and name is {name} and age is {age}");
        }
        public IActionResult setsession()
        {
            HttpContext.Session.SetString("name", "mahmoud");
            HttpContext.Session.SetInt32("age",22);

            return Content("Data Saved");
        }
        public IActionResult getsession()
        {
            string userName = HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"User Name Is {userName} and age is {age}");
        }
        public IActionResult set()
        {
            TempData["msg"] = "Hello World";
            return Content("Data saved");
        }
        public IActionResult get1() {
            string message = TempData.Peek("msg") as string;
            return Content(message);
        }
        public IActionResult get2() {
            string messge = TempData["msg"] as string;
            TempData.Keep("msg");
            return Content(messge);
        }
    }
}
