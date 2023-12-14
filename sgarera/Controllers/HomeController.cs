using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using sgarera.Models;
using sgarera.Servicios;
using System.Diagnostics;

namespace sgarera.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfazCrud crud;
        public HomeController(ILogger<HomeController> logger, InterfazCrud crud)
        {
            _logger = logger;
            this.crud = crud;
        }

        public IActionResult Index()
        {
            int opcion;
            bool seguir = true;
            do
            {
                Console.WriteLine("1. Dar de alta Elemento");
                Console.WriteLine("2. Mostrar Stock");
                Console.WriteLine("3. Salir");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            crud.CrearElemento();
                            break;
                        case 2:
                            crud.MostrarStock();
                            break;
                        case 3:
                            Console.WriteLine("Saliendo del programa.");
                            seguir = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            seguir = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Introduce un número.");
                }
            } while (seguir);
            
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