using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eLearnEnglish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizaldo.Common.ViewModels;
using Quizaldo.Models;
using Quizaldo.Services.Interfaces;
using Quizaldo.Web.Models;
using ReflectionIT.Mvc.Paging;

namespace Quizaldo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager = null;
        private readonly IMapper mapper;
        private readonly IQuizService quizService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IQuizService quizService, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.quizService = quizService;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var quizzes = (await this.quizService.AllQuizzes())
                .Select(mapper.Map<AllQuizzesViewModel>);

            var pagedQuizzes = PagingList.Create(quizzes, 8, page);

            return this.View(pagedQuizzes);
        }
        public IActionResult Main()
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            return View();
        }
        public IActionResult ManageSiteData()
        {
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
