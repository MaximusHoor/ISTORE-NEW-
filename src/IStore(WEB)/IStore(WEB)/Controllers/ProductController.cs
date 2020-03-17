using Business.Service;
using Domain.EF_Models;
using IStore_WEB_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IStore_WEB_.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productservice;

        public ProductController(ILogger<ProductController> logger, ProductService productservice)
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

        public IActionResult ProductPartial(Product product)
        {
            return View(product);
        }

        public async Task<IActionResult> GetProductDetails(Product product)
        {
            var res = await _productservice.GetByIdsync(1);


            return PartialView("ProductDetails", res);
        }
        public async Task<IActionResult> Product(int id)
        {
            var res = await _productservice.GetByIdsync(1);

            return View("Product", res);
        }
        [Route("Products/{categoryTitle?}")]
        public IActionResult GetProductFromCategory(string categoryTitle)
        {
            var res = _productservice.GetAllAsync().Result;
            if (categoryTitle != null)
            {
                 res = _productservice.FindByConditionAsync(x => x.Category.Title == categoryTitle).Result;
            }         

            return View(res);
        }
    }
}
