using System;

namespace GestionARG.Models
{
    public class Area
    {
        public int _IdArea { get; set; }

        public int IdArea
        {
            get
            {
                return _IdArea;
            }
            set
            {
                _IdArea = value;
            }
        }

        private int _IdJefe { get; set; }

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

        public Area(int idArea, string nombre, int IdJefe)
        {
            _IdArea = idArea;
            _Nombre = nombre;
            _IdJefe = IdJefe;
        }

    }
}