using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace GestionARG.Models
{
    public static class BaseDatos
    {
        private static string _connectionString = @"Server=A-PHZ2-CIDI-044;DataBase=GestionARG;Trusted_Connection=true";
        private static SqlConnection con;


        private static void Conectar()
        {
            con = new SqlConnection(_connectionString);
            con.Open();

        }
        private static void Desconectar()
        {
            con.Close();
        }


        public static int SubirEmpleado(Empleado emp)
        {
            Conectar();
            string sentencia = "INSERT INTO Empleados (NOMBRE, DNI, IDAREA, DESCRIPCION, DIRECCION, IDJEFE) VALUES ('" + emp.Nombre + "', " + emp.DNI + ", " + emp.IdArea + ", '" + emp.Descripcion + "', '" + emp.Direccion + "'," + emp.IdJefe + ")";
            var ListaEmpleados = BaseDatos.ListarEmpleados();
            System.Console.WriteLine("La tarea es NULL");
            SqlCommand Consulta = con.CreateCommand();
            Consulta.CommandText = sentencia;
            Consulta.CommandType = CommandType.Text;

            int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
            Desconectar();
            return cantidadFilasAfectada;
        }

        public static string ToSQLString(string dato)
        {
            string returnString;
            if (dato != null)
            {
                returnString = "'" + dato + "'";
            }
            else
            {
                returnString = "NULL";
            }
            return returnString;

        }

        public static string ToSQLDate(DateTime dato)
        {
            string returnString;
            if (dato != null)
            {
                returnString = "'" + dato.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                returnString = "NULL";
            }
            return returnString;

        }

        public static int SubirTarea(Tarea tar)
        {
            Conectar();
            //string sentencia2 = 
            string sentencia = "INSERT INTO Tareas (NOMBRE) VALUES (" + ToSQLString(tar.nombre) + ")";
            var ListaTareas = BaseDatos.ListarTareas();
            SqlCommand Consulta = con.CreateCommand();
            Consulta.CommandText = sentencia;
            Consulta.CommandType = CommandType.Text;
            int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
            Desconectar();
            return cantidadFilasAfectada;
        }


        public static int SubirTareaHecha(Tarea tar)
        {
            Conectar();
            string sentencia = "INSERT INTO Tareas (IDTAREAREALIZADA, FECHACREACION, PUNTAJE, IDTAREA, IDEMPLEADO) VALUES (" + tar.idTareaRealizada + ", " + ToSQLDate(tar.fechaCreacion) + ", " + ToSQLString(tar.puntaje) + ",  " + tar.idTarea + " , " + tar.idEmpleado + ")";
            var ListaTareas = BaseDatos.ListarTareas();
            SqlCommand Consulta = con.CreateCommand();
            Consulta.CommandText = sentencia;
            Consulta.CommandType = CommandType.Text;
            int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
            Desconectar();
            return cantidadFilasAfectada;
        }


        public static DataTable VerEmpleados()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SELECT e.NOMBRE, e.DNI, e.IDAREA, a.Nombre as Area, e.DESCRIPCION FROM Empleados e join Areas a on e.idArea=a.idArea", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public static List<Empleado> ListarEmpleados()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Empleados";

                return db.Query<Empleado>(sql).ToList();
            }
        }

        public static List<Area> ListarArea()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Areas";

                return db.Query<Area>(sql).ToList();
            }
        }

        public static List<Jefe> ListarJefe()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Jefes";

                return db.Query<Jefe>(sql).ToList();
            }
        }

         public static List<EmpleadoTarea> ListarEmpleadosVentas()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Tarea.Nombre as NombreTarea, TareasRealizadas.Puntaje as PuntajeTareas, TareasRealizadas.FechaCreacion, Empleados.Nombre From TareasRealizadas INNER JOIN Empleados on TareasRealizadas.IdEmpleado = Empleados.IdEmpleado INNER JOIN Tarea on Tarea.IdTarea = TareasRealizadas.IdTarea Where Area = 1";
                return db.Query<EmpleadoTarea>(sql).ToList();
            }
        }

         public static List<EmpleadoTarea> ListarEmpleadosAdministracion()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Tarea.Nombre as TareaNombre, TareasRealizadas.Puntaje as PuntajeTareas, TareasRealizadas.FechaCreacion as Fecha, Empleados.Nombre as NombreEmpleado From TareasRealizadas INNER JOIN Empleados on TareasRealizadas.IdEmpleado = Empleados.IdEmpleado INNER JOIN Tarea on Tarea.IdTarea = TareasRealizadas.IdTarea Where Area = 3";
                return db.Query<EmpleadoTarea>(sql).ToList();
            }
        }

        public static List<Tarea> ListarTareas()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Tarea";

                return db.Query<Tarea>(sql).ToList();
            }
        }

        
    }
}