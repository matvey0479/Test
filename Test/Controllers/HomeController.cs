﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        CreateProductRequest productRequest = new CreateProductRequest();
        PriceListColumns listColumns = new PriceListColumns();
        public async Task<IActionResult> Index()
        {
            var pricelists = await dataManager.priceLists.GetPriceListsAsync();
            return View("Index", pricelists);
        }

        public async Task<IActionResult> ShowPriceList(int idPriceList)
        {
            productRequest.priceList = await dataManager.priceLists.GetPriceListByIdAsync(idPriceList);
            return View(productRequest);
        }
        public async Task<IActionResult> AddingPriceList()
        {
            listColumns.columns = await dataManager.columns.GetColumnsAsync();
            return View(listColumns);
        }
        [HttpPost]
        public async Task<IActionResult> AddPriceList([FromBody] CreatePriceRequest data/*,PriceList priceList*/)
        {
            foreach (Column column in data.Columns)
            {
                await dataManager.columns.AddColumnAsync(column);
            }
            var priceList = new PriceList(data.Name);
            var columns = new List<Column>();
            foreach (var col in data.Columns)
            {
                columns.Add(await dataManager.columns.GetColumnsByNameAndDataTypeAsync(col.Name, col.DataType));
            }

            columns.Add(await dataManager.columns.GetColumnsByIdAsync(1));
            columns.Add(await dataManager.columns.GetColumnsByIdAsync(2));
            await dataManager.priceLists.AddPriceListAsync(priceList, columns);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> AddProduct(Product product, int idPriceList, List<Description>? descriptions)
        {

            var priceList = await dataManager.priceLists.GetPriceListColumnsByIdAsync(idPriceList);
            await dataManager.products.AddProductAsync(priceList, product, descriptions);
            return RedirectToAction("ShowPriceList", new { idPriceList = priceList.Id });
        }

        public async Task<IActionResult> DeleteProduct(int id, int priceid)
        {
            var list = await dataManager.priceLists.GetPriceListByIdAsync(priceid);
            await dataManager.products.DeleteProductAsync(list, id);
            return Ok();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}