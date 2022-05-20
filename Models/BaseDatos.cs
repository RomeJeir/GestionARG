using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace GestionARG.Models
{
    public class BaseDatos
    {
         private static List<Persona> _ListaPersonas = new List<Persona>();
        
        private static string _connectionString = @"Server=DESKTOP-4CCAH31;DataBase=GestionARG;Trusted_Conecction=True;";

     /*    public static Persona ConsultaEmpleado(int IdEmpleado)
        {
            Persona IdEmpleado = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Nombre, Direccion, DNI FROM Empleados "; 
            }
            return IdEmpleado;
        }*/
    }
}