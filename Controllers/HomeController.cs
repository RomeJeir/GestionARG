using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
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

     public IActionResult VerEmpleado(int IdEmpleado)
        {

            string cadena = @"Server=A-LUM-13;DataBase=GestionARG;Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(cadena);
            SqlDataAdapter da = new SqlDataAdapter("SELECT NOMBRE, DNI, AREA FROM Empleados",con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return View("Index", dt);

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
