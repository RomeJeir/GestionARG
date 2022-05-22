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
         private static List<Empleado> _ListaPersonas = new List<Empleado>();
        
        private static string _connectionString = @"Server=DESKTOP-4CCAH31;DataBase=GestionARG;Trusted_Conecction=True;";
    }
}