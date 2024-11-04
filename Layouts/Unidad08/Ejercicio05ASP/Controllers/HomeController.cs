using Ejercicio05ASP.Models;
using Ejercicio05DAL;
using Ejercicio05ENT;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio05ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListadoPersonas()
        {
            List<ClsPersona> lista = ClsListadoPersonas.getListadoCompletoPersonas();
            return View(lista);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
