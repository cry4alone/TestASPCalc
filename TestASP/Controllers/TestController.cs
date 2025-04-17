using Microsoft.AspNetCore.Mvc;
using TestASP.Models;
using TestLibrary;

namespace TestASP.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Greet(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Content("Имя не указано!");
            }
            return Content($"Привет, {name}!");
        }

        public IActionResult UserInfo()
        {
            var user = new User { Name = "Иван Иванов", Age = 30 };
            return View(user);
        }

        public IActionResult Calculator(string operation, string num1, string num2)
        {
            try
            {
                if (!double.TryParse(num1, out double number1) || !double.TryParse(num2, out double number2))
                {
                    return Content("Ошибка: Введите корректные числа.");
                }

                double result = 0;

                switch (operation)
                {
                    case "plus":
                        result = MathLibrary.Add(number1, number2);
                        break;

                    case "minus":
                        result = MathLibrary.Subtract(number1, number2);
                        break;

                    case "multiply":
                        result = MathLibrary.Multiply(number1, number2);
                        break;

                    case "sqrt":
                        result = MathLibrary.Sqrt((int)number1);
                        break;

                    default:
                        return Content("Ошибка: Неизвестная операция.");
                }
                return Content($"Результат: {result}");
            }
            catch (Exception ex)
            {
                return Content($"Ошибка: {ex.Message}");
            }
        }
    }
}