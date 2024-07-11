using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddingPriceList() 
        {
            return View();
        }

   
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}