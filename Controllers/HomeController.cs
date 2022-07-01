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
using Google.Apis.Forms.v1;

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
        Tarea t = new Tarea();
        //t.nombre = "Romeo";
        t.fechaCreacion = DateTime.Now;
        t.fechaLimite = t.fechaCreacion.AddDays(7);
        //t.descripcion ="ingrese";
        return View(t);
    }

    [HttpPost]
    public IActionResult SubidaTareas(Tarea laTarea){ 

        try {
                //Tarea tar = new Tarea(nombre,fechaLimite,fechaCreacion,puntaje,descripcion,idEmpleado);
                int cantidadFilasAfectada = BaseDatos.SubirTarea(laTarea);
                

        } catch (System.Exception){
            //
        }

        return View(new Tarea());
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

    public IActionResult Formulario(){

        

        return View();
    }
}
}


