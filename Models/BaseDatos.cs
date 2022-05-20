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
        private static string _connectionString = @"Server=DESKTOP-4CCAH31;DataBase=GestionARG;Trusted_Conecction=True;";

     /*    public static Persona ConsultaGestionARG(int IdEmpleado)
        {
            Persona IdEmpleado = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Nombre, Apellido, IdEstablecimiento, Voto, NumeroTramite FROM Personas WHERE DNI"; 
            }
            return IdEmpleado;
        }*/
    }
}