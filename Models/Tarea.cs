using System;

namespace GestionARG.Models
{
    public class Tarea
    {
        private string _nombre;
        private DateTime _fechaLimite;
        private DateTime _fechaCreacion;
        private string _puntaje;
        private string _descripcion;
        private int _idEmpleado;

        public string nombre{
            get{
                return _nombre;
            }
            set{
                _nombre=value;
            }
                }

         public DateTime fechaLimite{
            get{
                return _fechaLimite;
            }
            set{
                _fechaLimite=value;
            }
                    }
        public DateTime fechaCreacion{
            get{
                return _fechaCreacion;
            }
            set{
                _fechaCreacion=value;
            }
                }

        public string puntaje{
            get{
                return _puntaje;
            }
            set{
                _puntaje=value;
            }
                }
        public string descripcion{
            get{
                return _descripcion;
            }
            set{
                _descripcion=value;
            }
                }
        public int idEmpleado{
            get{
                return _idEmpleado;
            }
            set{
                _idEmpleado=value;
            }
                }

        public Tarea (string nombre, DateTime fechaCreacion, DateTime fechaLimite, string puntaje, string descripcion, int idEmpleado)
        {
            _nombre = nombre;
            _fechaCreacion = fechaCreacion;
            _fechaLimite = fechaLimite;
            _puntaje = puntaje;
            _descripcion = descripcion;
            _idEmpleado = idEmpleado;
        }
    }
}