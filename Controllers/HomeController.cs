using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        ProductContext db;
        public HomeController(ProductContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            //return View(await db.Products.ToListAsync());
            return View();
        }

        //public JavaScript UpdatePage()
        //{
        //    var script = "window.location ='" + Url.Action("ShowResult", "Quiz") + "' ;";
        //    return JavaScript(script);
        //}




        //public async Task<IActionResult> Index()
        //{
        //    return View(await db.Products.ToListAsync());

        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("/api/products")]
        public async Task<IResult> GetProducts()
        {
            return Results.Json(await db.Products.ToListAsync());
        }
        [Route("api/product/{id:int}")]
        public async Task<IResult> Get(int? id)
        {
            if (id != null)
            {
                Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null) return Results.Json(product);
            }
            return Results.NotFound();
        }



        //асинхронные версии методов
        [HttpDelete]
        [Route("api/delete/{id:int}")]
        //public async Task<IResult> Delete(int id)
        public async Task<IResult> Delete(int id)
        {
            //if (id != null)
            //{
            Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            //}
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Results.Json(product);
            //return RedirectToAction("Index");
            //return View("Index");
        }

        [HttpPut]
        [Route("api/edit")]
        public async Task<IResult> Edit([FromBody] Product product)
        //public async Task<IResult> Edit(int id, string name, string url)
        {
            // получаем товар по id
            var prod = await db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            //var prod = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            // если не найден, отправляем статусный код и сообщение об ошибке
            if (prod == null) return Results.NotFound(new { message = "Пользователь не найден" });
            //product.MarketName = product.Name;
            //product.Date = DateTime.Now;
            prod.Name = product.Name;
            prod.Url = product.Url;
            db.Products.Update(prod);
            await db.SaveChangesAsync();
            return Results.Json(prod);
            //return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("api/create")]
        //public async Task<IActionResult> Create(string prName, string prUrl)
        public async Task<IResult> Create([FromBody] Product product)
        {
            //product.MarketName = product.Name;
            //product.Date = DateTime.Now;
            Product prod1 = new Product();

            prod1.Name = product.Name;
            prod1.Url = product.Url;
            db.Products.Add(prod1);
            Price pr1 = new Price { MarketName = prod1.Name, Date = DateTime.Now, Product = prod1, MarketPrice = 1 };
            db.Prices.Add(pr1);
            await db.SaveChangesAsync();
            //return RedirectToAction("Index");
            return Results.Json(pr1);
        }


        ////синхронные версии
        //[HttpDelete]
        //[Route("api/delete/{id:int}")]
        ////public async Task<IResult> Delete(int id)
        ////public IResult Delete(int id)
        //public IActionResult Delete(int id)
        //{
        //    //if (id != null)
        //    //{
        //    Product? product = db.Products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        //return Results.NotFound(new { message = "Пользователь не найден" });
        //    }
        //    //}

        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //    //return RedirectToAction("Index");
        //    //return View("Index");
        //}

        //[HttpPut]
        //[Route("api/edit")]
        //public IResult Edit([FromBody] Product product)
        ////public async Task<IResult> Edit(int id, string name, string url)
        //{
        //    // получаем товар по id
        //    var prod = db.Products.FirstOrDefault(p => p.Id == product.Id);
        //    //var prod = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        //    // если не найден, отправляем статусный код и сообщение об ошибке
        //    if (prod == null) return Results.NotFound(new { message = "Пользователь не найден" });


        //    //product.MarketName = product.Name;
        //    //product.Date = DateTime.Now;

        //    prod.Name = product.Name;
        //    prod.Url = product.Url;

        //    //prod.Name = name;
        //    //prod.Url = url;

        //    //db.Products.Update(product);
        //    db.Products.Update(prod);
        //    db.SaveChanges();
        //    return Results.Json(prod);
        //    //return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[Route("api/create")]
        ////public async Task<IActionResult> Create(string prName, string prUrl)
        //public IActionResult Create([FromBody] Product product)
        //{
        //    //product.MarketName = product.Name;
        //    //product.Date = DateTime.Now;
        //    Product prod1 = new Product();
        //    //prod1.Name = prName;
        //    //prod1.Url = prUrl;
        //    prod1.Name = product.Name;
        //    prod1.Url = product.Url;
        //    db.Products.Add(prod1);
        //    Price pr1 = new Price { MarketName = prod1.Name, Date = DateTime.Now, Product = prod1, MarketPrice = 1 };
        //    db.Prices.Add(pr1);
        //    db.SaveChanges();
        //    //if (ModelState.IsValid)
        //    //{
        //    //    return RedirectToAction("Index");
        //    //}
        //    //return RedirectToAction("Create");

        //    return RedirectToAction("Index");

        //}










        //[HttpGet]
        ////route get
        ////[Route("Home/Edit/{id:int}")]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id != null)
        //    {
        //        Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        //        if (product != null) return View(product);
        //    }
        //    return NotFound();
        //}


        //[HttpPost]
        //public async Task<IActionResult> Create(Product product)
        //{
        //    //product.MarketName = product.Name;
        //    //product.Date = DateTime.Now;
        //    db.Products.Add(product);
        //    Price pr1 = new Price { MarketName = product.Name, Date = DateTime.Now, Product = product, MarketPrice = 1 };
        //    db.Prices.Add(pr1);
        //    await db.SaveChangesAsync();
        //    //if (ModelState.IsValid)
        //    //{
        //    //    return RedirectToAction("Index");
        //    //}
        //    //return RedirectToAction("Create");

        //        return RedirectToAction("Index");

        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        //        if (product != null)
        //        {
        //            db.Products.Remove(product);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return NotFound();
        //}
        //public async Task<IActionResult> Edit(Product product)
        //{
        //    //product.MarketName = product.Name;
        //    //product.Date = DateTime.Now;
        //    db.Products.Update(product);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

    }
}