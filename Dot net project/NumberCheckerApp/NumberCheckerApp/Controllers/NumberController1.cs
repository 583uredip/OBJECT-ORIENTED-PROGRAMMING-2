using Microsoft.AspNetCore.Mvc;

namespace NumberCheckerApp.Controllers
{
    public class NumberController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
       public  IActionResult CheckEvenOdd (int number)
        {
            string result;
            if (number % 2 == 0)
            {
                result = $"{number} is  an Even number";
            }
            else
            {
                result = $"{number} is Odd number";
            }
            ViewBag.Result = result;
            ViewBag.Number = number;
            return View("Result");
        }

    }
}
