using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        // ใช้ static list เก็บประวัติการคำนวณ
        private static List<string> History = new List<string>();

        // GET: /Calculator/Index
        public IActionResult Index()
        {
            return View(History);
        }

        // POST: /Calculator/Calculate
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
            History.Insert(0, expression); // เก็บผลไว้ด้านบนสุด

            return RedirectToAction("Index");
        }
    }
}
