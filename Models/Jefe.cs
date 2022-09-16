using System;

namespace GestionARG.Models
{
    public class Jefe
    {
        public int _IdJefe { get; set; }

        public int IdJefe
        {
            get
            {
                return _IdJefe;
            }
            set
            {
                _IdJefe = value;
            }
        }

        public string _Nombre { get; set; }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        public int _DNI { get; set; }

        public int DNI
        {
            get
            {
                return _DNI;
            }
            set
            {
                _DNI = value;
            }
        }

        public string _Area { get; set; }

        public string Area
        {
            get
            {
                return _Area;
            }
            set
            {
                _Area = value;
            }
        }


        public Jefe(int IdJefe, string Nombre, int DNI, string Area)
        {
            _IdJefe = IdJefe;
            _Nombre = Nombre;
            _DNI = DNI;
            _Area = Area;
        }

        public Jefe()
        {

        }
    }
}
