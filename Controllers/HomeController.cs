using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestionARG.Models;

namespace GestionARG.Controllers;

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

   /*  public IActionResult VerPersona(int IdEmpleado)
        {
            InitEspecialidades(); <======= QUE PIJA ES ESTO
            var persona = BD.ConsultaEmpleado(IdEmpleado);
            ViewBag.UnEmpleado = empleado;
            ViewBag.UnaEspecialidad = BD.ConsultaEspecialidad(curso.IdEspecialidad);  <===== AVERIGUAR SI NECESITAMOS
            return View("Index");
        } */
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
