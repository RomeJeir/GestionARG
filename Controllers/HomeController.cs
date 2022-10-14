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

        public IActionResult DepartamentoCompras()
        {
           List<EmpleadoTarea> datos = BaseDatos.ListarEmpleadosCompras();
           
            ViewBag.ListaEmpleadosTarea = datos;
            return View();
        }

        public IActionResult DepartamentoAdministracion()
        {
            List<EmpleadoTarea> datos = BaseDatos.ListarEmpleadosAdministracion();
            ViewBag.ListaEmpleadosTarea = datos;
            return View();
        }
        
        public IActionResult Tareas()
        {
            ViewBag.ListaTareas = BaseDatos.ListarTareas();
            return View();
        }

        public IActionResult TareaHecha()
        {
            ViewBag.ListaTareas = BaseDatos.ListarTareas();
            TareaHecha t = new TareaHecha();
            t.fechaCreacion = DateTime.Now;
            ViewBag.ListaEmpleados = BaseDatos.ListarEmpleados();
            return View(t);
        }

        [HttpPost]
        public IActionResult TareaHechaPost(TareaHecha laTarea)
        {
            int cantidadFilasAfectada = BaseDatos.SubirTareaHecha(laTarea);
            return RedirectToAction("Tareas", "Home");
        }

        public IActionResult SubidaTareas()
        {
            
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            Tarea t = new Tarea();
            //t.nombre = "Romeo";
            t.fechaCreacion = DateTime.Now;
            //t.descripcion ="ingrese";
            return View(t);
        }

        [HttpPost]
        public IActionResult SubidaTarea(Tarea laTarea)
        {
            if(laTarea.idTarea>0){  
                int cantidadFilasAfectada = BaseDatos.ModificarTarea(laTarea);
            }

            else{
                int cantidadFilasAfectada = BaseDatos.SubirTarea(laTarea);
            }
            return RedirectToAction("Tareas", "Home");
        }

        public IActionResult SubidaEmpleados()
        {
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            ViewBag.ListaJefes = BaseDatos.ListarJefe();
            ViewBag.ListarClientes = BaseDatos.ListarClientes();
            return View();
        }

        public async Task<IActionResult> Google(Empleado emp)
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

            Form.Info.DocumentTitle="GestionARG";
            Form.Info.Title="GestionARG";
            
            var formResource = new FormsResource(service);
            var formrequest = formResource.Create(Form);
            var form = await formrequest.ExecuteAsync();

            Form.Items.Add(item);
            var brequest = new BatchUpdateFormRequest();
            brequest.Requests = new List<Request>();
            var request = new Request();
            var createItem = new CreateItemRequest();
            createItem.Item= item;
            createItem.Location = new Location();
            createItem.Location.Index = 0;
            request.CreateItem = createItem;
            brequest.Requests.Add(request);

            item.Title="¿Como fue el desempeño del vendedor?";
            item.QuestionItem = new QuestionItem();
            item.QuestionItem.Question = new Question();
            item.QuestionItem.Question.ChoiceQuestion = new ChoiceQuestion();
            item.QuestionItem.Question.ChoiceQuestion.Options = new List<Option>();
            item.QuestionItem.Question.ChoiceQuestion.Type = "CHECKBOX";
            
            var option = new Option();
            option.Value= "Excelente";
            item.QuestionItem.Question.ChoiceQuestion.Options.Add(option);
            
            option = new Option();
            option.Value= "Muy Buena";
            item.QuestionItem.Question.ChoiceQuestion.Options.Add(option);
            
            option = new Option();
            option.Value= "Buena";
            item.QuestionItem.Question.ChoiceQuestion.Options.Add(option);

            option = new Option();
            option.Value= "Mala";
            item.QuestionItem.Question.ChoiceQuestion.Options.Add(option);

            option = new Option();
            option.Value= "Muy mala";
            item.QuestionItem.Question.ChoiceQuestion.Options.Add(option);

            option = new Option();
            option.Value= "Terrible";
            item.QuestionItem.Question.ChoiceQuestion.Options.Add(option);

            var batchUpdate = new FormsResource.BatchUpdateRequest(service, brequest, form.FormId);
            await batchUpdate.ExecuteAsync();
            
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SubidaEmpleadosPOST(string nombre, int dni, int idArea, string descripcion, string direccion, int idjefe)
        {
            Empleado Emp = new Empleado()
            {
                Nombre = nombre,
                DNI = dni,
                IdArea = idArea,
                IdJefe = idjefe,
                Direccion = direccion,
                Descripcion = descripcion
            };
            int cantidadFilasAfectada = BaseDatos.SubirEmpleado(Emp);


            ViewBag.ListaJefes = BaseDatos.ListarJefe();
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            

            if(idArea == 1){

            var result = await Google(Emp);

            return View("SubidaEmpleados");

            }else{

               return View("SubidaEmpleados");
            }
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public IActionResult EliminarTarea(int IdTarea)
        {
            BaseDatos.EliminarTarea(IdTarea);
            ViewBag.ListaTareas = BaseDatos.ListarTareas();
            return View("Tareas");
        }

        public IActionResult EditarTarea(int IdTarea)
        {
            var tarea = BaseDatos.GetTarea(IdTarea);
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            return View("SubidaTareas", tarea);
        }
    }
}                    