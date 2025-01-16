using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ProductController : Controller
    {
        ProductSambleData sample = new ProductSambleData();
        public IActionResult ShowAll()
        {
            List<Product> productList = sample.GetProducts();
            return View("showall",productList);
        }
        public IActionResult ShowProduct(int id)
        {
            Product res = sample.GetProduct(id);
            return View("showproduct",res);
        }
    }
}
