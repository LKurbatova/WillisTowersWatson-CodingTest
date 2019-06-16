using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    public class FizzBuzzController : Controller
    {
        public IActionResult Index()
        {
            var fizzBuzzList = new List<string>();
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    fizzBuzzList.Add("FizzBuzz");
                    continue;
                }
                if (i % 3 == 0)
                {
                    fizzBuzzList.Add("Fizz");
                    continue;
                }
                if (i % 5 == 0)
                {
                    fizzBuzzList.Add("Buzz");
                    continue;
                }
                fizzBuzzList.Add(i.ToString());
            }

            ViewData["fizzBuzzArray"] = fizzBuzzList.ToArray();
            return View();
        }

       
    }
}