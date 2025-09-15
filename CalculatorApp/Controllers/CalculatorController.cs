using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        private static List<string> History = new List<string>();

        public IActionResult Index()
        {
            return View(History);
        }

        [HttpPost]
        public IActionResult Calculate(double x, double y, string op)
        {
            double result = 0;
            string expression = "";

            switch (op)
            {
                case "+": result = x + y; break;
                case "-": result = x - y; break;
                case "*": result = x * y; break;
                case "/": result = y != 0 ? x / y : 0; break;
            }

            expression = $"{x} {op} {y} = {result}";
            History.Insert(0, expression);

            return RedirectToAction("Index");
        }
    }
}
