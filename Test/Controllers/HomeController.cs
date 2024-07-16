using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Test.Domain;
using Test.Domain.Entites;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly PriceContext context;
        public HomeController(PriceContext context) 
        {
            this.context = context;
        } 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pricelists = await context.priceLists.ToListAsync();
            return View(pricelists);
        }
        public IActionResult AddingPriceList() 
        {
            return View(new PriceList());
        }
        [HttpPost]
        public async Task<IActionResult> AddPriceList([FromBody] CreatePriceRequest data/*,PriceList priceList*/)
        {
            foreach (Column column in data.Columns)
            {
                await context.Columns.AddAsync(column);
            }

            await context.priceLists.AddAsync(new PriceList(data.Name, data.Columns));
            await context.SaveChangesAsync();

            return Ok();


        }

   
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}