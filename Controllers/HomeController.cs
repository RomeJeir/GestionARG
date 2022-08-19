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
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Forms.v1.Data;

namespace GestionARG.Controllers
{

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
            ViewBag.ListaEmpleados = BaseDatos.ListarEmpleados();
            t.fechaCreacion = DateTime.Now;
            t.fechaLimite = t.fechaCreacion.AddDays(7);
            //t.descripcion ="ingrese";
            return View(t);
        }

        [HttpPost]
        public IActionResult SubidaTareas(Tarea laTarea)
        {
            int cantidadFilasAfectada = BaseDatos.SubirTarea(laTarea);
            ViewBag.Mensaje = "La tarea se grabó correctamente";
            ViewBag.ListaEmpleados = BaseDatos.ListarEmpleados();
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
            Empleado Emp = new Empleado
            {
                Nombre = nombre,
                DNI = dni,
                IdArea = idArea,
                IdJefe = idjefe,
                Direccion = direccion,
                Descripcion = descripcion
            };
            int cantidadFilasAfectada = BaseDatos.SubirEmpleado(Emp);
            ViewBag.Mensaje = "El empleado se grabó correctamente";

            ViewBag.ListaJefes = BaseDatos.ListarJefe();
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            

            //if(idArea == 3){

            //Google();

            //}else{

                return View();
            //}
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public async Task<IActionResult> Google()
        {

            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { FormsService.Scope.FormsBody },
                    "romeojeir@gmail.com", CancellationToken.None);
            }

            // Create the service.
            var service = new FormsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GestionARG",
            });

            

            var Form = new Form();
            Form.Items= new List<Item> ();
            
            Item item = new Item();
            Form.Info = new Info();

        
        //public BatchUpdateRequest(IClientService service, BatchUpdateFormRequest body, string formId){

            Form.Info.Description = "Formulario de Romeo";
            Form.Info.DocumentTitle="GestionARG";
            //Form.Info.ETag="GestionARG";
            item.QuestionItem = new QuestionItem();
            item.QuestionItem.Question = new Question();
            item.QuestionItem.Question.TextQuestion = new TextQuestion();
            //item.QuestionItem.Question.TextQuestion.ETag = "Como estas";
            item.QuestionItem.Question.TextQuestion.Paragraph = true;

            Form.Items.Add(item);
            var formResource = new FormsResource(service);
            var formrequest = formResource.Create(Form);
            //var form = await formrequest.ExecuteAsync();

        //}

            return View("Index");
        }
    }
}                    