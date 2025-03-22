using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Filters
{
    public class MyFilter : Attribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Filter Executed after action executed");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Filter Executing before action execute");
        }
    }
}
