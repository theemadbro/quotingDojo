using System;
using DbConnection;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Models;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            List<Dictionary<string, object>> LastUser = DbConnector.Query("SELECT * FROM users ORDER BY ID DESC LIMIT 1");
            ViewBag.test = LastUser;
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(Quotes inp)
        {
            
            if(ModelState.IsValid)
            {
                string current = DateTime.Now.ToString("dddd, MMM dd, yyyy - HH:mm:ss tt");
                DbConnector.Query($"INSERT INTO `test2`.`users` (`name`, `quote`) VALUES ('{inp.Name}', '{inp.Quote}');");
                return RedirectToAction("quotes");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users ORDER BY ID DESC");
            ViewBag.all = AllUsers;
            return View("quotes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
