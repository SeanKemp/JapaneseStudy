using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JapaneseStudy.Models;
using JapaneseStudy.Classes;

namespace JapaneseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Config;

        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            Config = iConfig;
        }

        public IActionResult Index()
        {
            //Person p = new Person(1, Config);
            //Kanji kanji = new Kanji(1, Config);
            //kanji.FillKanjiById(1, Config);
            //KanjiReviews reviews = new KanjiReviews(p, Config); 
            //ViewData["Test"] = $"Username: {p.Username}, Kanji: {reviews.Reviews[0].KanjiChar.KanjiChar}";
            return View();  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
