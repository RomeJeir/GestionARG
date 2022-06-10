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
            
            private static string _connectionString = @"Server=DESKTOP-4CCAH31;DataBase=GestionARG;Trusted_Conecction=True;";
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
        public static void SubidaTareas(){

            using(SqlConnection db = new SqlConnection(_connectionString)){

                string sql = "INSERT INTO Tareas";



            }
        }


        public static int SubirEmpleado(Empleado emp)
        {
            Conectar();
            string sentencia = "INSERT INTO Empleados (NOMBRE, DNI, AREA, DESCRIPCION, DIRECCION, IDJEFE) VALUES ('"+ emp.Nombre +"', "+ emp.DNI +", '"+ emp.Area + "', '"+ emp.Descripcion + "', '" + emp.Direccion +"'," + emp.IdJefe + ")";
            SqlCommand Consulta = con.CreateCommand();
            Consulta.CommandText = sentencia;
            Consulta.CommandType = CommandType.Text;
            
            int cantidadFilasAfectada = Consulta.ExecuteNonQuery();
            Desconectar();
            return cantidadFilasAfectada;
        }

               public static int SubirTarea(Tarea tar)
        {
            Conectar();
            string sentencia = "INSERT INTO Empleados (Nombre, FechaLimite, FechaCreacion, Puntaje, Descripcion, IdEmpleado) VALUES ('"+ tar.Nombre +"', "+ tar.FechaLimite +", '"+ tar.FechaCreacion + "', '"+ tar.Puntaje + "', '" + tar.Descripcion +"'," + tar.IdEmpleado + ")";
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