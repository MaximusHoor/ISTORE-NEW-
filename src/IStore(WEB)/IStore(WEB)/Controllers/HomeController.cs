using Business.Service;
using Domain.EF_Models;
using IStore_WEB_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IStore_WEB_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productservice;

        public HomeController(ILogger<HomeController> logger, ProductService productservice)
        {
            _logger = logger;
            _productservice = productservice;
        }

        public async Task<IActionResult> Index()
        {            
            var result = await _productservice.GetSortByRatingAsync(24);

            return View(result);
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

        public async Task<IActionResult> ProductPartial(Product product)
        {
            return View(product);
        }

        public async Task<IActionResult> GetProductDetails(int id)
        {
            var res = await _productservice.GetByIdsync(id);
            return PartialView("ProductDetails", res);
        }
    }
}