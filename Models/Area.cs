using System;

namespace GestionARG.Models
{
    public class Area
    {
        public int _IdArea { get; set; }

        private string _Nombre;

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

        public Area(int idArea, string nombre)
        {
            _IdArea = idArea;
            _Nombre = nombre;
        }

    }
}