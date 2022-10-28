using System;

namespace GestionARG.Models
{
    public class EmpleadoTareaPromedio
    {
        public string NombreEmpleado { get; set; }

        public float Promedio { get; set; }

        public int TareasHechasXEmpleado {get; set;}

        public EmpleadoTareaPromedio()
        {    }
    }
}
