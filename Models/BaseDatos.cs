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
        private static string _connectionString = @"Server=LAPTOP-RVSO9NN5;DataBase=GestionARG;Trusted_Connection=true";
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
            string sentencia = "INSERT INTO Tarea (NOMBRE, IDAREA, DESCRIPCION, FECHACREACION) VALUES (" + ToSQLString(tar.nombre) + " , " + tar.idArea + "," + ToSQLString(tar.descripcion) + " , " + ToSQLDate(tar.fechaCreacion) + ")";
            var ListaTareas = BaseDatos.ListarTareas();
            SqlCommand Consulta = con.CreateCommand();
            Consulta.CommandText = sentencia;
            Consulta.CommandType = CommandType.Text;
            int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
            Desconectar();
            return cantidadFilasAfectada;
        }

        public static int ModificarTarea(Tarea tar)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sentencia = "UPDATE [dbo].[Tarea] SET [Nombre] = @Nombre, [IdArea] = @IdArea, [Descripcion] = @Descripcion, [FechaCreacion] = @FechaCreacion WHERE idtarea = @idtarea";
                int cantidadFilasAfectada = db.Execute(sentencia, new { Nombre = tar.nombre, IdArea = tar.idArea, Descripcion = tar.descripcion, IdTarea = tar.idTarea, FechaCreacion = tar.fechaCreacion });
                return cantidadFilasAfectada;
            }
        }


        public static int SubirTareaHecha(TareaHecha tar)
        {
            Conectar();
            string sentencia = "INSERT INTO TareasRealizadas (FECHACREACION, PUNTAJE, IDTAREA, IDEMPLEADO) VALUES (" + ToSQLDate(tar.fechaCreacion) + ", " + tar.puntaje + ",  " + tar.idTarea + " , " + tar.idEmpleado + ")";
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

        public static List<Cliente> ListarClientes()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cliente";

                return db.Query<Cliente>(sql).ToList();
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

        public static List<EmpleadoTarea> ListarEmpleadosCompras()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Tarea.Nombre as TareaNombre,  case TareasRealizadas.Puntaje WHEN '1' Then 'Malo' WHEN '2' THEN 'Intermedio' WHEN '3' Then 'Bueno' END as PuntajeTareas,TareasRealizadas.FechaCreacion as Fecha, Empleados.Nombre as NombreEmpleado From TareasRealizadas INNER JOIN Empleados on TareasRealizadas.IdEmpleado = Empleados.IdEmpleado INNER JOIN Tarea on Tarea.IdTarea = TareasRealizadas.IdTarea Where Tarea.IdArea = 2";
                return db.Query<EmpleadoTarea>(sql).ToList();
            }
        }

        public static List<EmpleadoTarea> ListarEmpleadosAdministracion()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Tarea.Nombre as TareaNombre,  case TareasRealizadas.Puntaje WHEN '1' Then 'Malo' WHEN '2' THEN 'Intermedio' WHEN '3' Then 'Bueno' END as PuntajeTareas,TareasRealizadas.FechaCreacion as Fecha, Empleados.Nombre as NombreEmpleado From TareasRealizadas INNER JOIN Empleados on TareasRealizadas.IdEmpleado = Empleados.IdEmpleado INNER JOIN Tarea on Tarea.IdTarea = TareasRealizadas.IdTarea Where Tarea.IdArea = 3";
                return db.Query<EmpleadoTarea>(sql).ToList();
            }
        }

                public static List<EmpleadoTareaPromedio> ListarPromedioEmpleadosCompras()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT AVG(CAST(TareasRealizadas.Puntaje as FLOAT)) as Promedio , COUNT(TareasRealizadas.IdEmpleado) as TareasHechasXEmpleado, Empleados.Nombre as NombreEmpleado from TareasRealizadas inner join Empleados on TareasRealizadas.IdEmpleado = Empleados.IdEmpleado where Empleados.IdArea = 1 group by TareasRealizadas.IdEmpleado, Empleados.Nombre";
                return db.Query<EmpleadoTareaPromedio>(sql).ToList();
            }
        }

       public static List<EmpleadoTareaPromedio> ListarPromedioEmpleadosAdministracion()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT AVG(CAST(TareasRealizadas.Puntaje as FLOAT)) as Promedio , COUNT(TareasRealizadas.IdEmpleado) as TareasHechasXEmpleado, Empleados.Nombre as NombreEmpleado from TareasRealizadas inner join Empleados on TareasRealizadas.IdEmpleado = Empleados.IdEmpleado where Empleados.IdArea = 3 group by TareasRealizadas.IdEmpleado, Empleados.Nombre";
                return db.Query<EmpleadoTareaPromedio>(sql).ToList();
            }
        }



        public static List<Tarea> ListarTareas()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Tarea WHERE NOT EXISTS (SELECT * FROM TareasRealizadas WHERE Tarea.IdTarea = TareasRealizadas.IdTarea );";

                return db.Query<Tarea>(sql).ToList();
            }
        }

        public static Tarea GetTarea(int idTarea)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Tarea where idTarea = @idTarea";

                return db.Query<Tarea>(sql, new { idTarea }).SingleOrDefault();
            }
        }

        public static void EliminarTarea(int idTarea)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Open();
                string sql = "Delete Tarea where IdTarea = @idTarea";

                db.Execute(sql, new { idTarea });
            }
        }


    }
}