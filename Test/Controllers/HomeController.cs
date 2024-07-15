using Microsoft.AspNetCore.Mvc;
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
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddingPriceList() 
        {
            return View(new Column());
        }
        [HttpPost]
        public JsonResult AddPriceList(Column column/*,PriceList priceList*/)
        {
            //List<Column> columns= new List<Column>();
            //for (int i=0;i<=Request.Form.Count;i++) 
            //{
            //    var Name = Request.Form["Name[" + i + "]"];
            //    var DataType = Request.Form["DataType[" + i + "]"];
            //    if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(DataType))
            //    {
            //        Column column = new Column { Name = Name, DataType = DataType };
            //        columns.Add(column);
            //        await context.Columns.AddAsync(column);
            //    }
            //}
            ////await context.priceLists.AddAsync(priceList = new PriceList( priceList.Name, columns ));
            ////context.SaveChanges();
            //return Ok();
            return Json(column);


        }

   
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}