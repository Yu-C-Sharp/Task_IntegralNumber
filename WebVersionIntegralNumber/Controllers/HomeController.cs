using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebVersionIntegralNumber.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClassLibraryNumber;
using DatabaseConnection;
using ConsoleDataEntryAndProcessing;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Microsoft.AspNetCore.Http;


namespace WebVersionIntegralNumber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        ApplicationContext db = new ApplicationContext(CreateOptions.JSON_FILE_Configuration());
        public IActionResult Index()
        {
            DbMethodes query = new DbMethodes();
            ViewBag.Numbers = query.UploadFromDbLastFiveResults();
            return View();
        }
        [HttpGet]

        [HttpPost]
        public ActionResult Result(int Number)
        {
            ControlInput num = new ControlInput();
            if (!num.Check(Number.ToString())) return RedirectToAction("Index");
            Number Input = new Number() { Num = Number };
            Calculate Calculator = new Calculate();
            Calculator.Squaring(Input);
            db.Numbers.Add(Input);
            db.SaveChanges();
            ViewBag.Number = Input;
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
