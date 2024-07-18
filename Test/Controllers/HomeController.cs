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

        CreateProductRequest productRequest = new CreateProductRequest();
        public async Task<IActionResult> Index()
        {
            var pricelists = await context.priceLists.ToListAsync();
            return View("Index",pricelists);
        }

        public async Task<IActionResult> ShowPriceList(int idPriceList)
        {
            productRequest.priceList = await context.priceLists.Include(list => list.Columns)
                .Include(list=>list.Products)
                .ThenInclude(prod=>prod.descriptions)
                .FirstOrDefaultAsync(list => list.Id == idPriceList);
            
            return View(productRequest);
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
            var priceList = new PriceList(data.Name);
            await context.priceLists.AddAsync(priceList);
            data.Columns.Add(context.Columns.FirstOrDefault(context=>context.Id == 1));
            data.Columns.Add(context.Columns.FirstOrDefault(context => context.Id == 2));
            priceList.Columns.AddRange(data.Columns);
            

            await context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> AddProduct(Product product,string priceListName,Description? description)
        {
            var priceList = await context.priceLists.Include(list => list.Columns)
                                           .FirstOrDefaultAsync(list => list.Name == priceListName);
            await context.Products.AddAsync(product);
            if (description != null)
            {

                await context.descriptions.AddAsync(description);
                product.descriptions.Add(description);
                

            }
            priceList.Products.Add(product);
            await context.SaveChangesAsync();
            return RedirectToAction("ShowPriceList", new { idPriceList = priceList.Id });


        }

   
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}