using System.Diagnostics;
using Business.Service;
using Domain.EF_Models;
using IStore_WEB_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IStore_WEB_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserSerive _service  { get; set;}

        public HomeController(ILogger<HomeController> logger, UserSerive serice)
        {
            _logger = logger;
            _service = serice;
        }

        public IActionResult Index()
        {
            _service.AddUser(new User() { Email = "roma@mail.ru"});
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
      
    }
}