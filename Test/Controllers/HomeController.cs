using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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


        public async Task<IActionResult> Index()
        {
            var pricelists = await context.priceLists.ToListAsync();
            return View(pricelists);
        }

        public IActionResult ShowPriceList(int idPriceList)
        {
            var priceList = context.priceLists.FirstOrDefault(x=>x.id == idPriceList);
            return View(priceList);
        }
        public IActionResult AddingPriceList() 
        {
            return View(new PriceList());
        }
        [HttpPost]
        public async Task<IActionResult> AddPriceList([FromBody]CreatePriceRequest data/*,PriceList priceList*/)
        {
            
            foreach (Column column in data.Columns)
            {
                await context.Columns.AddAsync(column);
            }
            data.Columns.Add(context.Columns.FirstOrDefault(x => x.Name == "Название товара"));
            data.Columns.Add(context.Columns.FirstOrDefault(x => x.Name == "Код товара"));
            var priceList = new PriceList(data.Name);
            foreach (Column column in data.Columns)
                priceList.Columns.Add(column);
            await context.priceLists.AddAsync(priceList);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

   
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}