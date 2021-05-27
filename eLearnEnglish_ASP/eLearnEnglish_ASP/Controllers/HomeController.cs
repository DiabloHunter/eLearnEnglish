using eLearnEnglish_ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Controllers
{

    

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            return View();
        }
        public IActionResult AllCources()
        {
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
