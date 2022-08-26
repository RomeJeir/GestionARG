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
            string sentencia = "INSERT INTO Tareas (NOMBRE, FECHALIMITE, FECHACREACION, PUNTAJE, DESCRIPCION, IDEMPLEADO) VALUES (" + ToSQLString(tar.nombre) + ", " + ToSQLDate(tar.fechaLimite) + ",  " + ToSQLDate(tar.fechaCreacion) + ", " + ToSQLString(tar.puntaje) + ", " + ToSQLString(tar.descripcion) + " , " + tar.idEmpleado + ")";

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

         public static List<Empleado> ListarEmpleadosVentas()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Empleados.Nombre, Tareas.Nombre FROM Empleados INNER JOIN Tareas on Tareas.IdEmpleado = Empleados.IdEmpleado WHERE Area = 3";
                return db.Query<Empleado>(sql).ToList();
            }
        }


        
    }
}