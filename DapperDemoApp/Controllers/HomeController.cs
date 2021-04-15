using DapperDemoApp.Models;
using DapperDemoApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdvanceRepository _advanceRepository;
        public HomeController(ILogger<HomeController> logger, IAdvanceRepository advanceRepository)
        {
            _logger = logger;
            _advanceRepository = advanceRepository;
        }

        public IActionResult Index()
        {
            var output1 = _advanceRepository.GetCompanyWithEmployees();
            var output2 = _advanceRepository.GetCompanyWithAddress(1);
            
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
