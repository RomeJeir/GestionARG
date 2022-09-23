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
            ViewBag.ListaEmpleadosTarea = BaseDatos.ListarEmpleadosVentas();
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
            ViewBag.ListaEmpleados = BaseDatos.ListarEmpleados();
            return View();
        }

        public IActionResult SubidaTareas()
        {
            
            ViewBag.ListaTareas = BaseDatos.ListarTareas();
            Tarea t = new Tarea();
            //t.nombre = "Romeo";
            t.fechaCreacion = DateTime.Now;
            //t.descripcion ="ingrese";
            return View(t);
        }

        [HttpPost]
        public IActionResult SubidaTareas(Tarea laTarea)
        {
            int cantidadFilasAfectada = BaseDatos.SubirTarea(laTarea);
            ViewBag.Mensaje = "La tarea se grabó correctamente";
            return View(new Tarea());
        }

        public IActionResult SubidaEmpleados()
        {
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            ViewBag.ListaJefes = BaseDatos.ListarJefe();
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
        public IActionResult SubidaEmpleadosPOST(string nombre, int dni, int idArea, string descripcion, string direccion, int idjefe)
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
            ViewBag.Mensaje = "El empleado se grabo correctamente";

            ViewBag.ListaJefes = BaseDatos.ListarJefe();
            ViewBag.ListaAreas = BaseDatos.ListarArea();
            

            //if(idArea == 1){

            //Google();

            //}else{

               return View("SubidaEmpleados");
            //}
        }

        public IActionResult Formulario()
        {
            return View();
        }

    }
}                    