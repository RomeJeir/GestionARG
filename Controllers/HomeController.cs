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
using Google.Apis.Services; 
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

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
        ViewBag.ListaAreas = BaseDatos.ListarArea();
        ViewBag.ListaJefes = BaseDatos.ListarJefe();
        return View("SubidaEmpleadosPOST");
    }

    [HttpPost]
    public IActionResult SubidaEmpleadosPOST(string nombre, int dni, int idArea, string descripcion, string direccion, int idjefe)
    {
            Empleado Emp = new Empleado {
                Nombre = nombre,
                DNI=dni,
                IdArea=idArea,
                IdJefe=idjefe,
                Direccion=direccion,
                Descripcion=descripcion
            };
            //ViewBag.ListaEmpleados = BaseDatos.ListarEmpleados();
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            int cantidadFilasAfectada = BaseDatos.SubirEmpleado(Emp);
            return View();


    }

    public IActionResult Formulario()
    {
        return View();
    }

    /*public async Task<IActionResult> Google(){
        ClientSecrets secrets = new ClientSecrets()
        {
            ClientId = 320156936652-jk2u9rpcld5q7droid5o6sqs1ac5eto1.apps.googleusercontent.com,
            ClientSecret = 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,

        };

        var token = new TokenResponse { RefreshToken = "1//04Ru7tcS-_92-CgYIARAAGAQSNwF-L9Irk84QPAxFrgmmDM73m3B7fkS6AxpCu6AKpVuTVLlAXwkS2vcoE5tMLQWS6b__MX-1k7I" }; 
        var credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
            new GoogleAuthorizationCodeFlow.Initializer 
            {
                ClientSecrets = secrets
            }), 
            "user", 
            token);

            // Create the service.
            var service = new FormsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "GestionARG",
                });

            var formResource = new FormsResource(service);
            var formrequest = formResource.Get("1NKQ9ma2ouRDIQLbBdITvbjAs4VXzupmlEzY5RiVgqWA");
            var form = await formrequest.ExecuteAsync();
            
            return View ("Index");
    }*/
}
}



