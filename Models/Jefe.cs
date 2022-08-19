using System;

namespace GestionARG.Models
{
    public class Jefe
    {
        public int _IdJefe { get; set; }

        public string _Nombre { get; set; }

        public int _DNI { get; set; }


        public Jefe(int IdJefe, string Nombre, int DNI)
        {
            _IdJefe = IdJefe;
            _Nombre = Nombre;
            _DNI = DNI;
        }
    }
}
