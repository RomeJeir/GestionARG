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

namespace GestionARG.Controllers{

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerEmpleados(int IdEmpleado)
        {

            string cadena = @"Server=A-CIDI-106;DataBase=GestionARG;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(cadena);
            SqlDataAdapter da = new SqlDataAdapter("SELECT NOMBRE, DNI, AREA, DESCRIPCION FROM Empleados",con);
            DataTable dt = new DataTable();

            da.Fill(dt);

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

    
    public IActionResult SubidaTareasPOST(string nombreTarea , DateTime FechaLimite , DateTime FechaAsignacion , string Valoracion , string Descripcion)
    {
        try

        {

        string cadena = @"Server=A-CIDI-106;DataBase=GestionARG;Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(cadena);
        con.Open();
        
        }

    }
    public IActionResult SubidaEmpleados(){

        return View();

    }

    public IActionResult SubidaEmpleadosPOST(string nombre, int dni, string area, string descripcion, string direccion)
    {

        try

        {

        string cadena = @"Server=A-CIDI-106;DataBase=GestionARG;Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(cadena);
        con.Open();
        string sentencia = "INSERT INTO Empleados (NOMBRE, DNI, AREA, DESCRIPCION, DIRECCION) VALUES ('"+ nombre +"', '"+ dni +"', '"+ area + "', '" + descripcion + "', '" + direccion +"')";
        SqlCommand Consulta = new SqlCommand();
        Consulta.CommandText = sentencia;
        Consulta.CommandType = CommandType.StoredProcedure;

        int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
        con.Close();

        if(cantidadFilasAfectada != 1){ 
            throw new ApplicationException("No se agrego el empleado");
        }

        TempData["MSG"] = "Se subio el empelado con exito" + string.Format("{0} {1} {2} {3} {4}", nombre, dni, area, descripcion, direccion);

        return View("SubidaEmpleados");

        }
        catch (System.Exception ex)
        {
            
            TempData["MSG"] = "No se agrego... " + string.Format("{0} {1} {2} {3} {4}", nombre, dni, area, descripcion, direccion, ex.Message);
            return View("SubidaEmpleados");
        }


    }
}
}
