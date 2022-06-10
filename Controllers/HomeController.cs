using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;
using GestionARG.Models;

namespace GestionARG.Controllers{

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerEmpleados(int IdEmpleado)
        {
            DataTable dt = BaseDatos.VerEmpleados();
            return View(dt);

        }

    public IActionResult ControlEmpleados()
    {
        return View();
    }

    public IActionResult DepartamentoVentas()
    {
        return View();
    }

    public IActionResult DepartamentoAdministracion()
    {
        return View();
    }

    public IActionResult SubidaTareas()
    {
        
        return View();
    }

    public IActionResult SubidaEmpleados()
    {
        return View("SubidaEmpleadosPOST");
    }

    [HttpPost]
    public IActionResult SubidaEmpleadosPOST(string nombre, int dni, string area, string descripcion, string direccion, int idjefe)
    {
        try
        {
            Empleado Emp = new Empleado(dni,nombre,area,descripcion,direccion,idjefe);
            int cantidadFilasAfectada = BaseDatos.SubirEmpleado(Emp);
            return View();

        }
        catch (System.Exception)
        {
            return View();
        }


    }
}
}
