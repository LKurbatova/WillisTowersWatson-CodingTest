using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Data()
        {
            return PartialView();
        }
    }
}