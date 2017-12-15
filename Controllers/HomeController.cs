using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using amazonAPI.Models;
using Connection.Model;
using Newtonsoft.Json.Linq;


namespace amazonAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string cathegory, string subcathegory)
        {
            ConnectToDB newConn = new ConnectToDB();
            List<Items> str = new List<Items>(); 
            str = newConn.GetDataFromDB("SELECT * FROM items");
            ViewBag.items = str;
            return View();
        }

        public IActionResult Aktier()
        {
            string url = "https://www.alphavantage.co/query?apikey=8WNFUGZVZJ3MCVFR&function=TIME_SERIES_DAILY_ADJUSTED&symbol=";
            var response = new WebClient().DownloadString(url + "PDX.ST");
            var stockdata = JObject.Parse(response); 
            //Console.WriteLine(stockdata);
            ViewData["Title"] = stockdata["Meta Data"]["2. Symbol"];
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
