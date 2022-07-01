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
            private static List<Empleado> _ListaPersonas = new List<Empleado>();

            private static List<Tarea> _ListaTarea = new List<Tarea>();
            
            private static string _connectionString = @"Server=A-CIDI-106;DataBase=GestionARG;Trusted_Conecction=True;";
            private static SqlConnection con;
        

        private static void Conectar()
        {
            string cadena = @"Server=A-CIDI-106;DataBase=GestionARG;Trusted_Connection=True;";
            con = new SqlConnection(cadena);
            con.Open();

        }
        private static void Desconectar()
        {
            con.Close();
        }   

        public static int SubirEmpleado(Empleado emp)
        {
            Conectar();
            string sentencia = "INSERT INTO Empleados (NOMBRE, DNI, AREA, DESCRIPCION, DIRECCION, IDJEFE) VALUES ('"+ emp.Nombre +"', "+ emp.DNI +", '"+ emp.Area + "', '"+ emp.Descripcion + "', '" + emp.Direccion +"'," + emp.IdJefe + ")";
            ViewBag.ListaEmpleados = BaseDatos.ListarEmpleados();
            System.Console.WriteLine("La tarea es NULL");
            SqlCommand Consulta = con.CreateCommand();
            Consulta.CommandText = sentencia;
            Consulta.CommandType = CommandType.Text;
            
            int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
            Desconectar();
            return cantidadFilasAfectada;
        }

        public static string ToSQLString (string dato){
            string returnString;
            if (dato!=null){
                returnString = "'" + dato + "'";
            }else{
                returnString = "NULL";
            }
            return returnString;

        }

        public static string ToSQLDate (DateTime dato){
            string returnString;
            if (dato!=null){
                returnString = "'" + dato.ToString("yyyy-MM-dd")  + "'";
            }else{
                returnString = "NULL";
            }
            return returnString;

        }

        public static int SubirTarea(Tarea tar)
        {
            Conectar();
            string sentencia = "INSERT INTO Tareas (NOMBRE, FECHALIMITE, FECHACREACION, PUNTAJE, DESCRIPCION, IDEMPLEADO) VALUES ("+ ToSQLString (tar.nombre) + ", " + ToSQLDate(tar.fechaLimite) + ",  " +  ToSQLDate(tar.fechaCreacion) +  ", " + ToSQLString (tar.puntaje) + ", " + ToSQLString (tar.descripcion) +" , " + tar.idEmpleado +")";

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
            SqlDataAdapter da = new SqlDataAdapter("SELECT NOMBRE, DNI, AREA, DESCRIPCION FROM Empleados",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;


        }

    }
}