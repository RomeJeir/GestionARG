using System;

namespace GestionARG.Models
{
    public class Area
    {
        public int IdArea {get;set;}

        private string _Nombre;

        public string Nombre{
            get{
                return _Nombre;
            }
            set{
                _Nombre=value;
            }
        }

        public Area (int idArea, string nombre)
        {
            IdArea = idArea;
            _Nombre = nombre;
        }

        public Area ()
        {

        }
    }
}