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
    public class AccountController : Controller
    {
        public IActionResult Webadmin(string cathegory, string subcathegory)
        {
            return View();
        }
    }
}