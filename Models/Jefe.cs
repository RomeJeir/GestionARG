using System;

namespace GestionARG.Models
{
    public class Jefe
    {
        public int IdJefe { get; set; }

        public string Nombre { get; set; }

        public int DNI { get; set; }


        public Jefe(int IdJefe, string Nombre, int DNI)
        {
            IdJefe = IdJefe;
            Nombre = Nombre;
            DNI = DNI;
        }

        public Jefe()
        {

        }
    }
}