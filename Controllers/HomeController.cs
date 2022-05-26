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

    public IActionResult Index()
    {
        return View();
    }

     public IActionResult VerEmpleados(int IdEmpleado)
        {

            string cadena = @"Server=DESKTOP-BSJ52N9\MSQLSERVER;DataBase=GestionARG;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(cadena);
            SqlDataAdapter da = new SqlDataAdapter("SELECT NOMBRE, DNI, AREA, DESCRIPCION FROM Empleados",con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return View(dt);

        } 
}
