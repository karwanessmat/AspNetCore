using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DealDouble.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DealDouble.Web.Models;
using DealDouble.Web.ViewModels.Production;

namespace DealDouble.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductionRepository _productionRepository;

        public HomeController(ILogger<HomeController> logger, IProductionRepository productionRepository)
        {
            _logger = logger;
            _productionRepository = productionRepository;
        }


        public async Task<IActionResult> Index()
        {
            var productions = await _productionRepository.GetAllAsync();

            var model = new HomeProductionViewModel()
            {
                Last3Productions =await _productionRepository.GetLast3Production(),
                Productions = productions

            };

            return View(model);
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
